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
    public class PaySlipController : ApiController
    {
        DocumentsDal objDocuments = new DocumentsDal();
        PaySlipDocument PayslipModel = new PaySlipDocument();

        [HttpPost]
        public int PaySlip(string PhoneNumber, string PaySlipUrl, string token)
            {
            try
            {
                PayslipModel.PhoneNumber = PhoneNumber;
                PayslipModel.PaySlipUrl = PaySlipUrl + "&token=" + token;
                return objDocuments.UpdatePaySlip(PayslipModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "PaySlip-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }
        [HttpGet]
        public string GetDetails  (string PhoneNumber)
        {
            try
            {
                PaySlipDocument model = new PaySlipDocument();
                PaySlipDocument Documents = objDocuments.FetchPaySlip(PhoneNumber);
                if (Documents == null)
                {
                    return "300";
                }
                else
                {
                    model.PayslipId = Documents.PayslipId;
                    model.PaySlipUrl = Documents.PaySlipUrl;
                    model.PhoneNumber = Documents.PhoneNumber;

                    string jsonResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                    return jsonResult;
                }
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "PaySlip-Get";
                int error = objError.InsertError(model);
                return "400";
            }

        }
    }
}
