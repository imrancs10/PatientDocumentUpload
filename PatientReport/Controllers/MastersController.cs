using DataLayer;
using PatientReport.BAL.Masters;
using PatientReport.BAL.Patient;
using PatientReport.Global;
using PatientReport.Infrastructure;
using PatientReport.Infrastructure.Adapter.WebService;
using PatientReport.Models;
using PatientReport.Models.Masters;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PatientReport.Global.Enums;
using JsonResult = System.Web.Mvc.JsonResult;

namespace PatientReport.Controllers
{
    public class MastersController : CommonController
    {
        DepartmentDetails _details = null;

        [HttpGet]
        public ActionResult AddDoctorLeave()
        {
            return View();
        }
    }
}