using System;
using System.Linq;
using System.Web;
using HaiDen.Handling;
using System.Data.SqlClient;
using Common;
using HaiDen.Models;
using System.Data;

namespace HaiDen.Repository
{
    public class OrderProcess_Repository
    {
        // Methods
        internal OrderProcess_Response LOAD_ORDERPROCESS(OrderProcess_Request req)
        {
            OrderProcess_Response response = new OrderProcess_Response();
            string procname = "LOAD_ORDERPROCESS";
            try
            {
                SqlParameter parameter = new SqlParameter("@Lang", SqlDbType.NVarChar)
                {
                    Value = req.Lang
                };
                SqlParameter parameter2 = new SqlParameter("@TYPE", SqlDbType.Int)
                {
                    Value = req.TYPE
                };
                SqlParameter[] prams = new SqlParameter[] { parameter, parameter2 };
                response.DataList = CommonHelper.ConvertToList<OrderProcess_Model>(baseConnection.load_data_param(procname, prams))[0];
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