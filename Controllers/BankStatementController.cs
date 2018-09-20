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
    public class BankStatementController : ApiController
    {
        DocumentsDal objDocuments = new DocumentsDal();
        BankstatementDocument BankStatementModel = new BankstatementDocument();

        [HttpPost]
        public int BankStatement(string PhoneNumber,string BankStatementUrl,string token)
        {
            try
            {
                BankStatementModel.PhoneNumber = PhoneNumber;
                BankStatementModel.BankstatementDocumentUrl = BankStatementUrl + "&token=" + token;
                return objDocuments.UpdateBankStatement(BankStatementModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "BankStatement-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }
        [HttpGet]
        public string GetDetails  (string PhoneNumber)
        {
            try
            {
                BankstatementDocument model = new BankstatementDocument();
                BankstatementDocument Documents = objDocuments.FetchBankStatement(PhoneNumber);
                if (Documents == null)
                {
                    return "300";
                }
                else
                {
                    model.BankStatmentId = Documents.BankStatmentId;
                    model.BankstatementDocumentUrl = Documents.BankstatementDocumentUrl;
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
                model.Source = "BankStatement-GET";
                int error = objError.InsertError(model);
                return "400";
            }

        }
    }
}
