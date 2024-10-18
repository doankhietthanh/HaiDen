using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaiDen.Views
{
    public partial class Collections : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string str = string.IsNullOrEmpty(base.Request.QueryString["alias"].ToString()) ? "-1" : base.Request.QueryString["alias"].ToString();
                str = (str == "all") ? "-1" : str;
                this.hdAlias.Value = str;
            }

        }
    }
}