using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Models
{
    public class WeddingDress_Model
    {
        // Properties
        public int WD_ID { get; set; }

        public string WD_NAME { get; set; }

        public string WD_DES { get; set; }

        public string WD_DETAIL { get; set; }

        public string IMG { get; set; }

        public string WD_PRICE { get; set; }

        public string CO_NAME { get; set; }

        public string CO_SEASON { get; set; }

        public int IS_FAV { get; set; }
    }



    public class WeddingDressImg_Model
    {
        // Properties
        public int WDI_ID { get; set; }

        public string WDI_NAME { get; set; }

        public string WDI_FILE { get; set; }
    }



}