using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeNotify.HttpService.Data
{
    public class Notification
    {
        public uint Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public string Image { get; set; } = string.Empty;

        public NotificationType Type { get; set; }

        public string Channel { get; set; } 
    }
}
