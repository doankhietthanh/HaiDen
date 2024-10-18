using HaiDen.Handling;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class NewsController
    {
        News_Repository Repository = new News_Repository();
        public News_Response LOAD_NEWS(News_Request req)
        {
            var Response = new News_Response();
            try
            {
                Response = Repository.LOAD_NEWS(req);
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