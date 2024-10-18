using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
    public class baseRequest
    {
        public baseRequest()
        {
            PageIndex = 1;
            PageSize = 5;
            Lang = "vi-VN"; //CommonHelper.getLanguage();
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string AttType { get; set; }
        public string Lang { get; set; }
    }
}