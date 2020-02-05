using DataLayer;
using PatientReport.Global;
using PatientReport.Models.Patient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using static PatientReport.Global.Enums;

namespace PatientReport.BAL.Lookup
{
    public class LookupDetails
    {
        PatientReportEntities _db = null;

        enum LookupEnum
        {
            HelpLineNo
        }
        public List<MasterLookup> GetLookupDetail()
        {
            _db = new PatientReportEntities();
            return _db.MasterLookups.ToList();
        }
    }
}