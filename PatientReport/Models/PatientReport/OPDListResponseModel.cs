using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientReport.Models.PatientReport
{
    public class OPDListResponseModel
    {
        public string PCode { get; set; }
        public string DoR { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string timeoftran { get; set; }
    }
}