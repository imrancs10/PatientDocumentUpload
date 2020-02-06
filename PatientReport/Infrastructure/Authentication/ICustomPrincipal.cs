using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PatientReport.Infrastructure.Authentication
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string Name { get; set; }
        string CODE { get; set; }
        string DepartmentID { get; set; }
        string Email { get; set; }
        string Mobile { get; set; }

    }
}
