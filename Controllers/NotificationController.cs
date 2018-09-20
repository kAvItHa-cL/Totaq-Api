using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TotaqWebAPI.DAL;

namespace TotaqWebAPI.Controllers
{
    public class NotificationController : ApiController
    {
        List<Notification>model = new List<Notification>();
        NotificationDal objNotify = new NotificationDal();
       List< Notification> Nmodel = new List<Notification>();
        Notification notifyModel = new Notification();

        [HttpGet]
        public string GetDetails(string PhoneNumber)
        {
            
            try
            {
                model = objNotify.FetchNotifications(PhoneNumber);
                foreach (var item in model)
                {
                    notifyModel.NotificationId = item.NotificationId;
                    notifyModel.PhoneNumber = item.PhoneNumber;
                    notifyModel.Title = item.Title;
                    notifyModel.Message = item.Message;
                    notifyModel.Date = item.Date;
                    Nmodel.Add(notifyModel);
                    
                }
                string jsonResult = JsonConvert.SerializeObject(Nmodel, Formatting.Indented);
                return jsonResult;
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Get Notifications";
                int error = objError.InsertError(model);
                return "400";
            }
           


        }
    }
}
