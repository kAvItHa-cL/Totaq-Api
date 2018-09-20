using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class RegisterDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        Register RegisterModel = new Register();
        public int SaveUser(Register RegModel)
        {
            try
            {
                var existscount = dbContext.Registers.Where(b => b.PhoneNumber == RegModel.PhoneNumber).FirstOrDefault();
                if (existscount == null)
                {
                    dbContext.Registers.Add(RegModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else { return 200;  }
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Register-Save User";
                int error = objError.InsertError(model);
                return 400;
                
            }
        }

        public int CheckUser(string PhoneNumber)
        {
            try
            {
                var userexists = dbContext.Registers.Where(p => p.PhoneNumber == PhoneNumber).FirstOrDefault();
                if(userexists !=null)
                {
                    userexists.Status = "Hold";
                    dbContext.Entry(userexists).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return 200;
                }
                else
                {
                    return 300;
                }
            }
            catch(Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Register-Check User";
                int error = objError.InsertError(model);
                return 400;
            }
        }
    }
}