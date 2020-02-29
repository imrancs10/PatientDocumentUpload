using log4net;
using PatientReport.HISWebReference;
using PatientReport.Infrastructure.Utility;
using PatientReport.Models;

namespace PatientReport.Infrastructure.Adapter.WebService
{

    public class WebServiceIntegration
    {
        ILog logger = LogManager.GetLogger(typeof(WebServiceIntegration));

        public HISPatientInfoModel GetPatientInfoBYCRNumber(string crNumber)
        {
            GetPatientDetails service = new GetPatientDetails();
            var result = service.getPatientDetails(crNumber);
            if (result.ToUpper().Equals("N") || result.ToUpper().Equals("E"))
                return null;
            Serializer serilizer = new Serializer();
            result = result.Replace("<NewDataSet>", "").Replace("</NewDataSet>", "");
            return serilizer.Deserialize<HISPatientInfoModel>(result, "Table1");
        }

    }
}