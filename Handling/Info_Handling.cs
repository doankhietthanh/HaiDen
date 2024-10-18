using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{
    public class Info_Request : baseRequest
    {
        // Methods
        public Info_Request()
        {
            this.IF_ALIAS = "-1";
        }

        // Properties
        public string IF_ALIAS { get; set; }
    }
    public class Info_Response : baseResponse<List<Info_Model>>
    {
    }

}