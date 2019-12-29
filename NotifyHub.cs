using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socket
{
    public class NotifyHub : Hub<ITypedHubClient>
    {
        public Task BroadcastMessage(string type, string payload)
        {
            throw new NotImplementedException();
        }
    }
}
