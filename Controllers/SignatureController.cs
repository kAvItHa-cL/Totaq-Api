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
    public class SignatureController : ApiController
    {
        DocumentsDal objDocuments = new DocumentsDal();
        SignatureDocument SignatureModel = new SignatureDocument();

        [HttpPost]
        public int Signature(string PhoneNumber,string SignatureUrl, string token)
        {
            try
            {
                SignatureModel.PhoneNumber = PhoneNumber;
                SignatureModel.SignatureUrl = SignatureUrl + "&token=" + token;
                return objDocuments.UpdateSignature(SignatureModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Signature-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }
        [HttpGet]
        public string GetDetails  (string PhoneNumber)
        {
            try
            {
                SignatureDocument model = new SignatureDocument();
                SignatureDocument Documents = objDocuments.FetchSignature(PhoneNumber);
                if (Documents == null)
                {
                    return "300";
                }
                else
                {
                    model.SignatureId = Documents.SignatureId;
                    model.SignatureUrl = Documents.SignatureUrl;
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
                model.Source = "Signature-GET";
                int error = objError.InsertError(model);
                return "400";
            }

        }

    }
}
