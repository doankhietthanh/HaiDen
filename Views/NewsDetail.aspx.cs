using HaiDen.Handling;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaiDen.Views
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string str = string.IsNullOrEmpty(base.Request.QueryString["id"].ToString()) ? "-1" : base.Request.QueryString["id"].ToString();
                str = (str == "all") ? "-1" : str;
                this.hdAlias.Value = str;
                loadNew(str);
            }


        }

        private void loadNew(string str)
        {
            News_Repository Repository = new News_Repository();
            var req = new News_Request
            {
                N_ID = int.Parse(str)
            };
            var Response = new News_Response();
            try
            {
                Response = Repository.LOAD_NEWS(req);
                if (Response.Code == 0 && Response.DataList.Count > 0)
                {
                    var item = Response.DataList[0];
                    meta_title.InnerText = item.N_NAME;
                    meta_title_fb.Attributes.Add("content", item.N_NAME);
                    meta_title_tw.Attributes.Add("content", item.N_NAME);

                    meta_description.Attributes.Add("content", item.N_DES);
                    meta_description_fb.Attributes.Add("content", item.N_DES);
                    meta_description_tw.Attributes.Add("content", item.N_DES);

                    meta_keywords.Attributes.Add("content", item.N_DES);

                    String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                    String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");

                    meta_img_fb.Attributes.Add("content", strUrl + "Assets/HinhAnh/News/" + item.N_IMG);
                    meta_img_tw.Attributes.Add("content", strUrl + "Assets/HinhAnh/News/" + item.N_IMG);
                }
            }
            catch (Exception ex)
            {

                Response.Code = 501;
                Response.error = ex.Message;
            }


        }
    }
}