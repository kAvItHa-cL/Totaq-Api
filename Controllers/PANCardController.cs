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
    public class PANCardController : ApiController
    {
        DocumentsDal objDocuments = new DocumentsDal();
        PANCardDocument PANCardModel = new PANCardDocument();
        
        [HttpPost]
        public int PANCard(string PhoneNumber, string PANCardUrl, string token)
        {
            try
            {
                PANCardModel.PhoneNumber = PhoneNumber;
                PANCardModel.PANCardUrl = PANCardUrl + "&token=" + token;
                return objDocuments.UpdatePANCard(PANCardModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "PANCard-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }
        [HttpGet]
        public string GetDetails (string PhoneNumber)
        {
            try
            {
                PANCardDocument model = new PANCardDocument();
                PANCardDocument Documents = objDocuments.FetchPANCard(PhoneNumber);
                if (Documents == null)
                {
                    return "300";
                }
                else
                {
                    model.PANCardId = Documents.PANCardId;
                    model.PANCardUrl = Documents.PANCardUrl;
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
                model.Source = "PanCard-Get";
                int error = objError.InsertError(model);
                return "400";
            }

        }
    }
}
