using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientReport.Infrastructure.Authentication
{
    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public string CODE { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string DepartmentID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Religion { get; set; }
        public string Department { get; set; }

    }
}