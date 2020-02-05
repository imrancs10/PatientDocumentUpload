using DataLayer;
using PatientReport.BAL.Appointments;
using PatientReport.BAL.Masters;
using PatientReport.BAL.Patient;
using PatientReport.Global;
using PatientReport.Infrastructure.Authentication;
using PatientReport.Models;
using System;
using System.Web.Mvc;
using static PatientReport.Global.Enums;

namespace PatientReport.Infrastructure.Utility
{
    public abstract class BaseViewPage : WebViewPage
    {
        
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
        public virtual HospitalDetail GetHospitalDetail()
        {
            HospitalDetails _details = new HospitalDetails();
            return _details.GetHospitalDetail();
        }

        public virtual AppointmentModel GetAppointmentDetail()
        {
            if (User != null)
            {
                AppointDetails _details = new AppointDetails();
                return _details.PatientAppointmentCount(User.Id);
            }
            return null;
        }

        public virtual PatientInfo GetPatientInfo()
        {
            if (User != null)
            {
                PatientDetails _details = new PatientDetails();
                return _details.GetPatientDetailById(User.Id);
            }
            return null;
        }

    }
}