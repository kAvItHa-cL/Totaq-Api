using Newtonsoft.Json;
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
    public class LoanDetailsController : ApiController
    {
        LoanDetailsDal objLoan = new LoanDetailsDal();
        LoanDetail LoanModel = new LoanDetail();

        [HttpPost]
        public int LoanDetails(string PhoneNumber, decimal LoanAmount, int InterestRate, decimal ProcessingFee, decimal LatePayment, string Duration, string LoanStatus, string DueDate)
        {
            try
            {
                LoanModel.PhoneNumber = PhoneNumber;
                LoanModel.LoanStatus = LoanStatus;
                LoanModel.LoanAmount = LoanAmount;
                LoanModel.InterestRate = InterestRate;
                LoanModel.ProcessFee = ProcessingFee;
                LoanModel.LatePaymentCharges = LatePayment;
                LoanModel.Duration = Duration;
                //LoanModel.DateOfLoan = Convert.ToDateTime(DateOfLoan);

                //LoanModel.PaymentDate = Convert.ToDateTime(PaymentDate);
                //LoanModel.LoanTransactionNo = "LT111";
                DateTime today = DateTime.Now;
                LoanModel.DueDate = today.AddDays(+14);
                return objLoan.SaveLoanDetails(LoanModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "LoanDetails-POST";
                int error = objError.InsertError(model);

                return 400;
            }
        }

        [HttpGet]
        public string GetDetails (string PhoneNumber)
        {
            try
            {
                LoanDetail model = new LoanDetail();
                LoanDetail LoanRecords = objLoan.FetchLoan(PhoneNumber);
                if (LoanRecords == null)
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
                    model.DueDate = DateTime.Now;
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
                model.Source = "LoanDetails-GET";
                int error = objError.InsertError(model);
                return "400";
            }

        }
    }
}
