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
    public class IDCardController : ApiController
    {
        DocumentsDal objDocuments = new DocumentsDal();
        IDCardDocument IDCardModel  = new IDCardDocument();

        [HttpPost]
        public int IDCard (string PhoneNumber, string IdCardUrl, string token)
        {
            try
            {
                IDCardModel.PhoneNumber = PhoneNumber;
                IDCardModel.IDCardUrl = IdCardUrl + "&token=" + token;
                return objDocuments.UpdateIDCard(IDCardModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "IDCard-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }
        [HttpGet]
        public string GetDetails (string PhoneNumber)
        {
            try
            {
                IDCardDocument model = new IDCardDocument();
                IDCardDocument Documents = objDocuments.FetchIDCard(PhoneNumber);
                if (Documents == null)
                {
                    return "300";
                }
                else
                {
                    model.IdCardNo = Documents.IdCardNo;
                    model.IDCardUrl = Documents.IDCardUrl;
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
                model.Source = "IDCard-GET";
                int error = objError.InsertError(model);
                return "400";
            }

        }

    }
}
