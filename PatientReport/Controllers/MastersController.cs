using PatientReport.BAL.Masters;
using System.Web.Mvc;

namespace PatientReport.Controllers
{
    public class MastersController : CommonController
    {
        DepartmentDetails _details = null;

        public ActionResult HomePage()
        {
            return View();
        }   

        public ActionResult PatientList()
        {
            return View();
        }

        public ActionResult PatientDetail()
        {
            return View();
        }
        public ActionResult UploadDocument()
        {
            return View();
        }
        public ActionResult SearchPatient()
        {
            return View();
        }
        

    }
}