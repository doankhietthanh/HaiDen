using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;

namespace Common
{
    public class BasePage: System.Web.UI.Page
    {
        ResourceManager rm;
        CultureInfo ci;
        protected override void InitializeCulture()
        {

            HttpCookie cookieLang = HttpContext.Current.Request.Cookies["cookieLang"];
            if (cookieLang == null)
            {
                cookieLang = new HttpCookie("cookieLang","vi-VN");
                cookieLang.Expires = DateTime.Now.AddDays(7);
                HttpContext.Current.Response.Cookies.Add(cookieLang);
            }

            string lang = Convert.ToString(cookieLang.Value);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            rm = new ResourceManager("Resource.Lang", System.Reflection.Assembly.Load("App_GlobalResources"));
            ci = Thread.CurrentThread.CurrentCulture;
            base.InitializeCulture();
        }

    }
}