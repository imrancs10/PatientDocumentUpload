using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientReport.Models.PatientReport
{
    public class LoginResponseModel
    {
        public bool Status { get; set; }
        public string Name { get; set; }
        public string CODE { get; set; }
        public string Message { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int DoctorId { get; set; }
        public int DeptID { get; set; }
        public string Mobile { get; set; }
        public string EmailAddress { get; set; }
        public string Designation { get; set; }
        public string UserType { get; set; }
    }
}