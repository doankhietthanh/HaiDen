using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Admin.App_Code
{
    public class DTO
    {
        //-------- ADMIN ------//
        private int _AD_ID;
        private string _AD_MAIL;
        private string _AD_PASS;
        private string _AD_NAME;
        private string _AD_IMG;

        //-------- ADMIN RIGHTS ------//
        private int _AR_RIGHTS;
        private int _AR_ID;

        //-------- BANNERS ------//
        private int _BN_ID;
        private string _BN_TITLE;
        private string _BN_DES;
        private string _BN_LINK;
        private string _BN_IMG;

        //-------- BRIDE_STORIES ------//
        private int _BS_ID;
        private string _BS_NAME;
        private string _BS_DES;
        private string _BS_DETAIL;
        private string _BS_IMG;
        private DateTime _BS_DATE;

        //-------- BRIDE_STORIES CATE ------//
        private int _BSC_ID;
        private string _BSC_DES;  
        private string _BSC_IMG;


        //-------- COLLECTIONS ------//
        private int _CO_ID;
        private string _CO_NAME;
        private string _CO_DES;
        private string _CO_SEASON;
        private string _CO_IMG;
        private string _CO_IMG_1;

        //-------- FAQS ------//
        private int _F_ID;
        private string _F_QUESTION;
        private string _F_ANSWER;

        //-------- FAQS_CATE ------//
        private int _FC_ID;
        private string _FC_NAME;
        private string _FC_DES;
        private string _FC_ALIAS;

        //-------- INFO ------//
        private int _IF_ID;
        private string _IF_NAME;
        private string _IF_DES;
        private string _IF_ALIAS;
        private int _IF_TYPE;

        //-------- NEWS ------//
        private int _N_ID;
        private string _N_NAME;
        private string _N_DES;
        private string _N_DETAIL;
        private string _N_IMG;
        private DateTime _N_DATE;

        //-------- PAGES ------//
        private int _PA_ID;
        private string _PA_NAME;
        private string _PA_ALIAS;

        //-------- USERS ------//
        private int _U_ID;
        private string _U_NAME;
        private string _U_MAIL;
        private string _U_PASS;
        private string _U_PHONE;
        private string _U_NATIONAL;
        private float _U_BUGET;
        private DateTime _U_WEDDING_DATE;
        private string _U_AVATAR;
        private int _U_STATUS;

        //-------- USERS_FAVOURITE ------//
        private int _UF_ID;

        //-------- INQUIRY ------//

        private int _IQ_ID;
        private DateTime _IQ_DATE;
        private string _IQ_MESSENGER;
        private float _IQ_TOTAL_AMOUT;
        private float _IQ_TOWARD;
        private float _IQ_DEPOSIT;
        private DateTime _IQ_DUE_DATE;
        private string _IQ_NAME;
        private string _IQ_MAIL;
        private string _IQ_PHONE;
        private float _IQ_BUGET;
        private DateTime _IQ_WEDDING_DATE;
        private int _IQ_STATUS;
        private int _IQ_PROGRESS;

        //-------- WEDDING_DRESS ------//
        private int _WD_ID;
        private string _WD_NAME;
        private string _WD_DES;
        private float _WD_PRICE;

        //-------- WEDDING_DRESS IMG ------//
        private int _WDI_ID;
        private string _WDI_NAME;
        private string _WDI_FILE;

        //-------- ORDER PROCESS ------//
        private int _OP_ID;
        private string _OP_DES;
        private string _OP_DETAIL;
        private string _OP_IMG;

        //-------- NATIONALITY ------//
        private int _NA_ID;
        private string _NA_NAME;
        private string _NA_ALIAS;

        //-------- ABOUT US ------//
        private int _AU_ID;
        private string _AU_NAME;
        private string _AU_DETAIL;
        private string _AU_IMG;
        private string _AU_TITLE;



        public int AD_ID { get; set; }
        public string AD_MAIL { get; set; }
        public string AD_PASS { get; set; }
        public string AD_NAME { get; set; }
        public string AD_IMG { get; set; }
        public int AR_RIGHTS { get; set; }
        public int AR_ID { get; set; }
        public int BN_ID { get; set; }
        public string BN_TITLE { get; set; }
        public string BN_DES { get; set; }
        public string BN_LINK { get; set; }
        public string BN_IMG { get; set; }
        public int BS_ID { get; set; }
        public string BS_NAME { get; set; }
        public string BS_DES { get; set; }
        public string BS_DETAIL { get; set; }
        public string BS_IMG { get; set; }
        public DateTime BS_DATE { get; set; }
        public int CO_ID { get; set; }
        public string CO_NAME { get; set; }
        public string CO_DES { get; set; }
        public string CO_SEASON { get; set; }
        public string CO_IMG { get; set; }
        public string CO_IMG_1 { get; set; }
        public int F_ID { get; set; }
        public string F_QUESTION { get; set; }
        public string F_ANSWER { get; set; }
        public int FC_ID { get; set; }
        public string FC_NAME { get; set; }
        public string FC_DES { get; set; }
        public string FC_ALIAS { get; set; }
        public int IF_ID { get; set; }
        public string IF_NAME { get; set; }
        public string IF_DES { get; set; }
        public string IF_ALIAS { get; set; }
        public int IF_TYPE { get; set; }
        public int N_ID { get; set; }
        public string N_NAME { get; set; }
        public string N_DES { get; set; }
        public string N_DETAIL { get; set; }
        public string N_IMG { get; set; }
        public DateTime N_DATE { get; set; }
        public int PA_ID { get; set; }
        public string PA_NAME { get; set; }
        public string PA_ALIAS { get; set; }
        public int U_ID { get; set; }
        public string U_NAME { get; set; }
        public string U_MAIL { get; set; }
        public string U_PASS { get; set; }
        public string U_PHONE { get; set; }
        public string U_NATIONAL { get; set; }
        public float U_BUGET { get; set; }
        public DateTime U_WEDDING_DATE { get; set; }
        public string U_AVATAR { get; set; }
        public int U_STATUS { get; set; }
        public int UF_ID { get; set; }      
        public int WD_ID { get; set; }
        public string WD_NAME { get; set; }
        public string WD_DES { get; set; }
        public string WD_PRICE { get; set; }
        public int WDI_ID { get; set; }
        public string WDI_NAME { get; set; }
        public string WDI_FILE { get; set; }
        public int BSC_ID { get; set; }
        public string BSC_DES { get; set; }
        public string BSC_IMG { get; set; }
        public int OP_ID { get; set; }
        public string OP_DES { get; set; }
        public string OP_DETAIL { get; set; }
        public string OP_IMG { get; set; }
        public int NA_ID { get; set; }
        public string NA_NAME { get; set; }
        public string NA_ALIAS { get; set; }
        public int IQ_ID { get; set; }
        public DateTime IQ_DATE { get; set; }
        public string IQ_MESSENGER { get; set; }
        public float IQ_TOTAL_AMOUT { get; set; }
        public float IQ_TOWARD { get; set; }
        public float IQ_DEPOSIT { get; set; }
        public DateTime IQ_DUE_DATE { get; set; }
        public string IQ_NAME { get; set; }
        public string IQ_MAIL { get; set; }
        public string IQ_PHONE { get; set; }
        public float IQ_BUGET { get; set; }
        public DateTime IQ_WEDDING_DATE { get; set; }
        public int IQ_STATUS { get; set; }
        public int IQ_PROGRESS { get; set; }
        public int AU_ID { get; set; }
        public string AU_NAME { get; set; }
        public string AU_DETAIL { get; set; }
        public string AU_IMG { get; set; }
        public string AU_TITLE { get; set; }
    }
}