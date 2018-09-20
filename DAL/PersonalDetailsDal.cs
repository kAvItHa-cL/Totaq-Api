using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class PersonalDetailsDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        public PersonalDetail FetchPersonalDetails(string PhoneNumber)
        {
            try
            {
                var personalquery = dbContext.PersonalDetails.Where(p => p.PhoneNumber == PhoneNumber).FirstOrDefault();
                return personalquery;
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "PersonalDetails-Fetch";
                int error = objError.InsertError(model);
                throw;
            }
        }

            public int SavePersonalDetails(PersonalDetail PersonalModel)
            {
            try
            {
                var existscount = dbContext.PersonalDetails.Where(b => b.PhoneNumber == PersonalModel.PhoneNumber).FirstOrDefault();
                if (existscount == null)
                {
                    dbContext.PersonalDetails.Add(PersonalModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    return 200;
                }
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "SavePersonalDetails";
                int error = objError.InsertError(model);
                return 400;
            }

            }
        }
    }
