using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace PatientReport.Infrastructure.Authentication
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }

        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string CODE { get; set; }
        public string DepartmentID { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}