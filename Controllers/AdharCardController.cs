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
    public class AdharCardController : ApiController
    {
        AdharCardDocument AdharModel = new AdharCardDocument();
        DocumentsDal objDocuments = new DocumentsDal();

        [HttpPost]
        public int AdharCard (string PhoneNumber,string AdharCardUrl ,string token)
        {
            try
            {
                AdharModel.PhoneNumber = PhoneNumber;
                AdharModel.AdharCardUrl = AdharCardUrl+"&token="+token;
                return objDocuments.UpdateAdharCard(AdharModel);
            }
            catch(Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "AdharCard-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }

        [HttpGet]
        public string GetDetails(string PhoneNumber)
        {
            try { 
            AdharCardDocument model = new AdharCardDocument();
            AdharCardDocument Documents = objDocuments.FetchAdharCard(PhoneNumber);
                if (Documents == null)
                {
                    return "300";
                }
                else
                {
                    model.AdharCardId = Documents.AdharCardId;
                    model.AdharCardUrl = Documents.AdharCardUrl;
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
                model.Source = "AdharCard-GET";
                int error = objError.InsertError(model);
                return "400";
            }

        }
    }
}
