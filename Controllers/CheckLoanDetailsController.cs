using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TotaqWebAPI.DAL;

namespace TotaqWebAPI.Controllers
{
    public class CheckLoanDetailsController : ApiController
    {
        LoanDetailsDal objLoan = new LoanDetailsDal();
        LoanDetail model = new LoanDetail();
        [HttpGet]
        public string GetDetails (string PhoneNumber)
        {
            try
            {
              LoanDetail LoanRecords =  objLoan.FetchLoan(PhoneNumber);
                if(LoanRecords == null)
                {
                    model.LoanDetailsId = 0;
                    model.PhoneNumber = "";
                    model.LoanAmount = 0;
                    model.LoanStatus = "";
                    model.LoanTransactionNo = "";
                    model.InterestRate = 0;
                    model.LatePaymentCharges = 0;
                    model.ProcessFee = 0;
                    model.Duration = "";
                    model.DateofLoan = DateTime.Now;
                    model.DueDate =DateTime.Now;
                    model.PaymentDate = DateTime.Now;
                    model.PaymentReferenceNo = "";

                    string jsonResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                    return jsonResult;
                }
                   
                else
                {
                    model.LoanDetailsId = LoanRecords.LoanDetailsId;
                    model.PhoneNumber = LoanRecords.PhoneNumber;
                    model.LoanAmount = LoanRecords.LoanAmount;
                    model.LoanStatus = LoanRecords.LoanStatus;
                    model.LoanTransactionNo = LoanRecords.LoanTransactionNo;
                    model.InterestRate = LoanRecords.InterestRate;
                    model.LatePaymentCharges = LoanRecords.LatePaymentCharges;
                    model.ProcessFee = LoanRecords.ProcessFee;
                    model.Duration = LoanRecords.Duration;
                    model.DateofLoan = LoanRecords.DateofLoan;
                    model.DueDate = LoanRecords.DueDate;
                    model.PaymentDate = LoanRecords.PaymentDate;
                    model.PaymentReferenceNo = LoanRecords.PaymentReferenceNo;

                    string jsonResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                    return jsonResult;
                }
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "CheckLoanDetails-GET";
                int error = objError.InsertError(model);
                return "400";
            }
        }
    }
}
