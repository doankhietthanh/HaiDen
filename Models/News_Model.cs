using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Models
{
    public class News_Model
    {
        public int N_ID { get; set; }
        public string N_NAME { get; set; }
        public string N_DES { get; set; }
        public string N_DETAIL { get; set; }
        public string N_IMG { get; set; }
        public DateTime N_DATE { get; set; }
    }
}