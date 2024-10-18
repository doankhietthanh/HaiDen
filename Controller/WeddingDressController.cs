using Common;
using HaiDen.Handling;
using HaiDen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaiDen.Controller
{
    public class WeddingDressController
    {
        // Fields
        private WeddingDress_Repository Repository = new WeddingDress_Repository();

        // Methods
        public WeddingDressFav_Response INSERT_FAVOURITE(WeddingDressFav_Request req)
        {
            WeddingDressFav_Response response = new WeddingDressFav_Response();
            try
            {
                req.U_MAIL = CommonHelper.GetUser();
                response = this.Repository.INSERT_FAVOURITE(req);
                if (response.Code == 0)
                {
                    response.result = "Add dress to favourite success!";
                }
                else if ((response.Code == 1) || (response.Code == -1))
                {
                    response.error = "Add dress to favourite unsuccess!";
                }
                else if (response.Code == 2)
                {
                    response.error = "This dress has already in your favorites!";
                }
            }
            catch (Exception exception1)
            {
                response.Code = 0x1f5;
                response.error = exception1.Message;
            }
            return response;
        }

        public WeddingDress_Response LOAD_WEDDINGDRESS(WeddingDress_Request req)
        {
            WeddingDress_Response response = new WeddingDress_Response();
            try
            {
                req.U_MAIL = CommonHelper.GetUser();
                response = this.Repository.LOAD_WEDDINGDRESS(req);
            }
            catch (Exception exception1)
            {
                response.Code = 0x1f5;
                response.error = exception1.Message;
            }
            return response;
        }

        public WeddingDressFavList_Response LOAD_WEDDINGDRESS_FAV(WeddingDressFavList_Request req)
        {
            WeddingDressFavList_Response response = new WeddingDressFavList_Response();
            try
            {
                req.U_MAIL = CommonHelper.GetUser();
                response = this.Repository.LOAD_WEDDINGDRESS_FAV(req);
            }
            catch (Exception exception1)
            {
                response.Code = 0x1f5;
                response.error = exception1.Message;
            }
            return response;
        }

        public WeddingDressImg_Response LOAD_WEDDINGDRESSIMG(WeddingDressImg_Request req)
        {
            WeddingDressImg_Response response = new WeddingDressImg_Response();
            try
            {
                response = this.Repository.LOAD_WEDDINGDRESSIMG(req);
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