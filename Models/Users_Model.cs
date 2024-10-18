using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Models
{
    public class Users_Model
    {
        // Properties
        public int U_ID { get; set; }

        public string U_NAME { get; set; }

        public string U_MAIL { get; set; }

        public string U_PASS { get; set; }

        public string U_PHONE { get; set; }

        public int NA_ID { get; set; }

        public float U_BUGET { get; set; }

        public DateTime U_WEDDING_DATE { get; set; }

        public string U_AVATAR { get; set; }

        public int U_STATUS { get; set; }

        public int CODE { get; set; }

        public string NA_NAME { get; set; }
    }
    public class USERS_FAVORITE
    {
        // Properties
        public int UF_ID { get; set; }

        public int WD_ID { get; set; }
    }
    public class USERS_NATIONALITY
    {
        // Properties
        public int NA_ID { get; set; }

        public string NA_NAME { get; set; }

        public string NA_ALIAS { get; set; }
    }
}