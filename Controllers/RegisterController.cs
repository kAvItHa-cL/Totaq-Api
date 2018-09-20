using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TotaqWebAPI.DAL;


namespace TotaqWebAPI.Controllers
{
    public class RegisterController : ApiController
    {
        RegisterDal objRegister = new RegisterDal();
        Register RegisterModel = new Register();

        [HttpPost]
        public int Register(string PhoneNumber)
        {
            try
            {
                return objRegister.CheckUser(PhoneNumber);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Register-CheckUser";
                int error = objError.InsertError(model);
                return 400;
            }


        }  

    }
}
