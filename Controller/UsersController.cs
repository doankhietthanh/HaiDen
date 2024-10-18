using Common;
using HaiDen.Handling;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class UsersController
    {
        Users_Repository Repository = new Users_Repository();
        public Users_Response INSERT_UPDATE_USER(Users_Request req)
        {
            var Response = new Users_Response();
            try
            {
                req.U_PASS = req.U_PASS != "-1" ? CommonHelper.ToMD5_v2(req.U_PASS) : "-1";
                Response = Repository.INSERT_UPDATE_USER(req);
                switch (Response.Code)
                {
                    case -1:
                        Response.result = "Error, not sign up!";
                        break;
                    case 0:
                        Response.result = "Sign up success!";
                        break;
                    case 1:
                        Response.result = "This email was registed, please choose another email or sign in!";
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Code = 501;
                Response.error = ex.Message;
            }

            return Response;
        }

        public Users_Nationality_Response LOAD_USERS_NATIONALITY(Users_Nationality_Request req)
        {
            Users_Nationality_Response response = new Users_Nationality_Response();
            try
            {
                response = this.Repository.LOAD_USERS_NATIONALITY(req);
            }
            catch (Exception exception1)
            {
                response.Code = 0x1f5;
                response.error = exception1.Message;
            }
            return response;
        }

        public Users_Login_Response LOGIN_USERS(Users_Login_Request req)
        {
            var Response = new Users_Login_Response();
            try
            {
                req.U_PASS = CommonHelper.ToMD5_v2(req.U_PASS);

                Response = Repository.LOGIN_USERS(req);
                var retCode = Response.DataList[0].CODE;
                switch (retCode)
                {
                    case 1:
                        if (req.U_REMEMBER == true)
                        {
                            HttpCookie cookie = new HttpCookie("CookieUsersName", req.U_MAIL);
                            cookie.Expires = DateTime.Now.AddDays(7);
                            HttpContext.Current.Response.Cookies.Add(cookie);
                        }
                        else
                        {
                            HttpCookie cookie1 = new HttpCookie("SUsersName", req.U_MAIL);
                            HttpContext.Current.Response.Cookies.Add(cookie1);
                        }
                        Response.result = "Success!";
                        break;
                    case 0:
                        Response.result = "Account not yet confirmed!";
                        break;
                    case 2:
                        Response.result = "Account blocked!";
                        break;
                    case -1:
                    case -2:
                        Response.result = "Incorrect username or password!";
                        break;
                }
                Response.Code = retCode;
            }
            catch (Exception ex)
            {
                Response.Code = 501;
                Response.error = ex.Message;
            }

            return Response;
        }
    }
}