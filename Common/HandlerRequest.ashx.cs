using HaiDen.Controller;
using HaiDen.Handling;
using Microsoft.JScript;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace HaiDen.Common
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
                case "101":
                    var collectionRes = new Collection_Response();
                    try
                    {
                        var CateCtrl = new CollectionController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<Collection_Request>(storeSt) : null;
                        collectionRes = CateCtrl.LOAD_COLLECTION(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(collectionRes));
                    break;
                case "102":
                    var orderRes = new OrderProcess_Response();
                    try
                    {
                        var CateCtrl = new OrderProcessController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<OrderProcess_Request>(storeSt) : null;
                        orderRes = CateCtrl.LOAD_ORDERPROCESS(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(orderRes));
                    break;
                case "103":
                    var BrideCateRes = new BrideStoriesCate_Response();
                    try
                    {
                        var CateCtrl = new BrideStoriesController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<BrideStoriesCate_Request>(storeSt) : null;
                        BrideCateRes = CateCtrl.LOAD_BRIDESTORIES_CATE(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(BrideCateRes));
                    break;
                case "104":
                    var AboutUsRes = new AboutUs_Response();
                    try
                    {
                        var CateCtrl = new AboutUsController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<AboutUs_Request>(storeSt) : null;
                        AboutUsRes = CateCtrl.LOAD_ABOUTUS(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(AboutUsRes));
                    break;
                case "105":
                    var NewsRes = new News_Response();
                    try
                    {
                        var CateCtrl = new NewsController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<News_Request>(storeSt) : null;
                        NewsRes = CateCtrl.LOAD_NEWS(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(NewsRes));
                    break;
                case "106":
                    var WeddingDressRes = new WeddingDress_Response();
                    try
                    {
                        var CateCtrl = new WeddingDressController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<WeddingDress_Request>(storeSt) : null;
                        WeddingDressRes = CateCtrl.LOAD_WEDDINGDRESS(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(WeddingDressRes));
                    break;
                case "107":
                    var WeddingDressImgRes = new WeddingDressImg_Response();
                    try
                    {
                        var CateCtrl = new WeddingDressController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<WeddingDressImg_Request>(storeSt) : null;
                        WeddingDressImgRes = CateCtrl.LOAD_WEDDINGDRESSIMG(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(WeddingDressImgRes));
                    break;
                case "108":
                    var InquiryImgRes = new Inquiries_Response();
                    try
                    {
                        var CateCtrl = new InquiriesController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<Inquiries_Request>(storeSt) : null;
                        InquiryImgRes = CateCtrl.INSERT_UPDATE_INQUIRIES(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(InquiryImgRes));
                    break;
                case "109":
                    var usRes = new Users_Response();
                    try
                    {
                        var Ctrl = new UsersController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<Users_Request>(storeSt) : null;
                        usRes = Ctrl.INSERT_UPDATE_USER(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(usRes));
                    break;
                case "110":
                    var uslRes = new Users_Login_Response();
                    try
                    {
                        var Ctrl = new UsersController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<Users_Login_Request>(storeSt) : null;
                        uslRes = Ctrl.LOGIN_USERS(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(uslRes));
                    break;
                case "111":
                    var InquiryGetRes = new Inquiries_Get_Response();
                    try
                    {
                        var CateCtrl = new InquiriesController();
                        var storeSt = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        var req = storeSt != "" ? JsonConvert.DeserializeObject<Inquiries_Get_Request>(storeSt) : null;
                        InquiryGetRes = CateCtrl.LOAD_INQUIRIES(req);
                    }
                    catch (Exception ex) { result = ex.Message.ToString(); }
                    context.Response.Write(JsonConvert.SerializeObject(InquiryGetRes));
                    break;
                case "112":
                    BrideStories_Response response13 = new BrideStories_Response();
                    try
                    {
                        BrideStoriesController controller13 = new BrideStoriesController();
                        string str15 = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        response13 = controller13.LOAD_BRIDESTORIES((str15 != "") ? JsonConvert.DeserializeObject<BrideStories_Request>(str15) : null);
                    }
                    catch (Exception exception30)
                    {
                        result = exception30.Message.ToString();
                    }
                    context.Response.Write(JsonConvert.SerializeObject(response13));

                    break;
                case "113":
                    Faqs_Response response14 = new Faqs_Response();
                    try
                    {
                        FaqController controller14 = new FaqController();
                        string str16 = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        response14 = controller14.LOAD_FAQS((str16 != "") ? JsonConvert.DeserializeObject<Faqs_Request>(str16) : null);
                    }
                    catch (Exception exception31)
                    {
                        result = exception31.Message.ToString();
                    }
                    context.Response.Write(JsonConvert.SerializeObject(response14));

                    break;
                case "114":
                    WeddingDressFav_Response response15 = new WeddingDressFav_Response();
                    try
                    {
                        WeddingDressController controller15 = new WeddingDressController();
                        string str17 = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        response15 = controller15.INSERT_FAVOURITE((str17 != "") ? JsonConvert.DeserializeObject<WeddingDressFav_Request>(str17) : null);
                    }
                    catch (Exception exception32)
                    {
                        result = exception32.Message.ToString();
                    }
                    context.Response.Write(JsonConvert.SerializeObject(response15));

                    break;
                case "115":
                    WeddingDressFavList_Response response16 = new WeddingDressFavList_Response();
                    try
                    {
                        WeddingDressController controller16 = new WeddingDressController();
                        string str18 = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        response16 = controller16.LOAD_WEDDINGDRESS_FAV((str18 != "") ? JsonConvert.DeserializeObject<WeddingDressFavList_Request>(str18) : null);
                    }
                    catch (Exception exception33)
                    {
                        result = exception33.Message.ToString();
                    }
                    context.Response.Write(JsonConvert.SerializeObject(response16));

                    break;
                case "116":
                    Users_Nationality_Response response17 = new Users_Nationality_Response();
                    try
                    {
                        UsersController controller17 = new UsersController();
                        string str19 = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        response17 = controller17.LOAD_USERS_NATIONALITY((str19 != "") ? JsonConvert.DeserializeObject<Users_Nationality_Request>(str19) : null);
                    }
                    catch (Exception exception34)
                    {
                        result = exception34.Message.ToString();
                    }
                    context.Response.Write(JsonConvert.SerializeObject(response17));

                    break;
                case "117":
                    Info_Response response18 = new Info_Response();
                    try
                    {
                        InfoController controller18 = new InfoController();
                        string str20 = GlobalObject.unescape(context.Request["Request"]) ?? "";
                        response18 = controller18.LOAD_INFO((str20 != "") ? JsonConvert.DeserializeObject<Info_Request>(str20) : null);
                    }
                    catch (Exception exception35)
                    {
                        result = exception35.Message.ToString();
                    }
                    context.Response.Write(JsonConvert.SerializeObject(response18));


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