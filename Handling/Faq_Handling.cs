using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{
    public class Faq_Cate_Request : baseRequest
    {
    }
    public class Faq_Cate_Response : baseResponse<List<Faq_Cate_Model>>
    {
    }
    public class Faq_Request : baseRequest
    {
        // Properties
        public int FC_ID { get; set; }
    }
    public class Faq_Response : baseResponse<List<Faq_Model>>
    {
    }
    public class Faqs_Request : baseRequest
    {
    }
    public class Faqs_Response : baseResponse<List<Faqs_Model>>
    {
    }
}