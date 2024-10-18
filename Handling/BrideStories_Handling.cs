using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{
    public class BrideStories_Request : baseRequest
    {
        // Methods
        public BrideStories_Request()
        {
            this.BS_ID = -1;
        }

        // Properties
        public int BS_ID { get; set; }
    }
    public class BrideStories_Response : baseResponse<List<BrideStories_Model>>
    {
    }
    public class BrideStoriesCate_Request : baseRequest
    {
    }
    public class BrideStoriesCate_Response : baseResponse<List<BrideStoriesCate_Model>>
    {
    }





}