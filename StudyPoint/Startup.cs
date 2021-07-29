using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyPoint.Startup))]
namespace StudyPoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
