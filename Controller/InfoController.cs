using HaiDen.Handling;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class InfoController
    {
        // Fields
        private Info_Repository Repository = new Info_Repository();

        // Methods
        public Info_Response LOAD_INFO(Info_Request req)
        {
            Info_Response response = new Info_Response();
            try
            {
                response = this.Repository.LOAD_INFO(req);
            }
            catch (Exception exception1)
            {
                response.Code = 0x1f5;
                response.error = exception1.Message;
            }
            return response;
        }
    }



}