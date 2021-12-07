using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;


[assembly: OwinStartup(typeof(ChatWEB.Startup))]

namespace ChatWEB
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
