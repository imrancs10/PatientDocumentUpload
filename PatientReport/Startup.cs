using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Owin;

[assembly: OwinStartupAttribute(typeof(PatientReport.Startup))]
namespace PatientReport
{
    public partial class Startup
    {
        public void Configuration(AppBuilder app)
        {
        }
    }
}
