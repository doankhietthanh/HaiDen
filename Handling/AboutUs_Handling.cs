using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{
    public class AboutUs_Request : baseRequest
    {
        public AboutUs_Request()
        {
            TYPE = -1; // LOAD ALL
        }
        public int TYPE { get; set; }
    }
    public class AboutUs_Response : baseResponse<List<AboutUs_Model>>
    {
    }
}