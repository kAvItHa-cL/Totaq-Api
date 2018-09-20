using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class ReferenceDetailsDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        public ReferenceDetail FetchReferenceDetails(string PhoneNumber)
        {
            try
            {
                var referencequery = dbContext.ReferenceDetails.Where(r => r.PhoneNumber == PhoneNumber).FirstOrDefault();
                return referencequery;
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch Reference Details";
                int error = objError.InsertError(model);
                throw;
            }
        }
        public int SaveReferenceDetails1(ReferenceDetail ReferenceModel)
        {
            try
            {
                var existscount = dbContext.ReferenceDetails.Where(b => b.PhoneNumber == ReferenceModel.PhoneNumber).FirstOrDefault();
                if (existscount == null)
                {
                    dbContext.ReferenceDetails.Add(ReferenceModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    existscount.Reference1 = ReferenceModel.Reference1;
                    existscount.ReferenceName1 = ReferenceModel.ReferenceName1;
                    dbContext.Entry(existscount).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return 100;
                }
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Save Reference Details";
                int error = objError.InsertError(model);
                return 400;
            }
        }
        public int SaveReferenceDetails2(ReferenceDetail ReferenceModel)
        {
            try
            {
                var existscount = dbContext.ReferenceDetails.Where(b => b.PhoneNumber == ReferenceModel.PhoneNumber).FirstOrDefault();
                if (existscount == null)
                {
                    dbContext.ReferenceDetails.Add(ReferenceModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    existscount.Reference2 = ReferenceModel.Reference2;
                    existscount.ReferenceName2 = ReferenceModel.ReferenceName2;
                    dbContext.Entry(existscount).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return 100;
                }
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Save Reference Details";
                int error = objError.InsertError(model);
                return 400;
            }
        }

        public int SaveReferenceDetails(ReferenceDetail ReferenceModel)
        {
            try
            {
                var existscount = dbContext.ReferenceDetails.Where(b => b.PhoneNumber == ReferenceModel.PhoneNumber).FirstOrDefault();
                if (existscount == null)
                {
                    dbContext.ReferenceDetails.Add(ReferenceModel);
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
                model.Source = "Save Reference Details";
                int error = objError.InsertError(model);
                return 400;
            }
        }
    }
}