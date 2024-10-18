using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaiDen.Admin.App_Code;

namespace HaiDen.Admin
{
    /// <summary>
    /// Summary description for Delete_Product_Img
    /// </summary>
    public class Delete_Product_Img : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write(context.Request["idphoto"]);
            int idphoto = int.Parse(context.Request["idphoto"].ToString());
            string ptfile = context.Request["ptfile"].ToString();
            string p_name = context.Request["p_name"].ToString();
            BLL news_bll = new BLL();
            DTO news_dto = new DTO();
            DAO dao = new DAO();
            string path_img = HttpContext.Current.Server.MapPath("~/Assets/HinhAnh/Weddingdress/") + ptfile;
            if (System.IO.File.Exists(path_img))
                System.IO.File.Delete(path_img);
            //System.IO.File.Delete(path_img);
            news_dto.WDI_ID = idphoto;
            dao.DELETE_DRESS_IMG_ID(news_dto);
            context.Response.Write("Đã xóa photo: " + ptfile);
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