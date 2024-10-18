using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace HaiDen.Admin.App_Code
{
    public class DAO : DataProvider
    {

        private static readonly string StrCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private readonly SqlConnection _sqlcon = new SqlConnection(StrCon);
        private SqlCommand _sqlCom;
        private SqlDataAdapter _sqlAdap;
        private DataSet _ds;

        //=======================ADMIN THẠCH =============================
        //------------------------------QUẢN TRỊ------------------------
        public DataTable SHOW_AD_NAME(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@AD_MAIL", SqlDbType.NVarChar);
            param1.Value = dto.AD_MAIL;
            return load_data_param("AD_SHOW_AD_NAME", param1);
        }

        public DataTable LOGIN_ADMIN(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@AD_MAIL", SqlDbType.NVarChar);
            param1.Value = dto.AD_MAIL;
            SqlParameter param2 = new SqlParameter("@AD_PASS", SqlDbType.NVarChar);
            param2.Value = dto.AD_PASS;
            return load_data_param("[AD_LOGIN_ADMIN]", param1, param2);
        }
        public DataTable SHOW_ADMIN_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@AD_ID", SqlDbType.Int);
            param1.Value = dto.AD_ID;
            return load_data_param("AD_SHOW_ADMIN_ID", param1);
        }
        public DataTable LOAD_LIST_USER(DTO dto)
        {
            return Load_data("AD_LOAD_LIST_ADMIN");
        }
        public void INSERT_UPDATE_ADMIN_ID(DTO dto)
        {
            SqlParameter param2 = new SqlParameter("@AD_ID", SqlDbType.Int);
            param2.Value = dto.AD_ID;

            SqlParameter param1 = new SqlParameter("@AD_MAIL", SqlDbType.NVarChar);
            param1.Value = dto.AD_MAIL;

            SqlParameter param3 = new SqlParameter("@AD_PASS", SqlDbType.NVarChar);
            param3.Value = dto.AD_PASS;

            SqlParameter param5 = new SqlParameter("@AD_NAME", SqlDbType.NVarChar);
            param5.Value = dto.AD_NAME;

            SqlParameter param7 = new SqlParameter("@AD_IMG", SqlDbType.NVarChar);
            param7.Value = dto.AD_IMG;

            exeproc("AD_INSERT_UPDATE_ADMIN_ID", param2, param1, param3, param5, param7);
        }

        ////======================= BANNER =============================
        public DataTable LOAD_LIST_BANNER(DTO dto)
        {
            return Load_data("AD_LOAD_LIST_BANNER");
        }
        public DataTable SHOW_BANNER_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@BN_ID", SqlDbType.Int);
            param1.Value = dto.BN_ID;
            return load_data_param("AD_SHOW_BANNER_ID", param1);
        }
        public void INSERT_UPDATE_BANNER_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@BN_ID", SqlDbType.Int);
            param1.Value = dto.BN_ID;

            SqlParameter param2 = new SqlParameter("@BN_TITLE", SqlDbType.NVarChar);
            param2.Value = dto.BN_TITLE;

            SqlParameter param3 = new SqlParameter("@BN_DES", SqlDbType.NVarChar);
            param3.Value = dto.BN_DES;

            SqlParameter param4 = new SqlParameter("@BN_LINK", SqlDbType.NVarChar);
            param4.Value = dto.BN_LINK;

            SqlParameter param5 = new SqlParameter("@BN_IMG", SqlDbType.NVarChar);
            param5.Value = dto.BN_IMG;



            exeproc("AD_INSERT_UPDATE_BANNER_ID", param1, param2, param3, param4, param5);
        }
        public int DELETE_BANNER_ID(DTO dto, ref int kq)
        {
            try
            {
                if (_sqlcon.State == ConnectionState.Closed) _sqlcon.Open();
                _sqlCom = new SqlCommand
                {
                    CommandText = "AD_DELETE_BANNER_ID",
                    Connection = _sqlcon,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                _sqlCom.Parameters.AddWithValue("@BN_ID", dto.BN_ID);

                _sqlCom.Parameters.Add("@OUT", SqlDbType.Int).Value = 0;
                _sqlCom.Parameters["@OUT"].Direction = ParameterDirection.Output;
                _sqlCom.ExecuteNonQuery();

                kq = _sqlCom.Parameters["@OUT"].Value.ToString() != ""
                    ? int.Parse(_sqlCom.Parameters["@OUT"].Value.ToString())
                    : 0;
                _sqlcon.Close();
            }
            catch (Exception ex)
            {

            }
            return kq;
        }

        ////========================================== THÔNG TIN ================================
        public DataTable LOAD_LIST_THONGTIN(DTO dto)
        {
            return Load_data("AD_LOAD_LIST_THONGTIN");
        }
        public void INSERT_UPDATE_THONGTIN_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@IF_ID", SqlDbType.Int);
            param1.Value = dto.IF_ID;

            SqlParameter param2 = new SqlParameter("@IF_NAME", SqlDbType.NVarChar);
            param2.Value = dto.IF_NAME;

            SqlParameter param3 = new SqlParameter("@IF_DES", SqlDbType.NVarChar);
            param3.Value = dto.IF_DES;


            exeproc("AD_INSERT_UPDATE_THONGTIN_ID", param1, param2, param3);
        }
        public DataTable SHOW_THONGTIN_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@IF_ID", SqlDbType.Int);
            param1.Value = dto.IF_ID;
            return load_data_param("AD_SHOW_THONGTIN_ID", param1);
        }

        ////============================== STORIES ============================================

        public DataTable LOAD_LIST_STORIES(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_STORIES");
        }
        public void INSERT_UPDATE_STORIES_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@BS_ID", SqlDbType.Int);
            param1.Value = dto.BS_ID;

            SqlParameter param2 = new SqlParameter("@BS_NAME", SqlDbType.NVarChar);
            param2.Value = dto.BS_NAME;

            SqlParameter param3 = new SqlParameter("@BS_DES", SqlDbType.NVarChar);
            param3.Value = dto.BS_DES;

            SqlParameter param4 = new SqlParameter("@BS_DETAIL", SqlDbType.NVarChar);
            param4.Value = dto.BS_DETAIL;

            SqlParameter param8 = new SqlParameter("@BS_IMG", SqlDbType.NVarChar);
            param8.Value = dto.BS_IMG;

            SqlParameter param5 = new SqlParameter("@BS_DATE", SqlDbType.Date);
            param5.Value = dto.BS_DATE;

            SqlParameter param6 = new SqlParameter("@BSC_ID", SqlDbType.Int);
            param6.Value = dto.BSC_ID;

            exeproc("AD_INSERT_UPDATE_STORIES_ID", param1, param2, param3, param4, param8, param5, param6);

        }
        public DataTable SHOW_STORIES_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@BS_ID", SqlDbType.Int);
            param1.Value = dto.BS_ID;
            return load_data_param("AD_SHOW_STORIES_ID", param1);
        }
        public int DEL_STORIES_ID(DTO dto, ref int kq)
        {
            try
            {
                if (_sqlcon.State == ConnectionState.Closed) _sqlcon.Open();
                _sqlCom = new SqlCommand
                {
                    CommandText = "AD_DEL_STORIES_ID",
                    Connection = _sqlcon,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                _sqlCom.Parameters.AddWithValue("@BS_ID", dto.BS_ID);

                _sqlCom.Parameters.Add("@OUT", SqlDbType.Int).Value = 0;
                _sqlCom.Parameters["@OUT"].Direction = ParameterDirection.Output;
                _sqlCom.ExecuteNonQuery();

                kq = _sqlCom.Parameters["@OUT"].Value.ToString() != ""
                    ? int.Parse(_sqlCom.Parameters["@OUT"].Value.ToString())
                    : 0;
                _sqlcon.Close();
            }
            catch (Exception ex)
            {

            }
            return kq;
        }
        public DataTable LOAD_LIST_CATE_IN_BRIDE_STORIE_CATE(DTO dto)
        {
            return Load_data("AD_LOAD_LIST_CATE_IN_BRIDE_STORIE_CATE");
        }

        ////============================== NEWS ============================================

        public DataTable LOAD_LIST_NEWS(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_NEWS");
        }
        public void INSERT_UPDATE_NEWS_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@N_ID", SqlDbType.Int);
            param1.Value = dto.N_ID;

            SqlParameter param2 = new SqlParameter("@N_NAME", SqlDbType.NVarChar);
            param2.Value = dto.N_NAME;

            SqlParameter param3 = new SqlParameter("@N_DES", SqlDbType.NVarChar);
            param3.Value = dto.N_DES;

            SqlParameter param4 = new SqlParameter("@N_DETAIL", SqlDbType.NVarChar);
            param4.Value = dto.N_DETAIL;

            SqlParameter param8 = new SqlParameter("@N_IMG", SqlDbType.NVarChar);
            param8.Value = dto.N_IMG;

            SqlParameter param5 = new SqlParameter("@N_DATE", SqlDbType.Date);
            param5.Value = dto.N_DATE;

            exeproc("AD_INSERT_UPDATE_NEWS_ID", param1, param2, param3, param4, param8, param5);

        }
        public DataTable SHOW_NEWS_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@N_ID", SqlDbType.Int);
            param1.Value = dto.N_ID;
            return load_data_param("AD_SHOW_NEWS_ID", param1);
        }
        public int DEL_NEWS_ID(DTO dto, ref int kq)
        {
            try
            {
                if (_sqlcon.State == ConnectionState.Closed) _sqlcon.Open();
                _sqlCom = new SqlCommand
                {
                    CommandText = "AD_DEL_NEWS_ID",
                    Connection = _sqlcon,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                _sqlCom.Parameters.AddWithValue("@N_ID", dto.N_ID);

                _sqlCom.Parameters.Add("@OUT", SqlDbType.Int).Value = 0;
                _sqlCom.Parameters["@OUT"].Direction = ParameterDirection.Output;
                _sqlCom.ExecuteNonQuery();

                kq = _sqlCom.Parameters["@OUT"].Value.ToString() != ""
                    ? int.Parse(_sqlCom.Parameters["@OUT"].Value.ToString())
                    : 0;
                _sqlcon.Close();
            }
            catch (Exception ex)
            {

            }
            return kq;
        }
        ////============================== COLLECTIONS ============================================

        public DataTable LOAD_LIST_COLLECTIONS(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_COLLECTIONS");
        }
        public int DEL_COLLECTIONS_ID(DTO dto, ref int kq)
        {
            try
            {
                if (_sqlcon.State == ConnectionState.Closed) _sqlcon.Open();
                _sqlCom = new SqlCommand
                {
                    CommandText = "AD_DEL_COLLECTIONS_ID",
                    Connection = _sqlcon,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                _sqlCom.Parameters.AddWithValue("@CO_ID", dto.CO_ID);

                _sqlCom.Parameters.Add("@OUT", SqlDbType.Int).Value = 0;
                _sqlCom.Parameters["@OUT"].Direction = ParameterDirection.Output;
                _sqlCom.ExecuteNonQuery();

                kq = _sqlCom.Parameters["@OUT"].Value.ToString() != ""
                    ? int.Parse(_sqlCom.Parameters["@OUT"].Value.ToString())
                    : 0;
                _sqlcon.Close();
            }
            catch (Exception ex)
            {

            }
            return kq;
        }

        public void INSERT_UPDATE_COLLECTIONS_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@CO_ID", SqlDbType.Int);
            param1.Value = dto.CO_ID;

            SqlParameter param2 = new SqlParameter("@CO_NAME", SqlDbType.NVarChar);
            param2.Value = dto.CO_NAME;

            SqlParameter param6 = new SqlParameter("@CO_DES", SqlDbType.NVarChar);
            param6.Value = dto.CO_DES;

            SqlParameter param3 = new SqlParameter("@CO_SEASON", SqlDbType.NVarChar);
            param3.Value = dto.CO_SEASON;

            SqlParameter param4 = new SqlParameter("@CO_IMG", SqlDbType.NVarChar);
            param4.Value = dto.CO_IMG;

            SqlParameter param5 = new SqlParameter("@CO_IMG_1", SqlDbType.NVarChar);
            param5.Value = dto.CO_IMG_1;


            exeproc("AD_INSERT_UPDATE_COLLECTIONS_ID", param1, param2, param6, param3, param4, param5);

        }

        public DataTable SHOW_COLLECTIONS_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@CO_ID", SqlDbType.Int);
            param1.Value = dto.CO_ID;
            return load_data_param("AD_SHOW_COLLECTIONS_ID", param1);
        }

        ////============================== FAQ CATE ============================================

        public DataTable LOAD_LIST_FAQCATE(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_FAQCATE");
        }
        public void INSERT_UPDATE_FAQCATE_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@FC_ID", SqlDbType.Int);
            param1.Value = dto.FC_ID;

            SqlParameter param2 = new SqlParameter("@FC_NAME", SqlDbType.NVarChar);
            param2.Value = dto.FC_NAME;

            SqlParameter param3 = new SqlParameter("@FC_DES", SqlDbType.NVarChar);
            param3.Value = dto.FC_DES;

            SqlParameter param4 = new SqlParameter("@FC_ALIAS", SqlDbType.NVarChar);
            param4.Value = dto.FC_ALIAS;

            exeproc("AD_INSERT_UPDATE_FAQCATE_ID", param1, param2, param3, param4);

        }
        public DataTable SHOW_FAQCATE_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@FC_ID", SqlDbType.Int);
            param1.Value = dto.FC_ID;
            return load_data_param("AD_SHOW_FAQCATE_ID", param1);
        }
        public int DEL_FAQCATE_ID(DTO dto, ref int kq)
        {
            try
            {
                if (_sqlcon.State == ConnectionState.Closed) _sqlcon.Open();
                _sqlCom = new SqlCommand
                {
                    CommandText = "AD_DEL_FAQCATE_ID",
                    Connection = _sqlcon,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                _sqlCom.Parameters.AddWithValue("@FC_ID", dto.FC_ID);

                _sqlCom.Parameters.Add("@OUT", SqlDbType.Int).Value = 0;
                _sqlCom.Parameters["@OUT"].Direction = ParameterDirection.Output;
                _sqlCom.ExecuteNonQuery();

                kq = _sqlCom.Parameters["@OUT"].Value.ToString() != ""
                    ? int.Parse(_sqlCom.Parameters["@OUT"].Value.ToString())
                    : 0;
                _sqlcon.Close();
            }
            catch (Exception ex)
            {

            }
            return kq;
        }

        ////============================== FAQ ============================================

        public DataTable LOAD_LIST_FAQ(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_FAQ");
        }

        public int DEL_FAQ_ID(DTO dto, ref int kq)
        {
            try
            {
                if (_sqlcon.State == ConnectionState.Closed) _sqlcon.Open();
                _sqlCom = new SqlCommand
                {
                    CommandText = "AD_DEL_FAQ_ID",
                    Connection = _sqlcon,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                _sqlCom.Parameters.AddWithValue("@F_ID", dto.F_ID);

                _sqlCom.Parameters.Add("@OUT", SqlDbType.Int).Value = 0;
                _sqlCom.Parameters["@OUT"].Direction = ParameterDirection.Output;
                _sqlCom.ExecuteNonQuery();

                kq = _sqlCom.Parameters["@OUT"].Value.ToString() != ""
                    ? int.Parse(_sqlCom.Parameters["@OUT"].Value.ToString())
                    : 0;
                _sqlcon.Close();
            }
            catch (Exception ex)
            {

            }
            return kq;
        }
        public DataTable LOAD_LIST_CATE_IN_FAQ(DTO dto)
        {
            return Load_data("AD_LOAD_LIST_CATE_IN_FAQ");
        }
        public void INSERT_UPDATE_FAQ_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@F_ID", SqlDbType.Int);
            param1.Value = dto.F_ID;

            SqlParameter param2 = new SqlParameter("@F_ANSWER", SqlDbType.NVarChar);
            param2.Value = dto.F_ANSWER;

            SqlParameter param3 = new SqlParameter("@F_QUESTION", SqlDbType.NVarChar);
            param3.Value = dto.F_QUESTION;

            SqlParameter param4 = new SqlParameter("@FC_ID", SqlDbType.Int);
            param4.Value = dto.FC_ID;

            exeproc("AD_INSERT_UPDATE_FAQ_ID", param1, param2, param3, param4);

        }

        public DataTable SHOW_FAQ_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@F_ID", SqlDbType.Int);
            param1.Value = dto.F_ID;
            return load_data_param("AD_SHOW_FAQ_ID", param1);
        }


        ////============================== DRESS ============================================

        public DataTable LOAD_LIST_DRESS(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_DRESS");
        }
        public DataTable LOAD_LIST_COLLECTION_IN_DRESS(DTO dto)
        {
            return Load_data("AD_LOAD_LIST_COLLECTION_IN_DRESS");
        }
        public void INSERT_UPDATE_DRESS_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@WD_ID", SqlDbType.Int);
            param1.Value = dto.WD_ID;

            SqlParameter param2 = new SqlParameter("@WD_NAME", SqlDbType.NVarChar);
            param2.Value = dto.WD_NAME;

            SqlParameter param3 = new SqlParameter("@WD_DES", SqlDbType.NVarChar);
            param3.Value = dto.WD_DES;

            SqlParameter param4 = new SqlParameter("@WD_PRICE", SqlDbType.NVarChar);
            param4.Value = dto.WD_PRICE;

            SqlParameter param5 = new SqlParameter("@CO_ID", SqlDbType.Int);
            param5.Value = dto.CO_ID;

            exeproc("AD_INSERT_UPDATE_DRESS_ID", param1, param2, param3, param4, param5);

        }
        public int DEL_DRESS_ID(DTO dto, ref int kq)
        {
            try
            {
                if (_sqlcon.State == ConnectionState.Closed) _sqlcon.Open();
                _sqlCom = new SqlCommand
                {
                    CommandText = "AD_DEL_DRESS_ID",
                    Connection = _sqlcon,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                _sqlCom.Parameters.AddWithValue("@WD_ID", dto.WD_ID);

                _sqlCom.Parameters.Add("@OUT", SqlDbType.Int).Value = 0;
                _sqlCom.Parameters["@OUT"].Direction = ParameterDirection.Output;
                _sqlCom.ExecuteNonQuery();

                kq = _sqlCom.Parameters["@OUT"].Value.ToString() != ""
                    ? int.Parse(_sqlCom.Parameters["@OUT"].Value.ToString())
                    : 0;
                _sqlcon.Close();
            }
            catch (Exception ex)
            {

            }
            return kq;
        }

        public DataTable SHOW_DRESS_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@WD_ID", SqlDbType.Int);
            param1.Value = dto.WD_ID;
            return load_data_param("AD_SHOW_DRESS_ID", param1);
        }
        //====================================DRESS IMAGES ================================================
        public void INSERT_DRESS_IMG(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@WDI_ID", SqlDbType.Int);
            param1.Value = dto.WDI_ID;

            SqlParameter param2 = new SqlParameter("@WDI_NAME", SqlDbType.NVarChar);
            param2.Value = dto.WDI_NAME;

            SqlParameter param3 = new SqlParameter("@WDI_FILE", SqlDbType.NVarChar);
            param3.Value = dto.WDI_FILE;

            SqlParameter param4 = new SqlParameter("@WD_ID", SqlDbType.Int);
            param4.Value = dto.WD_ID;

            exeproc("[AD_INSERT_DRESS_IMG]", param1, param2, param3, param4);
        }
        public void DELETE_DRESS_IMG_ID(DTO dto)
        {
            SqlParameter param2 = new SqlParameter("@WDI_ID", SqlDbType.Int);
            param2.Value = dto.WDI_ID;

            exeproc("AD_DELETE_DRESS_IMG_ID", param2);
        }
        public DataTable SHOW_DRESS_IMAGES_WD_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@WD_ID", SqlDbType.Int);
            param1.Value = dto.WD_ID;
            return load_data_param("AD_SHOW_DRESS_IMAGES_WD_ID", param1);
        }

        //============================== BRIDES STORIE CATE =======================================

        public DataTable LOAD_LIST_BRIDES_STORIE_CATE(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_BRIDES_STORIE_CATE");
        }
        public void INSERT_UPDATE_BRIDES_STORIE_CATE_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@BSC_ID", SqlDbType.Int);
            param1.Value = dto.BSC_ID;

            SqlParameter param2 = new SqlParameter("@BSC_DES", SqlDbType.NVarChar);
            param2.Value = dto.BSC_DES;

            SqlParameter param3 = new SqlParameter("@BSC_IMG", SqlDbType.NVarChar);
            param3.Value = dto.BSC_IMG;

            exeproc("AD_INSERT_UPDATE_BRIDES_STORIE_CATE_ID", param1, param2, param3);

        }
        public int DEL_BRIDES_STORIE_CATE_ID(DTO dto, ref int kq)
        {
            try
            {
                if (_sqlcon.State == ConnectionState.Closed) _sqlcon.Open();
                _sqlCom = new SqlCommand
                {
                    CommandText = "AD_DEL_BRIDES_STORIE_CATE_ID",
                    Connection = _sqlcon,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                _sqlCom.Parameters.AddWithValue("@BSC_ID", dto.BSC_ID);

                _sqlCom.Parameters.Add("@OUT", SqlDbType.Int).Value = 0;
                _sqlCom.Parameters["@OUT"].Direction = ParameterDirection.Output;
                _sqlCom.ExecuteNonQuery();

                kq = _sqlCom.Parameters["@OUT"].Value.ToString() != ""
                    ? int.Parse(_sqlCom.Parameters["@OUT"].Value.ToString())
                    : 0;
                _sqlcon.Close();
            }
            catch (Exception ex)
            {

            }
            return kq;
        }
        public DataTable SHOW_BRIDES_STORIE_CATE_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@BSC_ID", SqlDbType.Int);
            param1.Value = dto.BSC_ID;
            return load_data_param("AD_SHOW_BRIDES_STORIE_CATE_ID", param1);
        }


        //============================== ORDER PROCESS =======================================

        public DataTable LOAD_LIST_ORDER_PROCESS(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_ORDER_PROCESS");
        }
        public void INSERT_UPDATE_ORDER_PROCESS_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@OP_ID", SqlDbType.Int);
            param1.Value = dto.OP_ID;

            SqlParameter param3 = new SqlParameter("@OP_DES", SqlDbType.NVarChar);
            param3.Value = dto.OP_DES;

            SqlParameter param4 = new SqlParameter("@OP_IMG", SqlDbType.NVarChar);
            param4.Value = dto.OP_IMG;

            SqlParameter param8 = new SqlParameter("@OP_DETAIL", SqlDbType.NVarChar);
            param8.Value = dto.OP_DETAIL;

            exeproc("AD_INSERT_UPDATE_ORDER_PROCESS_ID", param1, param3, param4, param8);

        }
        public int DEL_ORDER_PROCESS_ID(DTO dto, ref int kq)
        {
            try
            {
                if (_sqlcon.State == ConnectionState.Closed) _sqlcon.Open();
                _sqlCom = new SqlCommand
                {
                    CommandText = "AD_DEL_ORDER_PROCESS_ID",
                    Connection = _sqlcon,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                _sqlCom.Parameters.AddWithValue("@OP_ID", dto.OP_ID);

                _sqlCom.Parameters.Add("@OUT", SqlDbType.Int).Value = 0;
                _sqlCom.Parameters["@OUT"].Direction = ParameterDirection.Output;
                _sqlCom.ExecuteNonQuery();

                kq = _sqlCom.Parameters["@OUT"].Value.ToString() != ""
                    ? int.Parse(_sqlCom.Parameters["@OUT"].Value.ToString())
                    : 0;
                _sqlcon.Close();
            }
            catch (Exception ex)
            {

            }
            return kq;
        }
        public DataTable SHOW_ORDER_PROCESS_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@OP_ID", SqlDbType.Int);
            param1.Value = dto.OP_ID;
            return load_data_param("AD_SHOW_ORDER_PROCESS_ID", param1);
        }


        //=========================== USERS ==============================================
        public DataTable AD_LOAD_LIST_USERS(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_USERS");
        }
        public DataTable SHOW_USER_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@U_ID", SqlDbType.Int);
            param1.Value = dto.U_ID;
            return load_data_param("AD_SHOW_USER_ID", param1);
        }
        public void INSERT_UPDATE_USER_ID(DTO dto)
        {

            SqlParameter param1 = new SqlParameter("@U_ID", SqlDbType.Int);
            param1.Value = dto.U_ID;

            SqlParameter param2 = new SqlParameter("@U_NAME", SqlDbType.NVarChar);
            param2.Value = dto.U_NAME;

            SqlParameter param3 = new SqlParameter("@U_MAIL", SqlDbType.NVarChar);
            param3.Value = dto.U_MAIL;

            SqlParameter param4 = new SqlParameter("@U_PASS", SqlDbType.NVarChar);
            param4.Value = dto.U_PASS;

            SqlParameter param5 = new SqlParameter("@U_PHONE", SqlDbType.NVarChar);
            param5.Value = dto.U_PHONE;

            SqlParameter param6 = new SqlParameter("@NA_ID", SqlDbType.Int);
            param6.Value = dto.NA_ID;

            SqlParameter param7 = new SqlParameter("@U_BUGET", SqlDbType.Float);
            param7.Value = dto.U_BUGET;

            SqlParameter param8 = new SqlParameter("@U_WEDDING_DATE", SqlDbType.DateTime);
            param8.Value = dto.U_WEDDING_DATE;

            SqlParameter param9 = new SqlParameter("@U_AVATAR", SqlDbType.NVarChar);
            param9.Value = dto.U_AVATAR;

            SqlParameter param10 = new SqlParameter("@U_STATUS", SqlDbType.Int);
            param10.Value = dto.U_STATUS;

            exeproc("AD_INSERT_UPDATE_USER_ID", param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
        }
        public DataTable LOAD_LIST_NATION_IN_USER(DTO dto)
        {
            return Load_data("AD_LOAD_LIST_NATION_IN_USER");
        }

        //============================== INQUIRIES ================================
        public DataTable LOAD_LIST_INQUIRIES(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_INQUIRIES");
        }
        public DataTable LOAD_LIST_DRESS_IN_USER(DTO dto)
        {
            return Load_data("AD_LOAD_LIST_DRESS_IN_USER");
        }
        public DataTable LOAD_LIST_USER_IN_USER(DTO dto)
        {
            return Load_data("AD_LOAD_LIST_USER_IN_USER");
        }
        public DataTable SHOW_INQUIRIES_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@IQ_ID", SqlDbType.Int);
            param1.Value = dto.IQ_ID;
            return load_data_param("AD_SHOW_INQUIRIES_ID", param1);
        }

        public void INSERT_INQUIRIES_IQ_ID(DTO dto)
        {

            SqlParameter param1 = new SqlParameter("@IQ_ID", SqlDbType.Int);
            param1.Value = dto.IQ_ID;

            SqlParameter param2 = new SqlParameter("@IQ_DATE", SqlDbType.DateTime);
            param2.Value = dto.IQ_DATE;

            SqlParameter param3 = new SqlParameter("@WD_ID", SqlDbType.Int);
            param3.Value = dto.WD_ID;

            SqlParameter param4 = new SqlParameter("@IQ_MESSENGER", SqlDbType.NVarChar);
            param4.Value = dto.IQ_MESSENGER;

            SqlParameter param5 = new SqlParameter("@U_ID", SqlDbType.Int);
            param5.Value = dto.U_ID;

            SqlParameter param6 = new SqlParameter("@IQ_TOTAL_AMOUT", SqlDbType.Float);
            param6.Value = dto.IQ_TOTAL_AMOUT;

            SqlParameter param7 = new SqlParameter("@IQ_TOWARD", SqlDbType.Float);
            param7.Value = dto.IQ_TOWARD;

            SqlParameter param8 = new SqlParameter("@IQ_DEPOSIT", SqlDbType.Float);
            param8.Value = dto.IQ_DEPOSIT;

            SqlParameter param9 = new SqlParameter("@IQ_DUE_DATE", SqlDbType.DateTime);
            param9.Value = dto.IQ_DUE_DATE;

            SqlParameter param10 = new SqlParameter("@IQ_NAME", SqlDbType.NVarChar);
            param10.Value = dto.IQ_NAME;

            SqlParameter param11 = new SqlParameter("@IQ_MAIL", SqlDbType.NVarChar);
            param11.Value = dto.IQ_MAIL;

            SqlParameter param12 = new SqlParameter("@IQ_PHONE", SqlDbType.NVarChar);
            param12.Value = dto.IQ_PHONE;

            SqlParameter param13 = new SqlParameter("@NA_ID", SqlDbType.Int);
            param13.Value = dto.NA_ID;

            SqlParameter param14 = new SqlParameter("@IQ_BUGET", SqlDbType.Float);
            param14.Value = dto.IQ_BUGET;

            SqlParameter param15 = new SqlParameter("@IQ_WEDDING_DATE", SqlDbType.DateTime);
            param15.Value = dto.IQ_WEDDING_DATE;

            SqlParameter param16 = new SqlParameter("@IQ_STATUS", SqlDbType.Int);
            param16.Value = dto.IQ_STATUS;

            SqlParameter param17 = new SqlParameter("@IQ_PROGRESS", SqlDbType.Int);
            param17.Value = dto.IQ_PROGRESS;


            exeproc("AD_INSERT_INQUIRIES_IQ_ID", param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16, param17);
        }

        //=========================== ABOUT US ==============================================
        public DataTable LOAD_LIST_ABOUT(DTO dto)
        {
            return load_data_param("AD_LOAD_LIST_ABOUT");
        }
        public DataTable SHOW_ABOUT_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@AU_ID", SqlDbType.Int);
            param1.Value = dto.AU_ID;
            return load_data_param("AD_SHOW_ABOUT_ID", param1);
        }
        public void INSERT_UPDATE_ABOUT_ID(DTO dto)
        {
            SqlParameter param1 = new SqlParameter("@AU_ID", SqlDbType.Int);
            param1.Value = dto.AU_ID;

            SqlParameter param2 = new SqlParameter("@AU_NAME", SqlDbType.NVarChar);
            param2.Value = dto.AU_NAME;

            SqlParameter param3 = new SqlParameter("@AU_DETAIL", SqlDbType.NVarChar);
            param3.Value = dto.AU_DETAIL;

            SqlParameter param4 = new SqlParameter("@AU_TITLE", SqlDbType.NVarChar);
            param4.Value = dto.AU_TITLE;

            SqlParameter param5 = new SqlParameter("@AU_IMG", SqlDbType.NVarChar);
            param5.Value = dto.AU_IMG;


            exeproc("AD_INSERT_UPDATE_ABOUT_ID", param1, param2, param3, param4, param5);

        }

        public int DEL_ABOUT_US_ID(DTO dto, ref int kq)
        {
            try
            {
                if (_sqlcon.State == ConnectionState.Closed) _sqlcon.Open();
                _sqlCom = new SqlCommand
                {
                    CommandText = "AD_DEL_ABOUT_US_ID",
                    Connection = _sqlcon,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                _sqlCom.Parameters.AddWithValue("@AU_ID", dto.AU_ID);

                _sqlCom.Parameters.Add("@OUT", SqlDbType.Int).Value = 0;
                _sqlCom.Parameters["@OUT"].Direction = ParameterDirection.Output;
                _sqlCom.ExecuteNonQuery();

                kq = _sqlCom.Parameters["@OUT"].Value.ToString() != ""
                    ? int.Parse(_sqlCom.Parameters["@OUT"].Value.ToString())
                    : 0;
                _sqlcon.Close();
            }
            catch (Exception ex)
            {

            }
            return kq;
        }
    }
}