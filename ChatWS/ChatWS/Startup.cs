using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(ChatWS.Startup))]

namespace ChatWS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //lanza el método enterUser() definido en el concentrador CounterHub
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration { };
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
