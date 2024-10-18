using HaiDen.Handling;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class BannerController
    {
        Banner_Repository Repository = new Banner_Repository();
        public Banner_Response LOAD_BANNER(Banner_Request req)
        {
            var Response = new Banner_Response();
            try
            {
                Response = Repository.LOAD_BANNER(req);
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