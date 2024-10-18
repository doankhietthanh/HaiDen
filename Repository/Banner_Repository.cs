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
    public class Banner_Repository
    {
        internal Banner_Response LOAD_BANNER(Banner_Request req)
        {
            var response = new Banner_Response();
            var procname = "LOAD_BANNER";
            try
            {
                SqlParameter param1 = new SqlParameter("@Lang", SqlDbType.NVarChar);
                param1.Value = req.Lang;
                response.DataList = CommonHelper.ConvertToList<Banner_Model>(baseConnection.load_data_param(procname, param1));
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