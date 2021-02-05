using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using WeNotify.HttpService.Data;
using WeNotify.HttpService.Contracts;

namespace WeNotify.HttpService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotifyController : ControllerBase
    {

        private readonly ILogger<NotifyController> _logger;
        private readonly IRepository<Notification> _repo;
        private readonly Hub<INotify> _notify;

        public NotifyController(Hub<INotify> notify, ILogger<NotifyController> logger, IRepository<Notification> repo)
        {
            _notify = notify;
            _logger = logger;
            _repo = repo;
        }

        [HttpPost]
        public async Task<NoContentResult> Notify(Notification notification)
        {
            // send and store the notification
            await _notify.Clients.Group(notification.Channel).Notify(notification);
            await _repo.StoreAnsyc(notification);

            // flush the log
            _logger.LogInformation(message: "Pushed notificaction with title: {0} to {1}",
                notification.Title,
                notification.Channel);
            
            // send a response with 204 code
            return NoContent();
        }
    }
}
