using HaiDen.Handling;
using HaiDen.Models;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class FaqController
    {
        // Fields
        private Faq_Repository Repository = new Faq_Repository();

        // Methods
        public Faqs_Response LOAD_FAQS(Faqs_Request req)
        {
            Faqs_Response response = new Faqs_Response();
            Faq_Response response2 = new Faq_Response();
            Faq_Cate_Response response3 = new Faq_Cate_Response();
            List<Faqs_Model> list = new List<Faqs_Model>();
            Faq_Cate_Request request1 = new Faq_Cate_Request();
            request1.Lang = req.Lang;
            Faq_Cate_Request request = request1;
            try
            {
                response3 = this.Repository.LOAD_FAQ_CATE(request);
                if ((response3.Code == 0) || (response3.DataList.Count > 0))
                {
                    foreach (Faq_Cate_Model model in response3.DataList)
                    {
                        Faqs_Model item = new Faqs_Model();
                        Faq_Request request3 = new Faq_Request();
                        request3.FC_ID = model.FC_ID;
                        Faq_Request request2 = request3;
                        response2 = this.Repository.LOAD_FAQ(request2);
                        if ((response2.Code == 0) && (response2.DataList.Count > 0))
                        {
                            item.Faq_Cate_Model = model;
                            item.Faq_Model = response2.DataList;
                        }
                        list.Add(item);
                    }
                    response.DataList = list;
                    response.Code = 0;
                    response.result = 0.ToString();
                }
            }
            catch (Exception exception1)
            {
                response.Code = 1;
                response.error = exception1.Message;
            }
            return response;
        }
    }



}