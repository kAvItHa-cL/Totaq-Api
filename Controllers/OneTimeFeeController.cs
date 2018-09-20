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
    public class OneTimeFeeController : ApiController
    {
        OneTimeFeeDal objProcessing = new OneTimeFeeDal();
        OneTimeFee FeeModel = new OneTimeFee();

        [HttpPost]
        public int OneTimeFee (string PhoneNumber,decimal Fee,string Date,string Status,string FeeTransactionNo)
        {
            try
            {
                FeeModel.PhoneNumber = PhoneNumber;
                FeeModel.Date = Convert.ToDateTime(Date);
                FeeModel.Fee = Fee;
                //FeeModel.Status = Status;
                FeeModel.FeeTransactionNo = FeeTransactionNo;
                return objProcessing.SaveOneTimeFee(FeeModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "OneTImeFee-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }
        [HttpGet]
        public string GetDetails(string PhoneNumber)
        {
            try
            {
                OneTimeFee model = new OneTimeFee();
                OneTimeFee FeeRecords = objProcessing.FetchFeeDetails(PhoneNumber);
                if (FeeRecords == null)
                {
                    return "300";
                }
                else
                {
                    model.FeeTransactionNo = FeeRecords.FeeTransactionNo;
                    model.Date = FeeRecords.Date;
                    model.Status = FeeRecords.Status;
                    model.OneTimeFeeID = FeeRecords.OneTimeFeeID;
                    model.PhoneNumber = FeeRecords.PhoneNumber;
                    model.Fee = FeeRecords.Fee;

                    string jsonResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                    return jsonResult;
                }

            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "OneTimeFee-Get";
                int error = objError.InsertError(model);
                return "400";
            }
        }
        }
    }
