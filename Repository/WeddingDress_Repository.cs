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
    public class WeddingDress_Repository
    {
        internal WeddingDressFav_Response INSERT_FAVOURITE(WeddingDressFav_Request req)
        {
            WeddingDressFav_Response response = new WeddingDressFav_Response();
            string procname = "INSERT_FAVOURITE";
            try
            {
                SqlParameter parameter = new SqlParameter("@U_MAIL", SqlDbType.NVarChar)
                {
                    Value = req.U_MAIL
                };
                SqlParameter parameter2 = new SqlParameter("@WD_ID", SqlDbType.Int)
                {
                    Value = req.WD_ID
                };
                baseResponseSingle num = new baseResponseSingle();
                SqlParameter[] prams = new SqlParameter[] { parameter, parameter2 };
                response.Code = baseConnection.add_data_param(procname, prams).Code;
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

        internal WeddingDress_Response LOAD_WEDDINGDRESS(WeddingDress_Request req)
        {
            WeddingDress_Response response = new WeddingDress_Response();
            string procname = "LOAD_WEDDINGDRESS";
            try
            {
                SqlParameter parameter = new SqlParameter("@Lang", SqlDbType.NVarChar)
                {
                    Value = req.Lang
                };
                SqlParameter parameter2 = new SqlParameter("@WD_ID", SqlDbType.Int)
                {
                    Value = req.WD_ID
                };
                SqlParameter parameter3 = new SqlParameter("@CO_NAME", SqlDbType.NVarChar)
                {
                    Value = req.CO_NAME
                };
                SqlParameter parameter4 = new SqlParameter("@U_MAIL", SqlDbType.NVarChar)
                {
                    Value = req.U_MAIL
                };
                SqlParameter[] prams = new SqlParameter[] { parameter, parameter2, parameter3 };
                response.DataList = CommonHelper.ConvertToList<WeddingDress_Model>(baseConnection.load_data_param(procname, prams));
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

        internal WeddingDressFavList_Response LOAD_WEDDINGDRESS_FAV(WeddingDressFavList_Request req)
        {
            WeddingDressFavList_Response response = new WeddingDressFavList_Response();
            string procname = "LOAD_WEDDINGDRESS_FAV";
            try
            {
                SqlParameter parameter = new SqlParameter("@Lang", SqlDbType.NVarChar)
                {
                    Value = req.Lang
                };
                SqlParameter parameter2 = new SqlParameter("@U_MAIL", SqlDbType.NVarChar)
                {
                    Value = req.U_MAIL
                };
                SqlParameter[] prams = new SqlParameter[] { parameter, parameter2 };
                response.DataList = CommonHelper.ConvertToList<WeddingDress_Model>(baseConnection.load_data_param(procname, prams));
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

        internal WeddingDressImg_Response LOAD_WEDDINGDRESSIMG(WeddingDressImg_Request req)
        {
            WeddingDressImg_Response response = new WeddingDressImg_Response();
            string procname = "LOAD_WEDDINGDRESSIMG";
            try
            {
                SqlParameter parameter = new SqlParameter("@Lang", SqlDbType.NVarChar)
                {
                    Value = req.Lang
                };
                SqlParameter parameter2 = new SqlParameter("@WD_ID", SqlDbType.Int)
                {
                    Value = req.WD_ID
                };
                SqlParameter[] prams = new SqlParameter[] { parameter, parameter2 };
                response.DataList = CommonHelper.ConvertToList<WeddingDressImg_Model>(baseConnection.load_data_param(procname, prams));
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