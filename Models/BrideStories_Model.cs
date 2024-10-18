using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Models
{
    public class BrideStoriesCate_Model
    {
        // Properties
        public int BSC_ID { get; set; }

        public string BSC_DES { get; set; }

        public string BSC_IMG { get; set; }

        public bool IS_DATA { get; set; }
    }
    public class BrideStories_Model
    {
        // Properties
        public int BS_ID { get; set; }

        public string BS_NAME { get; set; }

        public string BS_DES { get; set; }

        public string BS_DETAIL { get; set; }

        public string BS_IMG { get; set; }

        public DateTime BS_DATE { get; set; }
    }



}