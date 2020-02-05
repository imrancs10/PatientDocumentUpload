using DataLayer;
using PatientPortal.BAL.Masters;
using PatientPortal.BAL.Patient;
using PatientPortal.Global;
using PatientPortal.Infrastructure;
using PatientPortal.Infrastructure.Adapter.WebService;
using PatientPortal.Models;
using PatientPortal.Models.Masters;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PatientPortal.Global.Enums;
using JsonResult = System.Web.Mvc.JsonResult;

namespace PatientPortal.Controllers
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