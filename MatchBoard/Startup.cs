using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MatchBoard.Startup))]
namespace MatchBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
