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
    
    public partial class ErrorLog
    {
        public int ErrorLogId { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string Data { get; set; }
        public string Source { get; set; }
        public string TargetSite { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}
