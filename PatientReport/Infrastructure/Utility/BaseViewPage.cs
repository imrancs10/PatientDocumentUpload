using DataLayer;
using PatientReport.BAL.Masters;
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
    }
}