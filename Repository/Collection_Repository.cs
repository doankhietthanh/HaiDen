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
    public class Collection_Repository
    {
        // Methods
        internal Collection_Response LOAD_COLLECTION(Collection_Request req)
        {
            Collection_Response response = new Collection_Response();
            string procname = "LOAD_COLLECTION";
            try
            {
                SqlParameter parameter = new SqlParameter("@Lang", SqlDbType.NVarChar)
                {
                    Value = req.Lang
                };
                SqlParameter parameter2 = new SqlParameter("@CO_ID", SqlDbType.Int)
                {
                    Value = req.CO_ID
                };
                SqlParameter[] prams = new SqlParameter[] { parameter, parameter2 };
                response.DataList = CommonHelper.ConvertToList<Collection_Model>(baseConnection.load_data_param(procname, prams));
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