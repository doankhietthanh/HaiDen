<%@ WebHandler Language="C#" Class="App_upload_Img_APP_LIST" %>

using System.Collections.Generic;
using System;
using System.Drawing;
using System.Web;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public class App_upload_Img_APP_LIST : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.QueryString.Count > 0)
        {
            var path = context.Request.QueryString[1].ToString();
            var files = context.Request.QueryString[0].ToString();
            //Uploaded File Deletion
            if (files != "0")
            {
                string filePath = HttpContext.Current.Server.MapPath(path) + context.Request.QueryString[0].ToString();
                if (File.Exists(filePath))
                    //using (Image imf = Image.FromFile(filePath))
                    //{
                    //    Bitmap bmpPostedImage = new Bitmap(imf);
                    //}
                    File.Delete(filePath);
            }
            //File Upload
            else
            {
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
                objImage.Save(location, ImageFormat.Jpeg);
                //context.Request.Files[0].SaveAs(location);
                context.Response.Write(fileName + ext);
                context.Response.End();
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