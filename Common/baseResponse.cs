using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
    public class baseResponse<T> : baseModel
    {
        public baseResponse()
        {
            Code = -1;
            error = "";
            result = "";
            //DataList = new List<T>();
            DataList = DataList;
        }
        //List<T> DataList { get; set; }
        public T DataList { get; set; }
    }
    public class baseResponseSingle : baseModel
    {
        public baseResponseSingle()
        {
            Code = -1;
            error = "";
            result = "";
        }
    }
}