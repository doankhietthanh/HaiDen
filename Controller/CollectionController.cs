using HaiDen.Handling;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class CollectionController
    {
        // Fields
        private Collection_Repository Repository = new Collection_Repository();

        // Methods
        public Collection_Response LOAD_COLLECTION(Collection_Request req)
        {
            Collection_Response response = new Collection_Response();
            try
            {
                response = this.Repository.LOAD_COLLECTION(req);
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