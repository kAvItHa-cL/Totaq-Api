using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TotaqWebAPI.DAL;

namespace TotaqWebAPI.Controllers
{
    public class CheckExistLoanController  : ApiController
    {
        LoanDetailsDal objLoan = new LoanDetailsDal();
        [HttpGet]
        public int GetDetails (string PhoneNumber)
        {
            try
            {
                return objLoan.VerifyLoan(PhoneNumber);
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "ExistLoan-GET";
                int error = objError.InsertError(model);
                return 400;
            }
        }
    }
}
