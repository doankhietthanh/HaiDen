using HaiDen.Handling;
using HaiDen.Repository;
using System;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class OrderProcessController
    {
        // Fields
        private OrderProcess_Repository Repository = new OrderProcess_Repository();

        // Methods
        public OrderProcess_Response LOAD_ORDERPROCESS(OrderProcess_Request req)
        {
            OrderProcess_Response response = new OrderProcess_Response();
            try
            {
                response = this.Repository.LOAD_ORDERPROCESS(req);
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