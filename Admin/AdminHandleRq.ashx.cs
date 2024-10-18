using HaiDen.Admin.App_Code;
using Microsoft.JScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;


namespace HaiDen.Admin
{
    /// <summary>
    /// Summary description for AdminHandleRq
    /// </summary>
    public class AdminHandleRq : IHttpHandler
    {
        BLL bll = new BLL();
        public void ProcessRequest(HttpContext context)
        {
            var result = "";
            context.Response.ContentType = "text/json";
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var stpe = context.Request["stpe"];

            switch (stpe)
            {

                //=======================ADMIN THẠCH =============================
                case "1":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.login_ADMIN(storeSt);
                    }
                    catch (Exception ex)
                    {
                        // _err.ErrorLog(_logError, "CASE 17: " + ex.Message, ex.StackTrace);
                    }
                    break;
                //================================ADMIN===========================
                case "2":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_USER(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "3":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_ADMIN_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                //================================BANNER===================================
                case "4":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_BANNER(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "5":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_BANNER_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "6":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.DELETE_BANNER_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                //========================== THÔNG TIN ==========================
                case "7":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_THONGTIN(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "8":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_THONGTIN_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;

                //==========================  STORIES  ==========================
                case "9":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_STORIES(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "10":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_STORIES_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "11":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.DEL_STORIES_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                //==========================  NEWS  ==========================
                case "12":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_NEWS(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "13":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_NEWS_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "14":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.DEL_NEWS_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;

                //==========================  COLLECTIONS  ==========================
                case "15":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_COLLECTIONS(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "16":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_COLLECTIONS_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "17":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.DEL_COLLECTIONS_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                //==========================  FAQ CATE  ==========================
                case "18":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_FAQCATE(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "19":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_FAQCATE_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "20":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.DEL_FAQCATE_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                //==========================  FAQ  ==========================
                case "21":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_FAQ(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "22":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_FAQ_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;

                case "23":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.DEL_FAQ_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "24":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_CATE_IN_FAQ(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                //==========================  DRESS  ==========================
                case "25":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_DRESS(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "26":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_COLLECTION_IN_DRESS(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "27":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_DRESS_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "28":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.DEL_DRESS_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                //============================== DRESS PRODUCT =======================================
                case "29":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.UPDATE_DRESS_IMAGE(storeSt);
                    }
                    catch (Exception ex) { }
                    break;

                //============================== IMAGES DRESS =======================================
                case "30":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.UPDATE_DRESS_IMAGE(storeSt);
                    }
                    catch (Exception ex) { }
                    break;

                //============================== BRIDES STORIE CATE =======================================
                case "31":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_BRIDES_STORIE_CATE(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "32":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_BRIDES_STORIE_CATE_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "33":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.DEL_BRIDES_STORIE_CATE_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "34":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_CATE_IN_BRIDE_STORIE_CATE(storeSt);
                    }
                    catch (Exception ex) { }
                    break;

                //============================== ORDER PROCESS =======================================
                case "35":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_ORDER_PROCESS(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "36":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_ORDER_PROCESS_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "37":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.DEL_ORDER_PROCESS_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                //============================== USERS =======================================
                case "38":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.AD_LOAD_LIST_USERS(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "39":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_USER_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "40":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_NATION_IN_USER(storeSt);
                    }
                    catch (Exception ex) { }
                    break;

                //============================== INQUIRIES ================================
                case "41":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_INQUIRIES(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "42":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_DRESS_IN_USER(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "43":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_USER_IN_USER(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "44":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_INQUIRIES_IQ_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;

                //============================== ABOUT US ================================
                case "45":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.LOAD_LIST_ABOUT(storeSt);
                    }
                    catch (Exception ex) { }
                    break;

                case "46":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.INSERT_UPDATE_ABOUT_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;
                case "47":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        result = bll.DEL_ABOUT_US_ID(storeSt);
                    }
                    catch (Exception ex) { }
                    break;

            }
            context.Response.Write(result);
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