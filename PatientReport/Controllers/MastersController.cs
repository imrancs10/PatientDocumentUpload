using PatientReport.BAL.Masters;
using System.Web.Mvc;

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