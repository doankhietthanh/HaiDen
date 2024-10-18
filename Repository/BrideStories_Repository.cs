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
    public class BrideStories_Repository
    {
        // Methods
        internal BrideStories_Response LOAD_BRIDESTORIES(BrideStories_Request req)
        {
            BrideStories_Response response = new BrideStories_Response();
            string procname = "LOAD_BRIDESTORIES";
            try
            {
                SqlParameter parameter = new SqlParameter("@Lang", SqlDbType.NVarChar)
                {
                    Value = req.Lang
                };
                SqlParameter parameter2 = new SqlParameter("@BS_ID", SqlDbType.Int)
                {
                    Value = req.BS_ID
                };
                SqlParameter[] prams = new SqlParameter[] { parameter, parameter2 };
                response.DataList = CommonHelper.ConvertToList<BrideStories_Model>(baseConnection.load_data_param(procname, prams));
                response.Code = 0;
                response.result = "SUCCESS";
            }
            catch (Exception exception1)
            {
                response.Code = 500;
                response.result = "ERROR";
                response.error = exception1.Message;
            }
            return response;
        }

        internal BrideStoriesCate_Response LOAD_BRIDESTORIES_CATE(BrideStoriesCate_Request req)
        {
            BrideStoriesCate_Response response = new BrideStoriesCate_Response();
            string procname = "LOAD_BRIDESTORIES_CATE";
            try
            {
                SqlParameter parameter = new SqlParameter("@Lang", SqlDbType.NVarChar)
                {
                    Value = req.Lang
                };
                SqlParameter[] prams = new SqlParameter[] { parameter };
                response.DataList = CommonHelper.ConvertToList<BrideStoriesCate_Model>(baseConnection.load_data_param(procname, prams));
                response.Code = 0;
                response.result = "SUCCESS";
            }
            catch (Exception exception1)
            {
                response.Code = 500;
                response.result = "ERROR";
                response.error = exception1.Message;
            }
            return response;
        }
    }



}