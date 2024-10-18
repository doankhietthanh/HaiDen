using HaiDen.Admin.App_Code;
using HaiDen.Admin.App_Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaiDen.Admin.App_Control
{
    public partial class Header1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string uname = "";
                HttpCookie cookie = Request.Cookies["CookieUserName"];

                if (cookie != null)
                {
                    uname = cookie.Value;
                    Load_infomem(uname);
                }
                else
                {
                    HttpCookie cookie1 = Request.Cookies["SUserName"];
                    if (cookie1 != null)
                    {
                        uname = cookie1.Value;
                        Load_infomem(uname);
                    }
                    else
                    {
                        Response.Redirect("~/Admin/Login.aspx");
                    }
                }
            }
        }
        DTO dto = new DTO();
        BLL bll = new BLL();

        private void Load_infomem(string uname)
        {
            string htm = "";

            dto.AD_MAIL = uname;
            DataTable dt = bll.SHOW_AD_NAME(dto);
            if (dt.Rows.Count > 0)
            {
                string name = dt.Rows[0]["AD_NAME"].ToString();


                ad_img.InnerHtml = "<img src=\"../Assets/HinhAnh/Admins/" + dt.Rows[0]["ad_img"] + ".ashx?width=45&height=45&mode=crop\" data-vl=\"" + dt.Rows[0]["ad_id"] + "\" id=\"img_value\" alt=\"" + dt.Rows[0]["ad_name"] + "\"/>";
            }
        }
        protected void lbtn_thoat_Click(object sender, EventArgs e)
        {
            Response.Cookies["CookieUserName"].Expires = DateTime.Now;
            Response.Cookies["SUserName"].Expires = DateTime.Now;

            Response.Redirect("~/Admin/Login.aspx");
        }
    }
 }