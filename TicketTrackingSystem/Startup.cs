using Microsoft.Owin;
using Owin;



[assembly: OwinStartupAttribute(typeof(TicketTrackingSystem.Startup))]
namespace TicketTrackingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        

    }
}
