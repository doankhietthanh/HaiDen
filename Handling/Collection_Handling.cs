using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{

    public class Collection_Request : baseRequest
    {
        public Collection_Request()
        {
            CO_ID = -1;
        }
        public int CO_ID { get; set; }
    }
    public class Collection_Response : baseResponse<List<Collection_Model>>
    {
    }
}