using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class NotificationDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        public List<Notification> FetchNotifications(string PhoneNumber)
        {
            try
            {
                var notifications = dbContext.Notifications.Where(N => N.PhoneNumber == PhoneNumber).ToList();
                return notifications.ToList() ;

            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Notification Fetch";
                int error = objError.InsertError(model);
                throw;
            }
        }
    }
}