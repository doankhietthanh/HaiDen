using HaiDen.Admin.App_Code;
using Microsoft.JScript;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HaiDen.Admin
{
    /// <summary>
    /// Summary description for AdminHandler_list
    /// </summary>
    public class AdminHandler_list : IHttpHandler
    {
        BLL bll = new BLL();
        DTO dto = new DTO();
        DAO dao = new DAO();
        public void ProcessRequest(HttpContext context)
        {
            var result = "";
            List<quiz> blg = new List<quiz>();
            System.Collections.Generic.List<quiz> objList = new System.Collections.Generic.List<quiz>();

            List<app_ring> List_app = new List<app_ring>();
            System.Collections.Generic.List<app_ring> objList_app = new System.Collections.Generic.List<app_ring>();

            context.Response.ContentType = "text/json";
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var stpe = context.Request["stpe"];
            switch (stpe)
            {

                /////================================ THACH DEP TRAI=================================
                case "1":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.AD_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_ADMIN_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["ad_id"].ToString();
                                    bl.mail = dt.Rows[0]["ad_mail"].ToString();
                                    bl.pass = "*****"; //dt.Rows[0]["ad_pass"].ToString();
                                    bl.name = dt.Rows[0]["ad_name"].ToString();
                                    bl.img = dt.Rows[0]["ad_img"].ToString();
                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;
                default:
                break;

                //========================================= BANNER ===========================
                case "2":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.BN_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_BANNER_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["bn_id"].ToString();
                                    bl.title = dt.Rows[0]["bn_title"].ToString();
                                    bl.des = dt.Rows[0]["bn_des"].ToString();
                                    bl.link = dt.Rows[0]["bn_link"].ToString();
                                    bl.img = dt.Rows[0]["bn_img"].ToString();
                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;

                //========================== THÔNG TIN  =============================
                case "3":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.IF_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_THONGTIN_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["if_id"].ToString();
                                    bl.name = dt.Rows[0]["if_name"].ToString();
                                    bl.des = dt.Rows[0]["if_des"].ToString();

                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;
                //========================= STORIES ================
                case "4":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.BS_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_STORIES_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["bs_id"].ToString();
                                    bl.name = dt.Rows[0]["bs_name"].ToString();
                                    bl.des = dt.Rows[0]["bs_des"].ToString();
                                    bl.detail = dt.Rows[0]["bs_detail"].ToString();
                                    bl.date = String.Format("{0:dd/MM/yyyy}", dt.Rows[0]["bs_date"]);
                                    bl.img = dt.Rows[0]["bs_img"].ToString();
                                    bl.cate = dt.Rows[0]["bsc_id"].ToString();

                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;
                //========================= NEWS ================
                case "5":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.N_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_NEWS_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["n_id"].ToString();
                                    bl.name = dt.Rows[0]["n_name"].ToString();
                                    bl.des = dt.Rows[0]["n_des"].ToString();
                                    bl.detail = dt.Rows[0]["n_detail"].ToString();
                                    bl.date = String.Format("{0:dd/MM/yyyy}", dt.Rows[0]["n_date"]);
                                    bl.img = dt.Rows[0]["n_img"].ToString();

                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;

                //========================= COLLECTIONS ================
                case "6":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.CO_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_COLLECTIONS_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["co_id"].ToString();
                                    bl.name = dt.Rows[0]["co_name"].ToString();
                                    bl.des = dt.Rows[0]["co_des"].ToString();
                                    bl.sea = dt.Rows[0]["co_season"].ToString();
                                    bl.img = dt.Rows[0]["co_img"].ToString();
                                    bl.img1 = dt.Rows[0]["co_img_1"].ToString();

                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;

                //========================= FAQ CATE ================
                case "7":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.FC_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_FAQCATE_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["fc_id"].ToString();
                                    bl.name = dt.Rows[0]["fc_name"].ToString();
                                    bl.des = dt.Rows[0]["fc_des"].ToString();
                                    bl.alias = dt.Rows[0]["fc_alias"].ToString();

                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;

                //========================= FAQ  ================
                case "8":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.F_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_FAQ_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["f_id"].ToString();
                                    bl.ques = dt.Rows[0]["f_question"].ToString();
                                    bl.ans = dt.Rows[0]["f_answer"].ToString();
                                    bl.cate = dt.Rows[0]["fc_id"].ToString();

                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;

                //========================= DRESS  ================
                case "9":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.WD_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_DRESS_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["wd_id"].ToString();
                                    bl.name = dt.Rows[0]["wd_name"].ToString();
                                    bl.des = dt.Rows[0]["wd_des"].ToString();
                                    bl.price = dt.Rows[0]["wd_price"].ToString();
                                    bl.cate = dt.Rows[0]["co_id"].ToString();

                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;
                //============================== BRIDES STORIE CATE =======================================
                case "10":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.BSC_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_BRIDES_STORIE_CATE_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["bsc_id"].ToString();
                                    bl.des = dt.Rows[0]["bsc_des"].ToString();                                 
                                    bl.img = dt.Rows[0]["bsc_img"].ToString();

                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;

                //============================== ORDER PROCESS =======================================
                case "11":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.OP_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_ORDER_PROCESS_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["OP_ID"].ToString();
                                    bl.des = dt.Rows[0]["OP_DES"].ToString();
                                    bl.img = dt.Rows[0]["OP_IMG"].ToString();
                                    bl.detail = dt.Rows[0]["OP_DETAIL"].ToString();


                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;
                /////================================ USERS =================================
                case "12":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.U_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_USER_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["u_id"].ToString();
                                    bl.name = dt.Rows[0]["u_name"].ToString();
                                    bl.mail = dt.Rows[0]["u_mail"].ToString();
                                    bl.pass = "*****";
                                    bl.phone = dt.Rows[0]["u_phone"].ToString();
                                    bl.nation = dt.Rows[0]["na_id"].ToString();
                                    bl.buget = dt.Rows[0]["u_buget"].ToString();
                                    bl.date = String.Format("{0:dd/MM/yyyy}", dt.Rows[0]["u_wedding_date"]);
                                    bl.img = dt.Rows[0]["u_avatar"].ToString();                                
                                    bl.status = dt.Rows[0]["u_status"].ToString();
                                    
                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;

                /////================================ INQUIRIES =================================
                case "13":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.IQ_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_INQUIRIES_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["IQ_ID"].ToString();
                                    bl.order_date = String.Format("{0:dd/MM/yyyy}", dt.Rows[0]["IQ_DATE"]);
                                    bl.dress = dt.Rows[0]["WD_ID"].ToString();
                                    bl.mes = dt.Rows[0]["IQ_MESSENGER"].ToString();
                                    bl.user = dt.Rows[0]["U_ID"].ToString();
                                    bl.amout = dt.Rows[0]["IQ_TOTAL_AMOUT"].ToString();
                                    bl.toward = dt.Rows[0]["IQ_TOWARD"].ToString();
                                    bl.deposit = dt.Rows[0]["IQ_DEPOSIT"].ToString();
                                    bl.due_date = String.Format("{0:dd/MM/yyyy}", dt.Rows[0]["IQ_DUE_DATE"]);

                                    bl.name = dt.Rows[0]["IQ_NAME"].ToString();
                                    bl.mail = dt.Rows[0]["IQ_MAIL"].ToString();
                                    bl.phone = dt.Rows[0]["IQ_PHONE"].ToString();
                                    bl.nation = dt.Rows[0]["NA_ID"].ToString();
                                    bl.buget = dt.Rows[0]["IQ_BUGET"].ToString();
                                    bl.wed_date = String.Format("{0:dd/MM/yyyy}", dt.Rows[0]["IQ_WEDDING_DATE"]);
                                    bl.status = dt.Rows[0]["IQ_STATUS"].ToString();
                                    bl.process = dt.Rows[0]["IQ_PROGRESS"].ToString();
                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;

                //========================= ABOUT US ================
                case "14":
                    try
                    {
                        var storeSt = GlobalObject.unescape(context.Request["shoplistSt"]) ?? "";
                        string output = "", htm = "", ckc = ""; var pid = 0;
                        var dtstore = storeSt != "" ? JsonConvert.DeserializeObject<DataTable>(storeSt) : null;
                        app_ring bl = new app_ring();
                        try
                        {
                            if (dtstore != null && dtstore.Rows.Count > 0)
                            {
                                dto.AU_ID = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                                DataTable dt = dao.SHOW_ABOUT_ID(dto);
                                if (dt.Rows.Count > 0)
                                {
                                    bl.id = dt.Rows[0]["au_id"].ToString();
                                    bl.name = dt.Rows[0]["au_name"].ToString();
                                    bl.title = dt.Rows[0]["au_title"].ToString();
                                    bl.detail = dt.Rows[0]["au_detail"].ToString();
                                    bl.img = dt.Rows[0]["au_img"].ToString();

                                }
                                List_app.Add(bl);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    catch (System.Exception) { }
                    break;

            }
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(blg);
            string aJSON = oSerializer.Serialize(List_app);
            string refs = "";
            if (stpe == "1" || stpe == "2" || stpe == "3" || stpe == "4" || stpe == "5" || stpe == "6" || stpe == "7" || stpe == "8" || stpe == "9" || stpe == "10" || stpe == "11" || stpe == "12" || stpe == "13" || stpe == "14" || stpe == "15" ||
                stpe == "16" || stpe == "17" || stpe == "18" || stpe == "19" || stpe == "20" || stpe == "100")
            {
                refs = aJSON;
            }
            else { refs = sJSON; }
            context.Response.Write(refs);
            //context.Response.Write(blg.ToArray());
            context.Response.StatusCode = 200;
            context.Response.End();
        }
        public class quiz
        {
            public string pid { get; set; }

        }
        public class app_ring
        {

            public string wed_date { get; set; }
            public string user { get; set; }
            public string order_date { get; set; }
            public string due_date { get; set; }
            public string dress { get; set; }

            public string amout { get; set; }
            public string toward { get; set; }

            public string deposit { get; set; }
            public string process { get; set; }
            public string mes { get; set; }

            public string nation { get; set; }
            public string buget { get; set; }
            public string price { get; set; }
            public string ques { get; set; }
            public string ans { get; set; }
            

            public string sea { get; set; }
            public string img1 { get; set; }


           
            public string avt { get; set; }
            public string active { get; set; }
            public string total { get; set; }
            public string id { get; set; }
            public string cmt_count { get; set; }
            public string html { get; set; }
            public string alias { get; set; }
            public string link { get; set; }
            public string technical { get; set; }

            public string htm { get; set; }

            public string type { get; set; }

            public string position { get; set; }

            public string pass { get; set; }
            public string cate { get; set; }

            public string id1 { get; set; }
            public string aid { get; set; }
            public string name { get; set; }
            public string fname { get; set; }
            public string right { get; set; }
            public string img { get; set; }
            public string des { get; set; }
            public string detail { get; set; }
            public string year { get; set; }
            public string age { get; set; }
            public string born { get; set; }
            public string down { get; set; }
            public string file { get; set; }
            public string date { get; set; }
            public string hot { get; set; }
            public string longs { get; set; }
            public string hard { get; set; }
            public string mail { get; set; }
            public string status { get; set; }

            public string title { get; set; }
            public string act { get; set; }
            public string phone { get; set; }


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