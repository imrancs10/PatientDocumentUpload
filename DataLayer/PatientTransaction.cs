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
    
    public partial class PatientTransaction
    {
        public int PatientTransactionId { get; set; }
        public string OrderId { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> PatientId { get; set; }
        public string TransactionNumber { get; set; }
        public string ResponseCode { get; set; }
        public string StatusCode { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string Type { get; set; }
    
        public virtual PatientInfo PatientInfo { get; set; }
    }
}
