using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientReport.Models.PatientReport
{
    public class IPDListResponseModel
    {
        public string PCode { get; set; }
        public string DoR { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public string ipno { get; set; }
        public string iage { get; set; }
        public string name { get; set; }
        public string bedno { get; set; }
        public string roomno { get; set; }
        public string admittime { get; set; }
    }
}