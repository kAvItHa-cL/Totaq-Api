using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TotaqWebAPI.DAL;

namespace TotaqWebAPI.Controllers
{
    public class ContactUsController : ApiController
    {
        ContactUsDal objContact = new ContactUsDal();
        UserContact model = new UserContact();
        [HttpPost]
        public int ContactUs(string PhoneNumber, string Message)
        {
            try
            {
                model.PhoneNumber = PhoneNumber;
                model.Message = Message;
                model.Date = DateTime.Now;
                return objContact.SaveEnquiry(model);
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "ContactUs-POST";
                int error = objError.InsertError(model);
                return  400;
            }

        }
    }
}
