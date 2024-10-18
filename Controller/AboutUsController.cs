using HaiDen.Handling;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class AboutUsController
    {
        AboutUs_Repository Repository = new AboutUs_Repository();
        public AboutUs_Response LOAD_ABOUTUS(AboutUs_Request req)
        {
            var Response = new AboutUs_Response();
            try
            {
                Response = Repository.LOAD_ABOUTUS(req);
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