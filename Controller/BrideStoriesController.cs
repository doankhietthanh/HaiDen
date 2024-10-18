using HaiDen.Handling;
using HaiDen.Models;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class BrideStoriesController
    {
        // Fields
        private BrideStories_Repository Repository = new BrideStories_Repository();

        // Methods
        public BrideStories_Response LOAD_BRIDESTORIES(BrideStories_Request req)
        {
            BrideStories_Response response = new BrideStories_Response();
            try
            {
                response = this.Repository.LOAD_BRIDESTORIES(req);
            }
            catch (Exception exception1)
            {
                response.Code = 0x1f5;
                response.error = exception1.Message;
            }
            return response;
        }

        public BrideStoriesCate_Response LOAD_BRIDESTORIES_CATE(BrideStoriesCate_Request req)
        {
            BrideStoriesCate_Response response = new BrideStoriesCate_Response();
            try
            {
                response = this.Repository.LOAD_BRIDESTORIES_CATE(req);
                BrideStories_Request request = new BrideStories_Request();
                if (this.Repository.LOAD_BRIDESTORIES(request).DataList.Count > 0)
                {
                    foreach (BrideStoriesCate_Model model in response.DataList)
                    {
                        model.IS_DATA = true;
                    }
                }
            }
            catch (Exception exception1)
            {
                response.Code = 0x1f5;
                response.error = exception1.Message;
            }
            return response;
        }
    }



}