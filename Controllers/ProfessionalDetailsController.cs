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
    public class ProfessionalDetailsController : ApiController
    {
        ProfessionalDetailsDal objProfession = new ProfessionalDetailsDal();
        ProfessionalDetail ProfessionModel = new ProfessionalDetail();

        [HttpPost]
        public int ProfessionalDetails(string PhoneNumber,string CompanyName,decimal MonthlyIncome,string Experience,decimal CurrentEMI,string CompanyAddress,string CompanyEmailId)
        {
            try
            {
                ProfessionModel.PhoneNumber = PhoneNumber;
                ProfessionModel.CompanyName = CompanyName;
                ProfessionModel.CompanyEmailId = CompanyEmailId;
                ProfessionModel.CompanyAddress = CompanyAddress;
                ProfessionModel.YearOfExperience = Experience;
                ProfessionModel.MonthlyIncome = MonthlyIncome;
                ProfessionModel.CurrentEMI = CurrentEMI;
                return objProfession.SaveProfessionalDetails(ProfessionModel);
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "ProfessionalDetails-POST";
                int error = objError.InsertError(model);
                return 400;
            }
        }
        [HttpGet]
        public string GetDetails(string PhoneNumber)
        {
            try
            {
                ProfessionalDetail model = new ProfessionalDetail();
                ProfessionalDetail ProfessionRecord = objProfession.FetchProfessionalDetails(PhoneNumber);
                if (ProfessionRecord == null)
                {
                    return "300";
                }
                else
                {
                    model.ProfessionalDetailsId = ProfessionRecord.ProfessionalDetailsId;
                    model.CompanyName = ProfessionRecord.CompanyName;
                    model.MonthlyIncome = ProfessionRecord.MonthlyIncome;
                    model.YearOfExperience = ProfessionRecord.YearOfExperience;
                    model.CurrentEMI = ProfessionRecord.CurrentEMI;
                    model.CompanyAddress = ProfessionRecord.CompanyAddress;
                    model.CompanyEmailId = ProfessionRecord.CompanyEmailId;
                    model.PhoneNumber = ProfessionRecord.PhoneNumber;

                    string jsonResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                    return jsonResult;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "ProfessionalDetails-Get";
                int error = objError.InsertError(model);
                return "400";
            }
        }
        }
    }
