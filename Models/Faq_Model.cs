using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Models
{
    public class Faq_Cate_Model
    {
        // Properties
        public int FC_ID { get; set; }

        public string FC_NAME { get; set; }

        public string FC_DES { get; set; }

        public string FC_ALIAS { get; set; }
    }



    public class Faq_Model
    {
        // Properties
        public int F_ID { get; set; }

        public string F_QUESTION { get; set; }

        public string F_ANSWER { get; set; }
    }
    public class Faqs_Model
    {
        // Properties
        public List<Faq_Model> Faq_Model { get; set; }

        public Faq_Cate_Model Faq_Cate_Model { get; set; }
    }



}