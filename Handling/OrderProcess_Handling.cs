using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{
    public class OrderProcess_Request : baseRequest
    {
        public OrderProcess_Request()
        {
            TYPE = -1; // LOAD ALL
        }
        public int TYPE { get; set; }
    }
    public class OrderProcess_Response : baseResponse<OrderProcess_Model>
    {
    }
}