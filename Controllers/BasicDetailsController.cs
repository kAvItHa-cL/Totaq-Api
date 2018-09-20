using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TotaqWebAPI.DAL;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace TotaqWebAPI.Controllers
{
    public class BasicDetailsController : ApiController
    {
        BasicDetailsDal objBasic = new BasicDetailsDal();
        BasicDetail BasicModel = new BasicDetail();
        RegisterDal objRegister = new RegisterDal();
        Register RegisterModel  = new Register();
        OneTimeFee FeeModel = new OneTimeFee();
        OneTimeFeeDal objFee  = new OneTimeFeeDal();
        
        [HttpPost]
        public int BasicDetails (string PhoneNumber,string FullName,string EmailId,string PANCard,string AdharCard,string KYCStatus,string UserStatus)
        {
            try
            {
                RegisterModel.PhoneNumber = PhoneNumber;
                RegisterModel.Date = DateTime.Now;
                RegisterModel.Status = UserStatus;
                //RegisterModel.CRN = "1"; //auto increment in db 

                BasicModel.FullName = FullName;
                BasicModel.EmailId = EmailId;
                BasicModel.PhoneNumber = PhoneNumber;
                BasicModel.PANCard = PANCard;
                BasicModel.AdharCard = AdharCard;
                BasicModel.KYCStatus = KYCStatus;

                FeeModel.PhoneNumber = PhoneNumber;
                FeeModel.Status = "Pending";

                int response = objRegister.SaveUser(RegisterModel);
                objFee.SaveOneTimeFee(FeeModel);
                return objBasic.SaveBasicDetails(BasicModel);
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "BasicDetails-POST";
                int error = objError.InsertError(model);
                return 400;
            }

        }

        [HttpGet]
        public string GetDetails    (string PhoneNumber)
        {
            try
            {
                BasicDetail model = new BasicDetail();
                BasicDetail BasicRecords  = objBasic.FetchBasicDetails(PhoneNumber);
                if (BasicRecords == null)
                {
                    return "300";
                }
                else
                {
                    model.AdharCard = BasicRecords.AdharCard;
                    model.BasicDetailsId = BasicRecords.BasicDetailsId;
                    model.EmailId = BasicRecords.EmailId;
                    model.FullName = BasicRecords.FullName;
                    model.KYCStatus = BasicRecords.KYCStatus;
                    model.PANCard = BasicRecords.PANCard;
                    model.PhoneNumber = BasicRecords.PhoneNumber;

                    string jsonResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                    return jsonResult;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "BasicDetails-GET";
                int error = objError.InsertError(model);
                return "400";
            }

        }

    }
}
