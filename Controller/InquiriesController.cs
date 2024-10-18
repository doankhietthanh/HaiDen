using HaiDen.Handling;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class InquiriesController
    {
        // Fields
        private Inquiries_Repository Repository = new Inquiries_Repository();

        // Methods
        public Inquiries_Response INSERT_UPDATE_INQUIRIES(Inquiries_Request req)
        {
            Inquiries_Response response = new Inquiries_Response();
            try
            {
                response = this.Repository.INSERT_UPDATE_INQUIRIES(req);
            }
            catch (Exception exception1)
            {
                response.Code = 0x1f5;
                response.error = exception1.Message;
            }
            return response;
        }

        public Inquiries_Get_Response LOAD_INQUIRIES(Inquiries_Get_Request req)
        {
            Inquiries_Get_Response response = new Inquiries_Get_Response();
            try
            {
                response = this.Repository.LOAD_INQUIRIES(req);
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