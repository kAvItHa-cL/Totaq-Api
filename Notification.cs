//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TotaqWebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Status { get; set; }
    
        public virtual Register Register { get; set; }
    }
}
