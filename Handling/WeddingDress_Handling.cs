using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{
    public class WeddingDress_Request : baseRequest
    {
        public WeddingDress_Request()
        {
            WD_ID = -1;
            CO_NAME = "-1";
            this.U_MAIL = "-1";
        }
        public int WD_ID { get; set; }
        public string CO_NAME { get; set; }
        public string U_MAIL { get; set; }
    }
    public class WeddingDress_Response : baseResponse<List<WeddingDress_Model>>
    {
    }

    public class WeddingDressImg_Request : baseRequest
    {
        public WeddingDressImg_Request()
        {
            WD_ID = -1;

        }
        public int WD_ID { get; set; }

    }
    public class WeddingDressImg_Response : baseResponse<List<WeddingDressImg_Model>>
    {
    }
    public class WeddingDressFav_Request : baseRequest
    {
        // Methods
        public WeddingDressFav_Request()
        {
            this.WD_ID = -1;
            this.U_MAIL = "-1";
        }

        // Properties
        public string U_MAIL { get; set; }

        public int WD_ID { get; set; }
    }
    public class WeddingDressFav_Response : baseResponseSingle
    {
    }
    public class WeddingDressFavList_Request : baseRequest
    {
        // Methods
        public WeddingDressFavList_Request()
        {
            this.U_MAIL = "-1";
        }

        // Properties
        public string U_MAIL { get; set; }
    }
    public class WeddingDressFavList_Response : baseResponse<List<WeddingDress_Model>>
    {
    }

}