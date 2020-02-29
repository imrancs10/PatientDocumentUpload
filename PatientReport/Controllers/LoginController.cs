using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using PatientReport.Global;
using PatientReport.Infrastructure.Authentication;
using PatientReport.Models.PatientReport;

namespace PatientReport.Controllers
{
    public class LoginController : CommonController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLogin(string username, string password, string userrole)
        {
            if (userrole == "Doctors")
            {
                LoginResponseModel loginResponseModel = new LoginResponseModel();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["HIMSDoctorApiBaseUrl"].ToString());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("/RMLAPI/api/Authentication?id=&username=" + username + "&password=" + password + "").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;
                        loginResponseModel = response.Content.ReadAsAsync<LoginResponseModel>().Result;
                    }
                    else
                    {
                        SetAlertMessage(Enums.LoginMessage.LoginFailed.ToString(), "Login Response");
                        return View("Index");
                    }
                }

                if (loginResponseModel != null)
                {
                    if (loginResponseModel.Status == true)
                    {
                        loginResponseModel.UserType = "Doctor";
                        setUserClaim(loginResponseModel);
                        return RedirectToAction("HomePage", "Masters");
                    }
                    else
                    {
                        SetAlertMessage(Enums.LoginMessage.InvalidCreadential.ToString(), "Login Response");
                        return View("Index");
                    }
                }
                else
                {
                    SetAlertMessage(Enums.LoginMessage.InvalidCreadential.ToString(), "Login Response");
                    return View("Index");
                }
            }
            else if (userrole == "Others")
            {
                LoginResponseModel loginResponseModel = new LoginResponseModel();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["HIMSDoctorApiBaseUrl"].ToString());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("/RMLAPI/api/Authentication?id=&username=" + username + "&password=" + password + "").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;
                        loginResponseModel = response.Content.ReadAsAsync<LoginResponseModel>().Result;
                    }
                    else
                    {
                        SetAlertMessage(Enums.LoginMessage.LoginFailed.ToString(), "Login Response");
                        return View("Index");
                    }
                }

                if (loginResponseModel != null)
                {
                    if (loginResponseModel.Status == true || loginResponseModel.Status == false)
                    {
                        // Code will be reomved later start
                        loginResponseModel.DoctorId = 1;
                        loginResponseModel.Name = "testUser";
                        loginResponseModel.CODE = "testUser";
                        loginResponseModel.Mobile = "000000000";
                        loginResponseModel.EmailAddress = "testUser@test.com";
                        loginResponseModel.UserType = "Employee";
                        // Code will be reomved later End
                        setUserClaim(loginResponseModel);
                        return RedirectToAction("HomePage", "Masters");
                    }
                    else
                    {
                        SetAlertMessage(Enums.LoginMessage.InvalidCreadential.ToString(), "Login Response");
                        return View("Index");
                    }
                }
                else
                {
                    SetAlertMessage(Enums.LoginMessage.InvalidCreadential.ToString(), "Login Response");
                    return View("Index");
                }
            }
            else
            {
                SetAlertMessage(Enums.LoginMessage.WrongUserSelected.ToString(), "Login Response");
                return View("Index");
            }

        }

        private void setUserClaim(LoginResponseModel loginResponseModel)
        {
            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
            serializeModel.Id = loginResponseModel.DoctorId;
            serializeModel.Name = string.IsNullOrEmpty(loginResponseModel.Name) ? string.Empty : loginResponseModel.Name;
            serializeModel.CODE = string.IsNullOrEmpty(loginResponseModel.CODE) ? string.Empty : loginResponseModel.CODE;
            serializeModel.Mobile = string.IsNullOrEmpty(loginResponseModel.Mobile) ? string.Empty : loginResponseModel.Mobile;
            serializeModel.DepartmentID = string.IsNullOrEmpty(loginResponseModel.Mobile) ? string.Empty : loginResponseModel.Mobile; ;
            serializeModel.Email = string.IsNullOrEmpty(loginResponseModel.EmailAddress) ? string.Empty : loginResponseModel.EmailAddress;
            serializeModel.UserType = string.IsNullOrEmpty(loginResponseModel.UserType) ? string.Empty : loginResponseModel.UserType; ;

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(serializeModel);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                     1,
                     UserData.Email,
                     DateTime.Now,
                     DateTime.Now.AddMinutes(15),
                     false,
                     userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
        }
    }
}