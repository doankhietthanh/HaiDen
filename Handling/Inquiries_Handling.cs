using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{
    public class Inquiries_Get_Request : baseRequest
    {
        // Methods
        public Inquiries_Get_Request()
        {
            this.U_ID = -1;
        }

        // Properties
        public int U_ID { get; set; }
    }
    public class Inquiries_Get_Response : baseResponse<List<Inquiries_Model>>
    {
    }
    public class Inquiries_Request : baseRequest
    {
        // Methods
        public Inquiries_Request()
        {
            this.IQ_ID = -1;
            this.IQ_DATE = DateTime.Now;
            this.U_ID = -1;
            this.IQ_TOTAL_AMOUT = 0f;
            this.IQ_TOWARD = 0;
            this.IQ_DEPOSIT = 0;
            this.IQ_DUE_DATE = DateTime.Now;
            this.IQ_STATUS = 0;
            this.IQ_PROGRESS = 0;
        }

        // Properties
        public int IQ_ID { get; set; }

        public DateTime IQ_DATE { get; set; }

        public int WD_ID { get; set; }

        public string IQ_MESSENGER { get; set; }

        public int U_ID { get; set; }

        public float IQ_TOTAL_AMOUT { get; set; }

        public int IQ_TOWARD { get; set; }

        public int IQ_DEPOSIT { get; set; }

        public DateTime IQ_DUE_DATE { get; set; }

        public string IQ_NAME { get; set; }

        public string IQ_MAIL { get; set; }

        public string IQ_PHONE { get; set; }

        public int NA_ID { get; set; }

        public float IQ_BUGET { get; set; }

        public DateTime IQ_WEDDING_DATE { get; set; }

        public int IQ_STATUS { get; set; }

        public int IQ_PROGRESS { get; set; }
    }
    public class Inquiries_Response : baseResponseSingle
    {
    }





}