using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace socket.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private ILogger<MessageController> _msgLogger;
        public MessageController(IHubContext<NotifyHub, ITypedHubClient> hubContext, ILogger<MessageController> msgLogger)
        {
            _hubContext = hubContext;
            _msgLogger = msgLogger;
        }

        [HttpGet("[action]")]
        public string Message()
        {
            string retMessage = string.Empty;
            try
            {               
                _msgLogger.LogDebug("Hello {ContName} i am great", "MessageController");
                _hubContext.Clients.All.BroadcastMessage("success", "Element Added");
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }        
    }
}