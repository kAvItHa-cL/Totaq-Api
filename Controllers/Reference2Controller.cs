using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TotaqWebAPI.DAL;

namespace TotaqWebAPI.Controllers
{
    public class Reference2Controller : ApiController
    {

        ReferenceDetailsDal objReference = new ReferenceDetailsDal();
        ReferenceDetail ReferenceModel = new ReferenceDetail();

        [HttpPost]
        public int Reference2 (string Reference2, string Name2 , string PhoneNumber)
        {
            try
            {
                ReferenceModel.PhoneNumber = PhoneNumber;
                ReferenceModel.Reference2 = Reference2;
                ReferenceModel.ReferenceName2 = Name2;
                return objReference.SaveReferenceDetails2(ReferenceModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Reference2-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }
    }
}
