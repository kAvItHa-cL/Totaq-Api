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
    public class SelfieController : ApiController
    {
        DocumentsDal objDocuments = new DocumentsDal();
        SelfieDocument SelfieModel = new SelfieDocument();
        [HttpPost]
        public int Selfie(string PhoneNumber,string SelfieUrl, string token)
        {
            try
            {
                SelfieModel.PhoneNumber = PhoneNumber;
                SelfieModel.SelfieUrl = SelfieUrl + "&token=" + token;
                return objDocuments.UpdateSelfie(SelfieModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Selfie-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }
        [HttpGet]
        public string GetDetails(string PhoneNumber)
        {
            try
            {
                SelfieDocument model = new SelfieDocument();
                SelfieDocument Documents = objDocuments.FetchSelfie(PhoneNumber);
                if (Documents == null)
                {
                    return "300";
                }
                else
                {
                    model.SelfieId = Documents.SelfieId;
                    model.SelfieUrl = Documents.SelfieUrl;
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
                model.Source = "Selfie-Get";
                int error = objError.InsertError(model);
                return "400";
            }
        }
        }
    }

