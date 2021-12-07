using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazerSignalR.Server
{
    public class TextHub : Hub
    {
        public async Task Send(String text)
        {
            await Clients.All.SendAsync("ReceiveInformation", text);
        }
    }
}
