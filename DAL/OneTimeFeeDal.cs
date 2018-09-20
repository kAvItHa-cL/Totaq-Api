using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class OneTimeFeeDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        public OneTimeFee FetchFeeDetails  (string PhoneNumber)
        {
            try
            {
                var processingquery = dbContext.OneTimeFees.Where(p => p.PhoneNumber == PhoneNumber).FirstOrDefault();
                return processingquery;
            }
            catch(Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch One Time Fee Details";
                int error = objError.InsertError(model);
                throw;
            }

        }
        public int SaveOneTimeFee(OneTimeFee FeeModel)
        {
            try
            {
                var feexists = dbContext.OneTimeFees.Where(o => o.PhoneNumber == FeeModel.PhoneNumber).FirstOrDefault();
                if (feexists == null)
                {
                    dbContext.OneTimeFees.Add(FeeModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    feexists.Fee = FeeModel.Fee;
                    feexists.Date = FeeModel.Date;
                    feexists.Status = FeeModel.Status;
                    feexists.FeeTransactionNo = FeeModel.FeeTransactionNo;
                    dbContext.Entry(feexists).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return 100;
                    
                }
            }
            catch(Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Update One Time Fee";
                int error = objError.InsertError(model);
                return 400;
            }
        }
    }
}