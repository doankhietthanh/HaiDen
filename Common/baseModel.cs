using System.Web;
namespace Common
{
    public class baseModel
    {
        public baseModel()
        {

            Code = 0;
            result = "";
            error = "";
            //DataListChild = new List<T>();
            //DataList = new List<DTO>();
            //ROWCOUNTS = 0;
        }
        public int Code { get; set; }
        public string result { get; set; }
        public string error { get; set; }
        //public List<T> DataListChild { get; set; }
        //public List<T> DataList { get; set; }
        //public int ROWCOUNTS { get; set; }
    }
    public class baseMeta
    {
        public baseMeta() {
            Title = "";
            Des = "";
            Key = "";
            Robot = "index,follow";
            Url = HttpContext.Current.Request.Url.AbsoluteUri;
            Image = "";
        }
        public string Title { get; set; }
        public string Des { get; set; }
        public string Key { get; set; }
        public string Robot { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
    }
}