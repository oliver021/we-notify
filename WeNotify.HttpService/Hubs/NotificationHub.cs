using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeNotify.HttpService.Contracts;

namespace WeNotify.HttpService.Hubs
{
    public class NotificationHub : Hub<INotify>
    {
        private readonly ILogger<NotificationHub> _logger;

        public NotificationHub(ILogger<NotificationHub> logger)
        {
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            HttpContext http = Context.GetHttpContext();
            if (http is null)
            {
                await Clients.Caller.Close("No http protocol found");
            }

            if (false)
            {
                // make auth check
            }

            string channel = http.Request.Query["channel"];
            await Groups.AddToGroupAsync(Context.ConnectionId, channel);
            Context.Items.Add("added", channel);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (exception != null)
            {
                _logger.LogError("cliente: {0}\n desconectado por: {1}",
                    Context.ConnectionId,
                    exception.Message);
            }

            if (Context.Items.ContainsKey("added"))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, (string) Context.Items["added"]);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
