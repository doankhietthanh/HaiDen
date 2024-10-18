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
    public class Inquiries_Repository
    {
        // Methods
        internal Inquiries_Response INSERT_UPDATE_INQUIRIES(Inquiries_Request req)
        {
            Inquiries_Response response = new Inquiries_Response();
            string procname = "INSERT_UPDATE_INQUIRIES";
            try
            {
                SqlParameter parameter = new SqlParameter("@IQ_ID", SqlDbType.Int)
                {
                    Value = req.IQ_ID
                };
                SqlParameter parameter2 = new SqlParameter("@IQ_DATE", SqlDbType.Date)
                {
                    Value = req.IQ_DATE
                };
                SqlParameter parameter3 = new SqlParameter("@WD_ID", SqlDbType.Int)
                {
                    Value = req.WD_ID
                };
                SqlParameter parameter4 = new SqlParameter("@IQ_MESSENGER", SqlDbType.NVarChar)
                {
                    Value = req.IQ_MESSENGER
                };
                SqlParameter parameter5 = new SqlParameter("@U_ID", SqlDbType.Int)
                {
                    Value = req.U_ID
                };
                SqlParameter parameter6 = new SqlParameter("@IQ_TOTAL_AMOUT", SqlDbType.Float)
                {
                    Value = req.IQ_TOTAL_AMOUT
                };
                SqlParameter parameter7 = new SqlParameter("@IQ_TOWARD", SqlDbType.Float)
                {
                    Value = req.IQ_TOWARD
                };
                SqlParameter parameter8 = new SqlParameter("@IQ_DEPOSIT", SqlDbType.Float)
                {
                    Value = req.IQ_DEPOSIT
                };
                SqlParameter parameter9 = new SqlParameter("@IQ_DUE_DATE", SqlDbType.Date)
                {
                    Value = req.IQ_DUE_DATE
                };
                SqlParameter parameter10 = new SqlParameter("@IQ_NAME", SqlDbType.NVarChar)
                {
                    Value = req.IQ_NAME
                };
                SqlParameter parameter11 = new SqlParameter("@IQ_MAIL", SqlDbType.NVarChar)
                {
                    Value = req.IQ_MAIL
                };
                SqlParameter parameter12 = new SqlParameter("@IQ_PHONE", SqlDbType.NVarChar)
                {
                    Value = req.IQ_PHONE
                };
                SqlParameter parameter13 = new SqlParameter("@NA_ID", SqlDbType.Int)
                {
                    Value = req.NA_ID
                };
                SqlParameter parameter14 = new SqlParameter("@IQ_BUGET", SqlDbType.Float)
                {
                    Value = req.IQ_BUGET
                };
                SqlParameter parameter15 = new SqlParameter("@IQ_WEDDING_DATE", SqlDbType.Date)
                {
                    Value = req.IQ_WEDDING_DATE
                };
                SqlParameter parameter16 = new SqlParameter("@IQ_STATUS", SqlDbType.Int)
                {
                    Value = req.IQ_STATUS
                };
                SqlParameter parameter17 = new SqlParameter("@IQ_PROGRESS", SqlDbType.Int)
                {
                    Value = req.IQ_PROGRESS
                };
                baseResponseSingle num = new baseResponseSingle();
                SqlParameter[] prams = new SqlParameter[0x11];
                prams[0] = parameter;
                prams[1] = parameter2;
                prams[2] = parameter3;
                prams[3] = parameter4;
                prams[4] = parameter5;
                prams[5] = parameter6;
                prams[6] = parameter7;
                prams[7] = parameter8;
                prams[8] = parameter9;
                prams[9] = parameter10;
                prams[10] = parameter11;
                prams[11] = parameter12;
                prams[12] = parameter13;
                prams[13] = parameter14;
                prams[14] = parameter15;
                prams[15] = parameter16;
                prams[0x10] = parameter17;
                num = baseConnection.add_data_param(procname, prams);
                response.Code = num.Code;
                response.result = num.result;
                response.error = num.error;
            }
            catch (Exception exception1)
            {
                response.Code = 500;
                response.result = "ERROR";
                response.error = exception1.Message;
            }
            return response;
        }

        internal Inquiries_Get_Response LOAD_INQUIRIES(Inquiries_Get_Request req)
        {
            Inquiries_Get_Response response = new Inquiries_Get_Response();
            string procname = "LOAD_INQUIRIES";
            try
            {
                SqlParameter parameter = new SqlParameter("@U_ID", SqlDbType.Int)
                {
                    Value = req.U_ID
                };
                SqlParameter[] prams = new SqlParameter[] { parameter };
                response.DataList = CommonHelper.ConvertToList<Inquiries_Model>(baseConnection.load_data_param(procname, prams));
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