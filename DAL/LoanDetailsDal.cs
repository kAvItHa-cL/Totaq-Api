using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class LoanDetailsDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        public LoanDetail FetchLoanDetails(string PhoneNumber)
        {
            try {
                var loanquery = dbContext.LoanDetails.Where(l => l.PhoneNumber == PhoneNumber).FirstOrDefault();
               return loanquery;
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch LoanDetails";
                int error = objError.InsertError(model);
                throw;
            }
        }
        public int SaveLoanDetails(LoanDetail LoanModel)
        {
            try
            {
                var loanexists = dbContext.LoanDetails.Where(l => l.PhoneNumber == LoanModel.PhoneNumber && l.LoanStatus == "Active").FirstOrDefault();
                if (loanexists == null)
                { 
                dbContext.LoanDetails.Add(LoanModel);
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
                model.Source = "SaveLoanDetails";
                int error = objError.InsertError(model);
                return 400;
                
            }
        }
        
        public int VerifyLoan(string PhoneNumber)
        {
            try
            {
               string  PhoneNo  = PhoneNumber;
                var loanexists = dbContext.LoanDetails.Where(l => l.PhoneNumber == PhoneNo && (l.LoanStatus == "Active" || l.LoanStatus=="Pending")).Count();
                if (loanexists == 0)
                {
                    return 300;
                }
                else
                { return 200; }

            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Verify Loan";
                int error = objError.InsertError(model);
                throw;
            }
        }

        public LoanDetail FetchLoan(string PhoneNumber)
        {
            try
            {
                var loanquery = dbContext.LoanDetails.Where(l => l.PhoneNumber == PhoneNumber && (l.LoanStatus == "Active" || l.LoanStatus=="Pending")).FirstOrDefault();
                  
                  return loanquery;
                                           
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch Loan";
                int error = objError.InsertError(model);
                throw;
            }
        }

    }
}