using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class PaymentDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        public int UpdatePayment (LoanDetail LoanModel)
        {
            try
            {
                var loanexists = dbContext.LoanDetails.Where(l => l.PhoneNumber == LoanModel.PhoneNumber && l.LoanStatus == "Active").FirstOrDefault();
                if (loanexists == null)
                {
                    return 300;
                }
                else
                {
                    loanexists.PaymentDate = LoanModel.PaymentDate;
                    loanexists.PaymentReferenceNo = LoanModel.PaymentReferenceNo;
                    dbContext.Entry(loanexists).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return 100;
                }

            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Payment";
                int error = objError.InsertError(model);
                return 400;
            }
        }
    }
}