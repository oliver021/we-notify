using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeNotify.HttpService.Data;

namespace WeNotify.HttpService.Contracts
{
    public interface INotify
    {
        public Task Notify(Notification notification);
        public Task Close(string reason);
    }
}
