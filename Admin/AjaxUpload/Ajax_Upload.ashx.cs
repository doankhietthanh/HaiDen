using HaiDen.Admin.App_Code;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace HaiDen.Admin.AjaxUpload
{
    /// <summary>
    /// Summary description for Ajax_Upload
    /// </summary>
    public class Ajax_Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString.Count > 0)
            {
                var path = context.Request.QueryString["path"].ToString();
                var mode = context.Request.QueryString["mode"].ToString();
                //Uploaded File Deletion
                if (mode == "Delete")
                {
                    var FileName = string.IsNullOrEmpty(context.Request.QueryString["file"].ToString()) ? "-1" : context.Request.QueryString["file"].ToString();
                    string filePath = HttpContext.Current.Server.MapPath(path) + FileName;
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                //File Upload
                else if(mode == "Upload")
                {
                    
                    //if (!string.IsNullOrEmpty(context.Request.QueryString["file"].ToString()))
                    //{
                    //    var FileName = string.IsNullOrEmpty(context.Request.QueryString["file"].ToString()) ? "-1" : context.Request.QueryString["file"].ToString();
                    //    string filePath = HttpContext.Current.Server.MapPath(path) + FileName;
                    //    if (File.Exists(filePath))
                    //        File.Delete(filePath);
                    //}
                   

                    HttpPostedFile jpeg_image_upload = context.Request.Files[0];

                    // Retrieve the uploaded image
                    Image original_image = System.Drawing.Image.FromStream(jpeg_image_upload.InputStream);

                    var ext = System.IO.Path.GetExtension(context.Request.Files[0].FileName);
                    var fileName = Path.GetFileName(context.Request.Files[0].FileName);

                    if (context.Request.Files[0].FileName.LastIndexOf("\\") != -1)
                    {
                        fileName = context.Request.Files[0].FileName.Remove(0, context.Request.Files[0].FileName.LastIndexOf("\\")).ToLower();
                    }

                    fileName = GetUniqueFileName(fileName, HttpContext.Current.Server.MapPath(path), ext).ToLower();

                    string location = HttpContext.Current.Server.MapPath(path) + fileName + ext;
                    //string SaveLocation = HttpContext.Current.Server.MapPath("images/avatar/")
                    string fileimg = fileName + ext;
                    Bitmap bmpPostedImage = new Bitmap(original_image);
                    Image objImage = ScaleImage(bmpPostedImage, 1200);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        objImage.Save(ms, ImageFormat.Jpeg);
                        var img = Image.FromStream(ms);

                        img.Save(location);
                    }
                    //DTO dto = new DTO();
                    //BLL bll = new BLL();
                    //DAO dao = new DAO();
                    //dto.I_IMG = fileName + ext;
                    //dto.I_TITLE = "";
                    //dto.I_TITLE_EN = "";
                    //dto.Mode = "INSERT";
                    //dao.INSERT_DELETE_IMAGES(dto);
                    ////context.Request.Files[0].SaveAs(location);
                    //context.Response.Write(0);
                    //context.Response.End();
                }
            }
        }
        public static string GetUniqueFileName(string name, string savePath, string ext)
        {

            name = name.Replace(ext, "").Replace(" ", "_");
            name = System.Text.RegularExpressions.Regex.Replace(name, @"[^\w\s]", "");

            var newName = name;
            var i = 0;
            if (System.IO.File.Exists(savePath + newName + ext))
            {
                do
                {
                    i++;
                    newName = name + "_" + i;
                }
                while (System.IO.File.Exists(savePath + newName + ext));

            }
            return newName;
        }

        public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}