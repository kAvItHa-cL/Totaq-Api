using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class ContactUsDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        public int SaveEnquiry(UserContact model)
        {
            try
            {
                dbContext.UserContacts.Add  (model);
                dbContext.SaveChanges();

                return 100;
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog errorModel = new ErrorLog();
                errorModel.InnerException = ex.InnerException.InnerException.Message.ToString();
                errorModel.Source = "ContactUs-Save";
                int error = objError.InsertError(errorModel);
                return 400;
            }
        }
    }
}