using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TotaqWebAPI.DAL;

namespace TotaqWebAPI.Controllers
{
    public class PaymentController : ApiController
    {
        LoanDetail LoanModel = new LoanDetail();
        PaymentDal objPayment  =new  PaymentDal();
        
        [HttpPost]
        public int Payment(string PhoneNumber,string ReferenceNo,string Date)
        {
            try
            {
                LoanModel.PaymentReferenceNo = ReferenceNo;
                LoanModel.PaymentDate = Convert.ToDateTime(Date);
                LoanModel.PhoneNumber = PhoneNumber;
                return objPayment.UpdatePayment(LoanModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Payment-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }
    }
}
