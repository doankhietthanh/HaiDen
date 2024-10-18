using System;
using HaiDen.Admin.App_Code;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaiDen.Admin
{
    public partial class Up_Img_Product : System.Web.UI.Page
    {
        DTO dto = new DTO();
        BLL bll = new BLL();
        DAO dao = new DAO();

        private void AddToData(string imgName, string imgThumb)
        {
            string alid = Request.QueryString["id"];
            dto.WDI_ID = -1;
            dto.WDI_NAME = "";
            dto.WDI_FILE = imgName;
            dto.WD_ID = int.Parse(alid);

            dao.INSERT_DRESS_IMG(dto);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod != "POST")
            {
                Response.StatusCode = 405;
                Response.Write("Method Not Allowed");
                return;
            }

            System.Drawing.Image originalImage = null;
            System.Drawing.Bitmap finalImage = null;
            System.Drawing.Graphics graphic = null;
            MemoryStream ms = null;

            try
            {
                // Assuming Dropzone.js sends files under the key "file"
                HttpPostedFile uploadedFile = Request.Files["file[0]"];

                if (uploadedFile == null)
                {
                    throw new Exception("No file received.");
                }

                // Retrieve the uploaded image
                originalImage = System.Drawing.Image.FromStream(uploadedFile.InputStream);

                string folderName = Request.QueryString["name"];
                string name = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetFileName(uploadedFile.FileName);
                string path = Server.MapPath("~/Assets/HinhAnh/WeddingDress/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                Session["tentaptin"] = name;
                uploadedFile.SaveAs(Path.Combine(path, name));

                // Resizing logic
                int targetWidth = 800;
                int targetHeight = 600;
                int width = originalImage.Width;
                int height = originalImage.Height;
                int newWidth, newHeight;
                float targetRatio = (float)targetWidth / targetHeight;
                float imageRatio = (float)width / height;

                if (targetRatio > imageRatio)
                {
                    newHeight = targetHeight;
                    newWidth = (int)Math.Floor(imageRatio * targetHeight);
                }
                else
                {
                    newWidth = targetWidth;
                    newHeight = (int)Math.Floor((float)targetWidth / imageRatio);
                }

                finalImage = new System.Drawing.Bitmap(targetWidth, targetHeight);
                graphic = System.Drawing.Graphics.FromImage(finalImage);
                graphic.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Rectangle(0, 0, targetWidth, targetHeight));
                int pasteX = (targetWidth - newWidth) / 2;
                int pasteY = (targetHeight - newHeight) / 2;
                graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphic.DrawImage(originalImage, pasteX, pasteY, newWidth, newHeight);

                // Save thumbnail to session and database
                ms = new MemoryStream();
                finalImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                string thumbnailId = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                AddToData(name, thumbnailId + name);

                List<Thumbnail> thumbnails = Session["file_info"] as List<Thumbnail> ?? new List<Thumbnail>();
                Session["file_info"] = thumbnails;
                thumbnails.Add(new Thumbnail(thumbnailId, ms.GetBuffer()));

                // Respond with a success message in JSON format
                Response.ContentType = "application/json";
                Response.Write("{\"status\":\"success\",\"thumbnailId\":\"" + thumbnailId + "\"}");
                Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                // Return a JSON error response
                Response.ContentType = "application/json";
                Response.Write("{\"status\":\"error\",\"message\":\"" + ex.Message + "\"}");
                Response.StatusCode = 500;
            }
            finally
            {
                if (finalImage != null) finalImage.Dispose();
                if (graphic != null) graphic.Dispose();
                if (originalImage != null) originalImage.Dispose();
                if (ms != null) ms.Close();
                Response.End();
            }
        }
    }
}
