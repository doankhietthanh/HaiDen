using Newtonsoft.Json;
using System;
using HaiDen.Admin.App_Code;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;


namespace HaiDen.Admin.App_Code
{
    public class BLL
    {
        DTO dto = new DTO();
        DAO dao = new DAO();


        ////=========================ADMIN THẠCH =====================================================================================
        public DataTable SHOW_AD_NAME(DTO dto)
        {
            string key = "Aa@POIUYTREWQ";
            dto.AD_MAIL = DataProvider.DecryptString(dto.AD_MAIL, key);
            return dao.SHOW_AD_NAME(dto);
        }
        public string login_ADMIN(string stringjson)
        {
            string output = "";
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                dto.AD_MAIL = dtstore.Rows[0]["imail"].ToString().Trim();
                dto.AD_PASS = DataProvider.ToMD5_v2(dtstore.Rows[0]["ipass"].ToString().Trim());
                string key = "Aa@POIUYTREWQ";
                DataTable dtb = dao.LOGIN_ADMIN(dto);
                int nhotk = int.Parse(dtstore.Rows[0]["ckc"].ToString().Trim());
                int num = 0;
                if (dtb.Rows.Count > 0)
                {
                    num = int.Parse("0" + dtb.Rows[0][0]);
                    switch (num)
                    {
                        case 1: //dang nhap admin

                            if (nhotk == 1)
                            {
                                HttpCookie cookie = new HttpCookie("CookieUserName", DataProvider.EncryptString(dtstore.Rows[0]["imail"].ToString().Trim(), key));
                                cookie.Expires = DateTime.Now.AddDays(7);
                                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                            }
                            HttpCookie cookie1 = new HttpCookie("SUserName", DataProvider.EncryptString(dtstore.Rows[0]["imail"].ToString().Trim(), key));
                            System.Web.HttpContext.Current.Response.Cookies.Add(cookie1);
                            output = "1";
                            //}
                            break;
                        case 2: // mod
                            if (nhotk == 1)
                            {
                                HttpCookie cookie = new HttpCookie("CookieUserName", DataProvider.EncryptString(dtstore.Rows[0]["imail"].ToString().Trim(), key));
                                cookie.Expires = DateTime.Now.AddDays(7);
                                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                            }
                            HttpCookie cookie2 = new HttpCookie("SUserName", DataProvider.EncryptString(dtstore.Rows[0]["imail"].ToString().Trim(), key));
                            System.Web.HttpContext.Current.Response.Cookies.Add(cookie2);
                            output = "2";
                            break;
                        case 3: // dang nhap binh thuong
                            if (nhotk == 1)
                            {
                                HttpCookie cookie = new HttpCookie("CookieUserName", DataProvider.EncryptString(dtstore.Rows[0]["imail"].ToString().Trim(), key));
                                cookie.Expires = DateTime.Now.AddDays(7);
                                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                            }
                            HttpCookie cookie3 = new HttpCookie("SUserName", DataProvider.EncryptString(dtstore.Rows[0]["imail"].ToString().Trim(), key));
                            System.Web.HttpContext.Current.Response.Cookies.Add(cookie3);
                            output = "3";
                            break;
                        case 4: // khoa tk
                            output = "4";
                            break;
                        case 5: // khoa sai ten tk, mk
                            output = "5";
                            break;
                        case 6: // khoa sai ten tk, mk
                            output = "5";
                            break;
                    }
                }
            }
            return output;
        }
        ////========================= ADMINS =====================================
        public string LOAD_LIST_USER(string stringjson)
        {
            string htm = "", str_ri = "";

            DataTable dt = dao.LOAD_LIST_USER(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    stt++;

                    htm += "<tr><td>" + dr["AD_ID"] + "</td><td>" + dr["AD_IMG"] + ".ashx?width=50&height=50&mode=crop</td><td>" + dr["AD_NAME"] + "</td><td>" + dr["AD_MAIL"] +
                        "</td></tr>";
                }
            }
            return htm;
        }

        public string INSERT_UPDATE_ADMIN_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                string name = dtstore.Rows[0]["name"].ToString().Trim(),
                       mail = dtstore.Rows[0]["mail"].ToString().Trim(),
                       pass = dtstore.Rows[0]["pass"].ToString().Trim(),

                       img = dtstore.Rows[0]["iimg_APP_LIST"].ToString().Trim();

                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                //right = int.Parse(dtstore.Rows[0]["right"].ToString().Trim());

                if (pass == "*****") { pass = "-1"; }
                else { pass = DataProvider.ToMD5_v2(pass); }
                dto.AD_ID = id;
                dto.AD_MAIL = mail;
                dto.AD_PASS = pass;
                dto.AD_NAME = name;
                //dto.AD_RIGHT = right;
                dto.AD_IMG = img;

                dao.INSERT_UPDATE_ADMIN_ID(dto);
                output = "ok";
            }
            return output;
        }


        ////========================= BANNER =====================================
        public string LOAD_LIST_BANNER(string stringjson)
        {
            string htm = "", ckn = "";
            DataTable dt = dao.LOAD_LIST_BANNER(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;
                    htm += "<tr><td>" + dr["BN_ID"] + "</td><td>" + dr["BN_IMG"] + ".ashx?width=50&height=50&mode=crop</td><td>" + dr["BN_TITLE"] + "</td><td>" + dr["BN_DES"] + "</td><td>";
                }
            }

            return htm;
        }

        public string INSERT_UPDATE_BANNER_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                string title = dtstore.Rows[0]["title"].ToString().Trim(),
                       des = dtstore.Rows[0]["des"].ToString().Trim(),
                       link = dtstore.Rows[0]["link"].ToString().Trim(),
                       img = dtstore.Rows[0]["iimg_APP_LIST"].ToString().Trim();

                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());

                dto.BN_ID = id;
                dto.BN_TITLE = title;
                dto.BN_DES = des;
                dto.BN_LINK = link;
                dto.BN_IMG = img;
 
                dao.INSERT_UPDATE_BANNER_ID(dto);
                output = "ok";
            }
            return output;
        }


        public string DELETE_BANNER_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                dto.BN_ID = id;

                kq = dao.DELETE_BANNER_ID(dto, ref kq);
                if (kq == 0)
                {
                    output = "ok";
                }
                else if (kq == 1)
                {
                    output = "err";
                }
            }
            return output;
        }

        ////=========================== THÔNG TIN ==================================
        public string LOAD_LIST_THONGTIN(string stringjson)
        {
            string htm = "";
            DataTable dt = dao.LOAD_LIST_THONGTIN(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;

                    htm += "<tr><td>" + dr["IF_ID"] + "</td><td>" + dr["IF_ALIAS"] + "</td><td>" + dr["IF_NAME"] + "</td><td>" + dr["IF_DES"] + "</td></tr>";
                }
            }
            return htm;
        }

        public string INSERT_UPDATE_THONGTIN_ID(string stringjson)
        {
            string output = "";


            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {

                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                string des = dtstore.Rows[0]["des"].ToString().Trim();
                string name = dtstore.Rows[0]["name"].ToString().Trim();
              

                dto.IF_ID = id;
                dto.IF_NAME = name;
                dto.IF_DES = des;


                dao.INSERT_UPDATE_THONGTIN_ID(dto);
                output = "ok";
            }
            return output;
        }


        ////=========================== STORIES ==================================
        public string LOAD_LIST_STORIES(string stringjson)
        {
            string htm = "";
            DataTable dt = dao.LOAD_LIST_STORIES(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;

                    htm += "<tr><td>" + dr["BS_ID"] + "</td><td>" + dr["BS_NAME"] + "</td><td>" + dr["BS_IMG"] + ".ashx?width=50&height=50&mode=crop</td><td>" + dr["BS_DATE"] + "</td></tr>";
                }
            }
            return htm;
        }

        public string INSERT_UPDATE_STORIES_ID(string stringjson)
        {
            string output = "";
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                int cate = int.Parse(dtstore.Rows[0]["cate"].ToString().Trim());

                string name = dtstore.Rows[0]["name"].ToString().Trim(),
                        des = dtstore.Rows[0]["des"].ToString().Trim(),
                        detail = dtstore.Rows[0]["detail"].ToString().Trim(),
                        date = dtstore.Rows[0]["date"].ToString().Trim(),
                        img = dtstore.Rows[0]["iimg_APP_LIST"].ToString().Trim();
                DateTime dtt = DateTime.ParseExact(date, "dd/MM/yyyy", null);

                dto.BS_ID = id;
                dto.BS_NAME = name;
                dto.BS_DES = des;
                dto.BS_DETAIL = detail;
                dto.BS_DATE = dtt;
                dto.BS_IMG = img;
                dto.BSC_ID = cate;

                dao.INSERT_UPDATE_STORIES_ID(dto);
                output = "ok";
            }
            return output;
        }

        public string DEL_STORIES_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                dto.BS_ID = id;

                kq = dao.DEL_STORIES_ID(dto, ref kq);
                if (kq == 0)
                {
                    output = "ok";
                }
                else if (kq == 1)
                {
                    output = "err";
                }
            }
            return output;
        }
        public string LOAD_LIST_CATE_IN_BRIDE_STORIE_CATE(string stringjson)
        {
            string htm = "";

            DataTable dt = dao.LOAD_LIST_CATE_IN_BRIDE_STORIE_CATE(dto);


            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    htm += "<option value=\"" + dr["BSC_ID"] + "\">" + dr["BSC_DES"] + "</option>";
                }
            }

            return htm;
        }

        ////=========================== NEWS ==================================
        public string LOAD_LIST_NEWS(string stringjson)
        {
            string htm = "";
            DataTable dt = dao.LOAD_LIST_NEWS(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;

                    htm += "<tr><td>" + dr["N_ID"] + "</td><td>" + dr["N_NAME"] + "</td><td>" + dr["N_IMG"] + ".ashx?width=50&height=50&mode=crop</td><td>" + dr["N_DES"] + "</td><td>" + dr["N_DATE"] + "</td></tr>";
                }
            }
            return htm;
        }

        public string INSERT_UPDATE_NEWS_ID(string stringjson)
        {
            string output = "";
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                string name = dtstore.Rows[0]["name"].ToString().Trim(),
                        des = dtstore.Rows[0]["des"].ToString().Trim(),
                        detail = dtstore.Rows[0]["detail"].ToString().Trim(),
                        date = dtstore.Rows[0]["date"].ToString().Trim(),
                        img = dtstore.Rows[0]["iimg_APP_LIST"].ToString().Trim();
                DateTime dtt = DateTime.ParseExact(date, "dd/MM/yyyy", null);

                dto.N_ID = id;
                dto.N_NAME = name;
                dto.N_DES = des;
                dto.N_DETAIL = detail;
                dto.N_DATE = dtt;
                dto.N_IMG = img;

                dao.INSERT_UPDATE_NEWS_ID(dto);
                output = "ok";
            }
            return output;
        }

        public string DEL_NEWS_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                dto.N_ID = id;

                kq = dao.DEL_NEWS_ID(dto, ref kq);
                if (kq == 0)
                {
                    output = "ok";
                }
                else if (kq == 1)
                {
                    output = "err";
                }
            }
            return output;
        }

        ////=========================== COLLECTIONS ==================================
        public string LOAD_LIST_COLLECTIONS(string stringjson)
        {
            string htm = "";
            DataTable dt = dao.LOAD_LIST_COLLECTIONS(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;

                    htm += "<tr><td>" + dr["CO_ID"] + "</td><td>" + dr["CO_NAME"] + "</td><td>" + dr["CO_IMG"] + ".ashx?width=50&height=50&mode=crop</td><td>" + dr["CO_IMG_1"] + ".ashx?width=50&height=50&mode=crop</td><td>" + dr["CO_SEASON"] + "</td><td>" + dr["CO_DES"] + "</td></tr>";
                }
            }
            return htm;
        }
        public string INSERT_UPDATE_COLLECTIONS_ID(string stringjson)
        {
            string output = "";
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                string name = dtstore.Rows[0]["name"].ToString().Trim(),
                        des = dtstore.Rows[0]["des"].ToString().Trim(),
                        sea = dtstore.Rows[0]["sea"].ToString().Trim(),
                        img = dtstore.Rows[0]["iimg_APP_LIST"].ToString().Trim(),
                        img1 = dtstore.Rows[0]["iimg_APP_LIST_1"].ToString().Trim();

                dto.CO_ID = id;
                dto.CO_NAME = name;
                dto.CO_DES = des;
                dto.CO_SEASON = sea;
                dto.CO_IMG = img;
                dto.CO_IMG_1 = img1;

                dao.INSERT_UPDATE_COLLECTIONS_ID(dto);
                output = "ok";
            }
            return output;
        }
        public string DEL_COLLECTIONS_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                dto.CO_ID = id;

                kq = dao.DEL_COLLECTIONS_ID(dto, ref kq);
                if (kq == 0)
                {
                    output = "ok";
                }
                else if (kq == 1)
                {
                    output = "err";
                }
            }
            return output;
        }



        ////=========================== FAQ CATE ==================================
        public string LOAD_LIST_FAQCATE(string stringjson)
        {
            string htm = "";
            DataTable dt = dao.LOAD_LIST_FAQCATE(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;

                    htm += "<tr><td>" + dr["FC_ID"] + "</td><td>" + dr["FC_NAME"] + "</td><td>" + dr["FC_DES"] + "</td><td>" + dr["FC_ALIAS"] + "</td></tr>";
                }
            }
            return htm;
        }

        public string INSERT_UPDATE_FAQCATE_ID(string stringjson)
        {
            string output = "";
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                string name = dtstore.Rows[0]["name"].ToString().Trim(),
                        des = dtstore.Rows[0]["des"].ToString().Trim(),
                        alias = dtstore.Rows[0]["alias"].ToString().Trim();

                dto.FC_ID = id;
                dto.FC_NAME = name;
                dto.FC_DES = des;
                dto.FC_ALIAS = alias;

                dao.INSERT_UPDATE_FAQCATE_ID(dto);
                output = "ok";
            }
            return output;
        }

        public string DEL_FAQCATE_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                dto.FC_ID = id;

                kq = dao.DEL_FAQCATE_ID(dto, ref kq);
                if (kq == 0)
                {
                    output = "ok";
                }
                else if (kq == 1)
                {
                    output = "err";
                }
            }
            return output;
        }


        ////=========================== FAQ ==================================
        public string LOAD_LIST_FAQ(string stringjson)
        {
            string htm = "";
            DataTable dt = dao.LOAD_LIST_FAQ(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;

                    htm += "<tr><td>" + dr["F_ID"] + "</td><td>" + dr["F_QUESTION"] + "</td><td>" + dr["F_ANSWER"] + "</td><td>" + dr["FC_NAME"] + "</td></tr>";
                }
            }
            return htm;
        }

        public string DEL_FAQ_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                dto.F_ID = id;

                kq = dao.DEL_FAQ_ID(dto, ref kq);
                if (kq == 0)
                {
                    output = "ok";
                }
                else if (kq == 1)
                {
                    output = "err";
                }
            }
            return output;
        }
        public string LOAD_LIST_CATE_IN_FAQ(string stringjson)
        {
            string htm = "";

            DataTable dt = dao.LOAD_LIST_CATE_IN_FAQ(dto);


            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    htm += "<option value=\"" + dr["FC_ID"] + "\">" + dr["FC_NAME"] + "</option>";
                }
            }

            return htm;
        }
        public string INSERT_UPDATE_FAQ_ID(string stringjson)
        {
            string output = "";
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                int cate = int.Parse(dtstore.Rows[0]["cate"].ToString().Trim());

                string ques = dtstore.Rows[0]["ques"].ToString().Trim(),
                       ans = dtstore.Rows[0]["ans"].ToString().Trim();
                        

                dto.F_ID = id;
                dto.F_QUESTION = ques;
                dto.F_ANSWER = ans;
                dto.FC_ID = cate;

                dao.INSERT_UPDATE_FAQ_ID(dto);
                output = "ok";
            }
            return output;
        }

        ////=========================== DRESS ==================================
        public string LOAD_LIST_DRESS(string stringjson)
        {
            string htm = "";
            DataTable dt = dao.LOAD_LIST_DRESS(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;
                    htm += "<tr><td>" + dr["WD_ID"] + "</td><td>" + dr["WD_NAME"] + "</td><td>" + dr["WD_DES"] + "</td><td>" + dr["WD_PRICE"] + "</td><td>" + dr["CO_NAME"] + "</td></tr>";
                }
            }
            return htm;
        }
        public string LOAD_LIST_COLLECTION_IN_DRESS(string stringjson)
        {
            string htm = "";

            DataTable dt = dao.LOAD_LIST_COLLECTION_IN_DRESS(dto);


            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    htm += "<option value=\"" + dr["CO_ID"] + "\">" + dr["CO_NAME"] + "</option>";
                }
            }

            return htm;
        }
        public string INSERT_UPDATE_DRESS_ID(string stringjson)
        {
            string output = "";
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                int cate = int.Parse(dtstore.Rows[0]["cate"].ToString().Trim());

                string price = dtstore.Rows[0]["price"].ToString().Trim();

                string name = dtstore.Rows[0]["name"].ToString().Trim(),
                       des = dtstore.Rows[0]["des"].ToString().Trim();


                dto.WD_ID = id;
                dto.WD_NAME = name;
                dto.WD_DES = des;
                dto.WD_PRICE = price;
                dto.CO_ID = cate;

                dao.INSERT_UPDATE_DRESS_ID(dto);
                output = "ok";
            }
            return output;
        }

        public string DEL_DRESS_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                dto.WD_ID = id;

                kq = dao.DEL_DRESS_ID(dto, ref kq);
                if (kq == 0)
                {
                    output = "ok";
                }
                else if (kq == 1)
                {
                    output = "err";
                }
            }
            return output;
        }

        ////================================ DRESS PRODUCT ================================================

        public string UPDATE_DRESS_IMAGE(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {

                int idphoto = int.Parse(dtstore.Rows[0]["idphoto"].ToString().Trim());
                string title = dtstore.Rows[0]["title"].ToString().Trim();

                dto.WDI_NAME = "-1";
                dto.WD_ID = -1;
                dto.WDI_ID = idphoto;
                dto.WDI_FILE = title;

                dao.INSERT_DRESS_IMG(dto);
                output = "ok";
            }
            return output;
        }

        //============================== BRIDES STORIE CATE =======================================
        public string LOAD_LIST_BRIDES_STORIE_CATE(string stringjson)
        {
            string htm = "";
            DataTable dt = dao.LOAD_LIST_BRIDES_STORIE_CATE(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;
                    htm += "<tr><td>" + dr["BSC_ID"] + "</td><td>" + dr["BSC_IMG"] + ".ashx?width=50&height=50&mode=crop</td><td>" + dr["BSC_DES"] + "</td></tr>";
                }
            }
            return htm;
        }
        public string INSERT_UPDATE_BRIDES_STORIE_CATE_ID(string stringjson)
        {
            string output = "";
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                string 
                        des = dtstore.Rows[0]["des"].ToString().Trim(),
             
                        img = dtstore.Rows[0]["iimg_APP_LIST"].ToString().Trim();

                dto.BSC_ID = id;

                dto.BSC_DES = des;

                dto.BSC_IMG = img;

                dao.INSERT_UPDATE_BRIDES_STORIE_CATE_ID(dto);
                output = "ok";
            }
            return output;
        }
        public string DEL_BRIDES_STORIE_CATE_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                dto.BSC_ID = id;

                kq = dao.DEL_BRIDES_STORIE_CATE_ID(dto, ref kq);
                if (kq == 0)
                {
                    output = "ok";
                }
                else if (kq == 1)
                {
                    output = "err";
                }
            }
            return output;
        }

        //============================== ORDER PROCESS =======================================
        public string LOAD_LIST_ORDER_PROCESS(string stringjson)
        {
            string htm = "";
            DataTable dt = dao.LOAD_LIST_ORDER_PROCESS(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;
                    htm += "<tr><td>" + dr["OP_ID"] + "</td><td>" + dr["OP_IMG"] + ".ashx?width=50&height=50&mode=crop</td><td>" + dr["OP_DES"] + "</td></tr>";
                }
            }
            return htm;
        }
        public string INSERT_UPDATE_ORDER_PROCESS_ID(string stringjson)
        {
            string output = "";
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                string  des = dtstore.Rows[0]["des"].ToString().Trim(),
                        detail = dtstore.Rows[0]["detail"].ToString().Trim(),
                        img = dtstore.Rows[0]["iimg_APP_LIST"].ToString().Trim();

                dto.OP_ID = id;
                dto.OP_DES = des;
                dto.OP_DETAIL = detail;
                dto.OP_IMG = img;

                dao.INSERT_UPDATE_ORDER_PROCESS_ID(dto);
                output = "ok";
            }
            return output;
        }
        public string DEL_ORDER_PROCESS_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                dto.OP_ID = id;

                kq = dao.DEL_ORDER_PROCESS_ID(dto, ref kq);
                if (kq == 0)
                {
                    output = "ok";
                }
                else if (kq == 1)
                {
                    output = "err";
                }
            }
            return output;
        }


        //=========================== USERS ==================

        public string AD_LOAD_LIST_USERS(string stringjson)
        {
            string htm = "", str_ri = "", ckn = "";

            DataTable dt = dao.AD_LOAD_LIST_USERS(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    stt++;
                    int n = int.Parse("" + dr["U_STATUS"]);

                    switch (n)
                    {
                        case 1:
                            ckn = "<span class=\"label-success label label-default\">Đã kích hoạt</span>";
                            break;
                        case 0:
                            ckn = "<span class=\" label label-default\">Chưa kích hoạt</span>";
                            break;
                        case 2:
                            ckn = "<span class=\" label label-default\">Banned</span>";
                            break;
                        default:
                            ckn = "err";
                            break;
                    }

                    htm += "<tr><td>" + dr["U_ID"] + "</td><td>" + dr["U_NAME"] + "</td><td>" + dr["U_AVATAR"] + ".ashx?width=50&height=50&mode=crop</td><td>" + dr["U_MAIL"] + "</td><td>" + dr["U_PHONE"] + "</td><td>" + ckn + "</td></tr>";
                }
            }
            return htm;
        }

        public string INSERT_UPDATE_USER_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                string name = dtstore.Rows[0]["name"].ToString().Trim(),
                       mail = dtstore.Rows[0]["mail"].ToString().Trim(),
                       pass = dtstore.Rows[0]["pass"].ToString().Trim(),
                       phone = dtstore.Rows[0]["phone"].ToString().Trim(),
                       img = dtstore.Rows[0]["iimg_APP_LIST"].ToString().Trim();

                float buget = float.Parse(dtstore.Rows[0]["buget"].ToString().Trim());

                string date = dtstore.Rows[0]["date"].ToString().Trim();
                DateTime dtt = DateTime.ParseExact(date, "dd/MM/yyyy", null);

                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                int nation = int.Parse(dtstore.Rows[0]["nation"].ToString().Trim());
                int status = int.Parse(dtstore.Rows[0]["status"].ToString().Trim());

                if (pass == "*****") { pass = "-1"; }
                else { pass = DataProvider.ToMD5_v2(pass); }

                dto.U_ID = id;
                dto.U_NAME = name;
                dto.U_MAIL = mail;
                dto.U_PASS = pass;
                dto.U_PHONE = phone;
                dto.NA_ID = nation;
                dto.U_BUGET = buget;
                dto.U_WEDDING_DATE = dtt;
                dto.U_AVATAR = img;
                dto.U_STATUS = status;

                dao.INSERT_UPDATE_USER_ID(dto);
                output = "ok";
            }
            return output;
        }

        public string LOAD_LIST_NATION_IN_USER(string stringjson)
        {
            string htm = "";

            DataTable dt = dao.LOAD_LIST_NATION_IN_USER(dto);


            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    htm += "<option value=\"" + dr["NA_ID"] + "\">" + dr["NA_NAME"] + "</option>";
                }
            }

            return htm;
        }

        //============================== INQUIRIES ================================

        public string LOAD_LIST_INQUIRIES(string stringjson)
        {
            string htm = "", str_ri = "", ckn = ""; 

            DataTable dt = dao.LOAD_LIST_INQUIRIES(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    stt++;
                    int n = int.Parse("" + dr["IQ_PROGRESS"]);

                    switch (n)
                    {
                        case 1:
                            ckn = "<span class=\" label label-default\">Place the order </span>";
                            break;

                        case 2:
                            ckn = "<span class=\"label-success label label-default\">Deposit</span>";
                            break;
                     
                        case 3:
                            ckn = "<span class=\" label label-default\">Production</span>";
                            break;

                        case 4:
                            ckn = "<span class=\" label label-default\">Payment Completed</span>";
                            break;

                        case 5:
                            ckn = "<span class=\" label label-default\">Shipping </span>";
                            break;

                        default:
                            ckn = "err";
                            break;
                    }
                    htm += "<tr><td>" + dr["IQ_ID"] + "</td><td>" + dr["IQ_NAME"] + "</td><td>" + dr["IQ_MAIL"] + "</td><td>" + dr["IQ_PHONE"] + "</td><td>" + dr["WD_NAME"] + "</td><td>" + ckn + "</td></tr>";
                }
            }
            return htm;
        }


        public string LOAD_LIST_DRESS_IN_USER(string stringjson)
        {
            string htm = "";

            DataTable dt = dao.LOAD_LIST_DRESS_IN_USER(dto);


            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    htm += "<option value=\"" + dr["WD_ID"] + "\">" + dr["WD_NAME"] + "</option>";
                }
            }

            return htm;
        }
        public string LOAD_LIST_USER_IN_USER(string stringjson)
        {
            string htm = "";

            DataTable dt = dao.LOAD_LIST_USER_IN_USER(dto);

            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    htm += "<option value=\"" + dr["U_ID"] + "\">" + dr["U_NAME"] + "</option>";
                }
            }
            return htm;
        }

        public string INSERT_INQUIRIES_IQ_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {

                string name = dtstore.Rows[0]["name"].ToString().Trim(),
                       mail = dtstore.Rows[0]["mail"].ToString().Trim(),
                       phone = dtstore.Rows[0]["phone"].ToString().Trim(),
                       mes = dtstore.Rows[0]["mes"].ToString().Trim();

                float buget = float.Parse(dtstore.Rows[0]["buget"].ToString().Trim());
                float amout = float.Parse(dtstore.Rows[0]["amout"].ToString().Trim());
                float toward = float.Parse(dtstore.Rows[0]["toward"].ToString().Trim());
                float deposit = float.Parse(dtstore.Rows[0]["deposit"].ToString().Trim());

                string order_date = dtstore.Rows[0]["order_date"].ToString().Trim();
                DateTime odate = DateTime.ParseExact(order_date, "dd/MM/yyyy", null);

                string due_date = dtstore.Rows[0]["due_date"].ToString().Trim();
                DateTime ddate = DateTime.ParseExact(due_date, "dd/MM/yyyy", null);

                string wed_date = dtstore.Rows[0]["wed_date"].ToString().Trim();
                DateTime wdate = DateTime.ParseExact(wed_date, "dd/MM/yyyy", null);

                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                int nation = int.Parse(dtstore.Rows[0]["nation"].ToString().Trim());
                int status = int.Parse(dtstore.Rows[0]["status"].ToString().Trim());
                int process = int.Parse(dtstore.Rows[0]["process"].ToString().Trim());
                int user = int.Parse(dtstore.Rows[0]["user"].ToString().Trim());
                int dress = int.Parse(dtstore.Rows[0]["dress"].ToString().Trim());

                dto.IQ_ID = id;
                dto.IQ_DATE = odate;
                dto.WD_ID = dress;
                dto.IQ_MESSENGER = mes;
                dto.U_ID = user;
                dto.IQ_TOTAL_AMOUT = amout;
                dto.IQ_TOWARD = toward;
                dto.IQ_DEPOSIT = deposit;
                dto.IQ_DUE_DATE = ddate;
                dto.IQ_NAME = name;
                dto.IQ_MAIL = mail;
                dto.IQ_PHONE = phone;
                dto.NA_ID = nation;
                dto.IQ_BUGET = buget;
                dto.IQ_WEDDING_DATE = wdate;
                dto.IQ_STATUS = status;
                dto.IQ_PROGRESS = process;

                dao.INSERT_INQUIRIES_IQ_ID(dto);
                output = "ok";
            }
            return output;
        }

        //============================== ABOUT US =======================================
        public string LOAD_LIST_ABOUT(string stringjson)
        {
            string htm = "";
            DataTable dt = dao.LOAD_LIST_ABOUT(dto);
            if (dt.Rows.Count > 0)
            {
                int stt = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    stt++;
                    htm += "<tr><td>" + dr["AU_ID"] + "</td><td>" + dr["AU_NAME"] + "</td><td>" + dr["AU_TITLE"] + "</td><td>" + dr["AU_IMG"] + ".ashx?width=50&height=50&mode=crop</td></tr>";
                }
            }
            return htm;
        }

        public string INSERT_UPDATE_ABOUT_ID(string stringjson)
        {
            string output = "";
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                string  name = dtstore.Rows[0]["name"].ToString().Trim(),
                        title = dtstore.Rows[0]["title"].ToString().Trim(),
                        detail = dtstore.Rows[0]["detail"].ToString().Trim(),
                        img = dtstore.Rows[0]["iimg_APP_LIST"].ToString().Trim();


                dto.AU_ID = id;
                dto.AU_NAME = name;
                dto.AU_TITLE = title;
                dto.AU_DETAIL = detail;
                dto.AU_IMG = img;

                dao.INSERT_UPDATE_ABOUT_ID(dto);
                output = "ok";
            }
            return output;
        }
        public string DEL_ABOUT_US_ID(string stringjson)
        {
            string output = "", sotrang = ""; int kq = -1;
            var dtstore = stringjson != "" ? JsonConvert.DeserializeObject<DataTable>(stringjson) : null;
            if (dtstore != null && dtstore.Rows.Count > 0)
            {
                int id = int.Parse(dtstore.Rows[0]["id"].ToString().Trim());
                dto.AU_ID = id;

                kq = dao.DEL_ABOUT_US_ID(dto, ref kq);
                if (kq == 0)
                {
                    output = "ok";
                }
                else if (kq == 1)
                {
                    output = "err";
                }
            }
            return output;
        }


    }
}