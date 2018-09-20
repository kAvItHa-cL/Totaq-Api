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
    public class PersonalDetailsController : ApiController
    {
        PersonalDetailsDal objPersonal = new PersonalDetailsDal();
        PersonalDetail PersonalModel = new PersonalDetail();

        [HttpPost]
        public int PersonalDetails(string FatherName, string MotherName, string DOB, string MaritalStatus, string CurrentAddress, string PhoneNumber)
        {
            try
            {
                PersonalModel.FatherName = FatherName;
                PersonalModel.MotherName = MotherName;
                PersonalModel.DOB = DOB;
                PersonalModel.MaritalStatus = MaritalStatus;
                PersonalModel.CurrentAddress = CurrentAddress;
                PersonalModel.PhoneNumber = PhoneNumber;
                return objPersonal.SavePersonalDetails(PersonalModel);
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "PersonalDetails-POST";
                int error = objError.InsertError(model);
                return 400;
                
            }
        }
        [HttpGet]
        public string GetDetails(string PhoneNumber)
        {
            try
            {
                PersonalDetail model = new PersonalDetail();
                PersonalDetail PersonalRecords = objPersonal.FetchPersonalDetails(PhoneNumber);
                if (PersonalRecords == null)
                {
                    return "300";
                }
                else
                {
                    model.PersonalDetailsId = PersonalRecords.PersonalDetailsId;
                    model.PhoneNumber = PersonalRecords.PhoneNumber;
                    model.FatherName = PersonalRecords.FatherName;
                    model.MotherName = PersonalRecords.MotherName;
                    model.DOB = PersonalRecords.DOB;
                    model.MaritalStatus = PersonalRecords.MaritalStatus;
                    model.CurrentAddress = PersonalRecords.CurrentAddress;


                    string jsonResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                    return jsonResult;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "PersonalDetails-GET";
                int error = objError.InsertError(model);
                return "400";
            }
        }
    }
}