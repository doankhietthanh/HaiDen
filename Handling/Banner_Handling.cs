using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{
    public class Banner_Request : baseRequest
    {
        public string BN_KEY { get; set; }
    }
    public class Banner_Response : baseResponse<List<Banner_Model>>
    {
    }
}