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
    public class News_Repository
    {
        internal News_Response LOAD_NEWS(News_Request req)
        {
            var response = new News_Response();
            var procname = "LOAD_NEWS";
            try
            {
                SqlParameter param1 = new SqlParameter("@Lang", SqlDbType.NVarChar);
                param1.Value = req.Lang;
                SqlParameter param2 = new SqlParameter("@N_ID", SqlDbType.Int);
                param2.Value = req.N_ID;
                response.DataList = CommonHelper.ConvertToList<News_Model>(baseConnection.load_data_param(procname, param1, param2));
                response.Code = 0;
                response.result = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.Code = 500;
                response.result = "ERROR";
                response.error = ex.Message;
            }
            return response;
        }
    }
}