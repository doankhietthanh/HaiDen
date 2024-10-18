using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaiDen.Views.Control
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.Cookies["CookieUsersName"] != null)
                {
                    this.User_zone.Visible = true;
                    this.Guest_zone.Visible = false;
                    this.User_zone_mobi.Visible = true;
                    this.Guest_zone_mobi.Visible = false;
                }
                else if (base.Request.Cookies["SUsersName"] != null)
                {
                    this.User_zone.Visible = true;
                    this.Guest_zone.Visible = false;
                    this.User_zone_mobi.Visible = true;
                    this.Guest_zone_mobi.Visible = false;
                }
                else
                {
                    this.User_zone.Visible = false;
                    this.Guest_zone.Visible = true;
                    this.User_zone_mobi.Visible = false;
                    this.Guest_zone_mobi.Visible = true;
                }
            }
        }
    }
}