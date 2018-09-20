using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TotaqWebAPI.DAL;
using TotaqWebAPI.Models;

namespace TotaqWebAPI.Controllers
{
    public class DocumentsController : ApiController
    {
        DocumentsDal objDocuments = new DocumentsDal();
        DocumentsModel model = new DocumentsModel();

        [HttpGet]
        public string GetDetails(string PhoneNumber)
        {
            try
            {
                AdharCardDocument doc1 = objDocuments.FetchAdharCard(PhoneNumber);
                PANCardDocument doc2  = objDocuments.FetchPANCard(PhoneNumber);
                IDCardDocument doc3 = objDocuments.FetchIDCard(PhoneNumber);
                PaySlipDocument doc4 = objDocuments.FetchPaySlip(PhoneNumber);
                BankstatementDocument doc5 = objDocuments.FetchBankStatement(PhoneNumber);
                SelfieDocument doc6 = objDocuments.FetchSelfie(PhoneNumber);
                SignatureDocument doc7 = objDocuments.FetchSignature(PhoneNumber);
               string DefaultURL= "https://firebasestorage.googleapis.com/v0/b/totaq-6155d.appspot.com/o/noimage.png?alt=media&token=fe4a3c0f-e6f9-497f-827d-a9e0906ccf6b";
                if (doc1==null)
                {
                    model.AdharCard = DefaultURL;
                }
                else
                {
                    model.AdharCard = doc1.AdharCardUrl;
                }
                if (doc2 == null)
                {
                    model.PANCard = DefaultURL;
                }
                else
                {
                    model.PANCard = doc2.PANCardUrl;
                }
            
                if (doc3 == null)
            {
                model.IDCard = DefaultURL;
            }
            else
            {
                model.IDCard = doc3.IDCardUrl;
            }

                if (doc4 == null)
                {
                    model.PaySlip = DefaultURL;
                }
                else
                {
                    model.PaySlip = doc4.PaySlipUrl;
                }
                if (doc5 == null)
                {
                    model.BankStatement = DefaultURL;
                }
                else
                {
                    model.BankStatement = doc5.BankstatementDocumentUrl;
                }

                if (doc6 == null)
                {
                    model.Selfie = DefaultURL;
                }
                else
                {
                    model.Selfie = doc6.SelfieUrl;
                }
                if (doc7 == null)
                {
                    model.Signature = DefaultURL;
                }
                else
                {
                    model.Signature = doc7.SignatureUrl;
                }
                string jsonResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                return jsonResult;

            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Documents-Get";
                int error = objError.InsertError(model);
                return "400";
            }
        }

    }

}
