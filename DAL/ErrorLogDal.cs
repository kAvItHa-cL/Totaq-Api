using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TotaqWebAPI.DAL;

namespace TotaqWebAPI.DAL
{
    public class ErrorLogDal
    {
        ErrorLog model = new ErrorLog();
        GTLOANEntities dbContext = new GTLOANEntities();
        public int InsertError(ErrorLog model)
        {
            try
            {
                //model.Data = Data;
                //model.Message = Message;
                //model.InnerException = InnerException;
                //model.Source = Source;
                //model.TargetSite = TargetSite;
                model.Date = DateTime.Now;

                dbContext.ErrorLogs.Add(model);
                dbContext.SaveChanges();
                return 500;
                
            }
            catch (Exception)
            {

                return 400;
            }
            
        }
    }
}