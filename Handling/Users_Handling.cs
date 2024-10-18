using Common;
using HaiDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Handling
{
    public class Users_Login_Request : baseRequest
    {
        // Methods
        public Users_Login_Request()
        {
            this.U_REMEMBER = false;
        }

        // Properties
        public string U_MAIL { get; set; }

        public string U_PASS { get; set; }

        public bool U_REMEMBER { get; set; }
    }
    public class Users_Login_Response : baseResponse<List<Users_Model>>
    {
    }
    public class Users_Nationality_Request : baseRequest
    {
    }
    public class Users_Nationality_Response : baseResponse<List<USERS_NATIONALITY>>
    {
    }
    public class Users_Request : baseRequest
    {
        // Methods
        public Users_Request()
        {
            this.U_ID = -1;
            this.U_NAME = "-1";
            this.U_MAIL = "-1";
            this.U_PASS = "-1";
            this.U_PHONE = "-1";
            this.NA_ID = -1;
            this.U_BUGET = -1f;
            this.U_WEDDING_DATE = DateTime.Now;
            this.U_AVATAR = "-1";
            this.U_STATUS = 1;
            this.MODE = "SIGNUP";
        }

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

        public string MODE { get; set; }
    }
    public class Users_Response : baseResponse<List<Users_Model>>
    {
    }
}