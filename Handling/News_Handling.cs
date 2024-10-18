using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{
    public class News_Request : baseRequest
    {
        public News_Request()
        {
            N_ID = -1;
        }
        public int N_ID { get; set; }
    }
    public class News_Response : baseResponse<List<News_Model>>
    {
    }
}