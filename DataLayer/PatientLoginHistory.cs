//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientLoginHistory
    {
        public int Id { get; set; }
        public Nullable<int> PatientId { get; set; }
        public Nullable<System.DateTime> LoginDate { get; set; }
        public string IPAddress { get; set; }
    
        public virtual PatientInfo PatientInfo { get; set; }
    }
}
