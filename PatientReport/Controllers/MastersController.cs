using PatientReport.BAL.Masters;
using PatientReport.BAL.Patient;
using PatientReport.Infrastructure.Authentication;
using PatientReport.Models.PatientReport;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
                    if (loginResponseModel.Any())
                    {
                        return Json(loginResponseModel);
                    }
                    else
                    {
                        return Json("No Recrod Found");
                    }
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
                    if (loginResponseModel.Any())
                    {
                        return Json(loginResponseModel);
                    }
                    else
                    {
                        return Json("No Recrod Found");
                    }
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