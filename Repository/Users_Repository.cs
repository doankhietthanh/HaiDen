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
    public class Users_Repository
    {
        // Methods
        internal Users_Response INSERT_UPDATE_USER(Users_Request req)
        {
            Users_Response response = new Users_Response();
            string procname = "INSERT_UPDATE_USER";
            try
            {
                SqlParameter parameter = new SqlParameter("@U_NAME", SqlDbType.NVarChar)
                {
                    Value = req.U_NAME
                };
                SqlParameter parameter2 = new SqlParameter("@U_MAIL", SqlDbType.NVarChar)
                {
                    Value = req.U_MAIL
                };
                SqlParameter parameter3 = new SqlParameter("@U_PASS", SqlDbType.NVarChar)
                {
                    Value = req.U_PASS
                };
                SqlParameter parameter4 = new SqlParameter("@U_STATUS", SqlDbType.Int)
                {
                    Value = req.U_STATUS
                };
                SqlParameter parameter5 = new SqlParameter("@U_PHONE", SqlDbType.NVarChar)
                {
                    Value = req.U_PHONE
                };
                SqlParameter parameter6 = new SqlParameter("@NA_ID", SqlDbType.Int)
                {
                    Value = req.NA_ID
                };
                SqlParameter parameter7 = new SqlParameter("@U_BUGET", SqlDbType.Float)
                {
                    Value = req.U_BUGET
                };
                SqlParameter parameter8 = new SqlParameter("@U_WEDDING_DATE", SqlDbType.Date)
                {
                    Value = req.U_WEDDING_DATE
                };
                SqlParameter parameter9 = new SqlParameter("@U_AVATAR", SqlDbType.NVarChar)
                {
                    Value = req.U_AVATAR
                };
                SqlParameter parameter10 = new SqlParameter("@U_ID", SqlDbType.Int)
                {
                    Value = req.U_ID
                };
                SqlParameter parameter11 = new SqlParameter("@MODE", SqlDbType.NVarChar)
                {
                    Value = req.MODE
                };
                baseResponseSingle num = new baseResponseSingle();
                SqlParameter[] prams = new SqlParameter[11];
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

        internal Users_Nationality_Response LOAD_USERS_NATIONALITY(Users_Nationality_Request req)
        {
            Users_Nationality_Response response = new Users_Nationality_Response();
            string procname = "LOAD_USERS_NATIONALITY";
            try
            {
                response.DataList = CommonHelper.ConvertToList<USERS_NATIONALITY>(baseConnection.load_data_param(procname, Array.Empty<SqlParameter>()));
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

        internal Users_Login_Response LOGIN_USERS(Users_Login_Request req)
        {
            Users_Login_Response response = new Users_Login_Response();
            string procname = "LOGIN_USERS";
            try
            {
                SqlParameter parameter = new SqlParameter("@U_MAIL", SqlDbType.NVarChar)
                {
                    Value = req.U_MAIL
                };
                SqlParameter parameter2 = new SqlParameter("@U_PASS", SqlDbType.NVarChar)
                {
                    Value = req.U_PASS
                };
                SqlParameter[] prams = new SqlParameter[] { parameter2, parameter };
                response.DataList = CommonHelper.ConvertToList<Users_Model>(baseConnection.load_data_param(procname, prams));
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