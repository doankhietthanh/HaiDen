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
    public class AboutUs_Repository
    {
        internal AboutUs_Response LOAD_ABOUTUS(AboutUs_Request req)
        {
            var response = new AboutUs_Response();
            var procname = "LOAD_ABOUTUS";
            try
            {
                SqlParameter param1 = new SqlParameter("@Lang", SqlDbType.NVarChar);
                param1.Value = req.Lang;
                SqlParameter param2 = new SqlParameter("@TYPE", SqlDbType.Int);
                param2.Value = req.TYPE;
                response.DataList = CommonHelper.ConvertToList<AboutUs_Model>(baseConnection.load_data_param(procname, param1, param2));
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