using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Models
{
    public class Inquiries_Model
    {
        // Properties
        public int IQ_ID { get; set; }

        public DateTime IQ_DATE { get; set; }

        public int WD_ID { get; set; }

        public string IQ_MESSENGER { get; set; }

        public int U_ID { get; set; }

        public float IQ_TOTAL_AMOUT { get; set; }

        public float IQ_TOWARD { get; set; }

        public float IQ_DEPOSIT { get; set; }

        public DateTime IQ_DUE_DATE { get; set; }

        public string IQ_NAME { get; set; }

        public string IQ_MAIL { get; set; }

        public string IQ_PHONE { get; set; }

        public int NA_ID { get; set; }

        public float IQ_BUGET { get; set; }

        public DateTime IQ_WEDDING_DATE { get; set; }

        public int IQ_STATUS { get; set; }

        public int IQ_PROGRESS { get; set; }

        public string WD_NAME { get; set; }
    }



}