using Newtonsoft.Json;
using Microsoft.JScript;
using System;
using System.Web;
using System.Web.SessionState;
using HaiDen.Controller;
using static HaiDen.Handling.Banner_Handling;

namespace TruongView.Common
{
    /// <summary>
    /// Summary description for HandlerRequest
    /// </summary>
    public class HandlerRequest : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var result = "";
            context.Response.ContentType = "text/json";
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var stpe = context.Request["stpe"];

            switch (stpe)
            {
                case "100":
                    var bannerRes = new Banner_Response();
                    try
                    {
                        var CateCtrl = new BannerController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<Banner_Request>(storeSt) : null;
                        bannerRes = CateCtrl.LOAD_BANNER(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(bannerRes));
                    break;
            }

            context.Response.StatusCode = 200;
            context.Response.End();
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