using HaiDen.Admin.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HaiDen.Admin
{
    public partial class Images_Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int idal = int.Parse(Request.QueryString["id"]);
                if (idal != -1)
                {
                    load_data(idal);
                }
            }
        }
        BLL news_bll = new BLL();
        DTO news_dto = new DTO();
        DAO dao = new DAO();
        private void load_data(int idal)
        {
            news_dto.WD_ID = idal; string wd_name = "";
            DataTable dt1_showtv = dao.SHOW_DRESS_ID(news_dto);
            if (dt1_showtv.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1_showtv.Rows)
                {
                    lbl_alname.Text = dr["wd_name"].ToString();
                    wd_name = DataProvider.locDau_v2(dr["wd_name"].ToString());
                    // lbl_aldate.Text = String.Format("{0:d/M/yyyy}", DateTime.Parse(dr["P_date"].ToString()));
                    hdd_alid.Value = idal.ToString();
                    hdd_pj_name.Value = wd_name;
                }
            }
            string htm = "", sohinh = "";
            news_dto.WD_ID = idal;
            DataTable dt = dao.SHOW_DRESS_IMAGES_WD_ID(news_dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++; string idphoto = dr["WDI_ID"].ToString();
                    htm += "<div class=\"photo_main\"><input type=\"hidden\" id=\"id_photo" + stt + "\" value=\"" + idphoto + "\" />";
                    htm += "<a class=\"button red small del_img\" onclick=\"del_img('" + idphoto + "','" + dr["WDI_FILE"] + "','" + wd_name + "')\" href=\"#\" title=\"Xóa Hình Này\">X</a><img src=\"../Assets/HinhAnh/WeddingDress/" + dr["WDI_FILE"] + ".ashx?width=190&height=190&mode=crop\" />";
                    htm += "<div><input type=\"text\" value=\"" + dr["WDI_NAME"] + "\" class=\"txt_image_title txt_image_title_" + idphoto + "\"/> <input type=\"button\" value=\"Ok\" class=\"btn input btn_inset_title_image\" onclick=\"inserttitle('" + idphoto + "');\"/></div></div>";
                }
            }
            ltr_photo.Text = htm;
            sohinh = dt.Rows.Count.ToString();
            lbl_sh.Text = sohinh;

        }
    }
}