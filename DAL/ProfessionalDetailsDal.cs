using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class ProfessionalDetailsDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        public ProfessionalDetail FetchProfessionalDetails(string PhoneNumber)
        {
            try
            {
                var professionalquery = dbContext.ProfessionalDetails.Where(p => p.PhoneNumber == PhoneNumber).FirstOrDefault();
                return professionalquery;
            }
            catch(Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch Professional Details";
                int error = objError.InsertError(model);
                throw;
            }
        }

        public int SaveProfessionalDetails(ProfessionalDetail ProfessionModel)
        {
            try
            {
                var existscount = dbContext.ProfessionalDetails.Where(b => b.PhoneNumber == ProfessionModel.PhoneNumber).FirstOrDefault();
                if (existscount == null)
                {
                    dbContext.ProfessionalDetails.Add(ProfessionModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                { return 200; }
            }
            catch(Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Save Professional Details";
                int error = objError.InsertError(model);
                return 400;
            }
        }
    }
}