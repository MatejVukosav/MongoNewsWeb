using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MongoNewsWebAplication.Startup))]
namespace MongoNewsWebAplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
