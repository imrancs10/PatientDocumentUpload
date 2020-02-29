using PatientReport.BAL.Masters;
using PatientReport.Infrastructure.Authentication;
using PatientReport.Models.PatientReport;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using PatientReport.Global;
using System.IO;

namespace PatientReport.Controllers
{
    public class MastersController : CommonController
    {
        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult PatientList()
        {
            return View();
        }
        [HttpPost]
        public JsonResult PatientList(string patienttype)
        {
            var userInfo = User as CustomPrincipal;
            if (userInfo != null)
            {
                int doctorId = userInfo.Id;
                if (patienttype == "IPD")
                {
                    List<IPDListResponseModel> loginResponseModel = new List<IPDListResponseModel>();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["HIMSDoctorApiBaseUrl"].ToString());
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync("/RMLAPI/api/PatientDetails/GetIpdList?doctid=" + doctorId + "").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            string responseString = response.Content.ReadAsStringAsync().Result;
                            loginResponseModel = response.Content.ReadAsAsync<List<IPDListResponseModel>>().Result;
                        }
                    }
                    return Json(loginResponseModel);
                }
                else if (patienttype == "OPD")
                {
                    List<OPDListResponseModel> loginResponseModel = new List<OPDListResponseModel>();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["HIMSDoctorApiBaseUrl"].ToString());
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync("/RMLAPI/api/PatientDetails/GetOpdList?doctid=" + doctorId + "").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            string responseString = response.Content.ReadAsStringAsync().Result;
                            loginResponseModel = response.Content.ReadAsAsync<List<OPDListResponseModel>>().Result;
                        }
                        else
                        {
                            return Json("ServerError");
                        }
                    }
                    return Json(loginResponseModel);
                }
            }
            else
            {
                return Json("Session Out");
            }
            return null;
        }

        public ActionResult PatientDetail(string crNumber)
        {
            crNumber = crNumber.Replace('~', ':').Replace('_', '/');
            DocumentDetails details = new DocumentDetails();
            ViewData["documents"] = details.GetAllDocumentDetail(crNumber);
            TempData["crNumber"] = crNumber;
            return View();
        }

        [HttpPost]
        public ActionResult PatientDetail(string title, string DocType, HttpPostedFileBase document)
        {
            PatientDocument PatientDocument = new PatientDocument();
            if (document != null && document.ContentLength > 0)
            {
                string fileUrl = getDocumentPath(document, PatientDocument.CRNumber);

                PatientDocument.DocumentTitle = title;
                PatientDocument.DocumentType = DocType;
                PatientDocument.CRNumber = Convert.ToString(TempData["crNumber"]);
                PatientDocument.DocumentPath = fileUrl;
                //save file start
                //hospital.HospitalLogo = new byte[File1.ContentLength];
                //File1.InputStream.Read(hospital.HospitalLogo, 0, File1.ContentLength);
                //Use Namespace called :  System.IO  
                if (document.ContentLength > 0)
                {
                    DocumentDetails details = new DocumentDetails();
                    var result = details.SaveDocumentDetail(PatientDocument);
                    if (result == Enums.CrudStatus.DataAlreadyExist)
                    {
                        SetAlertMessage("Document already exist with same name", "Document Entry");
                    }
                    else
                    {
                        document.SaveAs(Server.MapPath(fileUrl));
                        SetAlertMessage("Document saved Successfully", "Document Entry");
                    }

                    return RedirectToAction("PatientDetail", new { crNumber = Convert.ToString(TempData["crNumber"]) });
                }
                else
                {
                    SetAlertMessage("document detail not saved", "Document Entry");
                    return RedirectToAction("PatientDetail", new { crNumber = Convert.ToString(TempData["crNumber"]) });
                }
            }
            else
            {
                SetAlertMessage("document detail not saved", "Document Entry");
                return RedirectToAction("PatientDetail", new { crNumber = Convert.ToString(TempData["crNumber"]) });
            }
        }

        private string getDocumentPath(HttpPostedFileBase document, string CRNumber)
        {
            string dirUrl = "~/PatientDocument/" + CRNumber;
            string dirPath = Server.MapPath(dirUrl);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            // save the file to the Specifyed folder  
            string fileUrl = dirUrl + "/" + Path.GetFileName(document.FileName);
            return fileUrl;
        }

        public ActionResult UploadDocument()
        {
            return View();
        }
        public ActionResult SearchPatient()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}