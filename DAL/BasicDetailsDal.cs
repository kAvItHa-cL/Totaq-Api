using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class BasicDetailsDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        public BasicDetail FetchBasicDetails(string PhoneNumber)
        {
            try
            {   
                var basicquery = dbContext.BasicDetails.Where(b => b.PhoneNumber == PhoneNumber).FirstOrDefault();
                return basicquery;
            }
            catch(Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "BasicDetails-Fetch";
                int error = objError.InsertError(model);
                throw;
            }
        }

        public int SaveBasicDetails(BasicDetail BasicModel)
        {
            try
            {
                var existscount = dbContext.BasicDetails.Where(b => b.PhoneNumber == BasicModel.PhoneNumber).FirstOrDefault();
                if (existscount == null)
                {
                    dbContext.BasicDetails.Add(BasicModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else { return 200; }
                
            }
            catch(Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "BasicDetails-Save";
                int error = objError.InsertError(model);
                return 400;
                
            }
           
        }
    }
}