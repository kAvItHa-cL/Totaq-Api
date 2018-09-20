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
    public class UserReferenceController : ApiController
    {
        ReferenceDetailsDal objReference = new ReferenceDetailsDal();
        ReferenceDetail ReferenceModel = new ReferenceDetail();

        [HttpPost]
        public int UserReference(string PhoneNumber,string Name1,string ReferenceNo1,string Name2,string ReferenceNo2)
        {
            try
            {
                ReferenceModel.PhoneNumber = PhoneNumber;
                ReferenceModel.Reference1 = ReferenceNo1;
                ReferenceModel.ReferenceName1 = Name1;
                ReferenceModel.Reference2 = ReferenceNo2;
                ReferenceModel.ReferenceName2 = Name2;
                return objReference.SaveReferenceDetails(ReferenceModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "UserReference-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        
        }
        [HttpGet]
        public string GetDetails(string PhoneNumber)
        {
            try
            {
                ReferenceDetail model = new ReferenceDetail();
                ReferenceDetail ReferenceRecords = objReference.FetchReferenceDetails(PhoneNumber);
                if (ReferenceRecords == null)
                {
                    return "300";
                }
                else
                {
                    model.ReferenceId = ReferenceRecords.ReferenceId;
                    model.Reference1 = ReferenceRecords.Reference1;
                    model.ReferenceName1 = ReferenceRecords.ReferenceName1;
                    model.Reference2 = ReferenceRecords.Reference2;
                    model.ReferenceName2 = ReferenceRecords.ReferenceName2;
                    model.PhoneNumber = ReferenceRecords.PhoneNumber;

                    string jsonResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                    return jsonResult;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "UserReference-GET";
                int error = objError.InsertError(model);
                return "400";
            }
        }
    }
}
