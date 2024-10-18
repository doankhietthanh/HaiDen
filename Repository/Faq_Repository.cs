using Common;
using HaiDen.Handling;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HaiDen.Repository
{
    public class Faq_Repository
    {
        // Methods
        internal Faq_Response LOAD_FAQ(Faq_Request req)
        {
            Faq_Response response = new Faq_Response();
            string procname = "LOAD_FAQ";
            try
            {
                SqlParameter parameter = new SqlParameter("@Lang", SqlDbType.NVarChar)
                {
                    Value = req.Lang
                };
                SqlParameter parameter2 = new SqlParameter("@FC_ID", SqlDbType.Int)
                {
                    Value = req.FC_ID
                };
                SqlParameter[] prams = new SqlParameter[] { parameter, parameter2 };
                response.DataList = CommonHelper.ConvertToList<Faq_Model>(baseConnection.load_data_param(procname, prams));
                response.Code = 0;
                response.result = "SUCCESS";
            }
            catch (Exception exception1)
            {
                response.Code = 1;
                response.result = "ERROR";
                response.error = exception1.Message;
            }
            return response;
        }

        internal Faq_Cate_Response LOAD_FAQ_CATE(Faq_Cate_Request req)
        {
            Faq_Cate_Response response = new Faq_Cate_Response();
            string procname = "LOAD_FAQ_CATE";
            try
            {
                SqlParameter parameter = new SqlParameter("@Lang", SqlDbType.NVarChar)
                {
                    Value = req.Lang
                };
                SqlParameter[] prams = new SqlParameter[] { parameter };
                response.DataList = CommonHelper.ConvertToList<Faq_Cate_Model>(baseConnection.load_data_param(procname, prams));
                response.Code = 0;
                response.result = "SUCCESS";
            }
            catch (Exception exception1)
            {
                response.Code = 1;
                response.result = "ERROR";
                response.error = exception1.Message;
            }
            return response;
        }
    }



}