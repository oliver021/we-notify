using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeNotify.HttpService.Contracts;

namespace WeNotify.HttpService.Data
{
    public class Account : BaseEntity<uint>
    {
        public string Name { get; set; }
        public Guid ApiKey { get; set; }
        public string ApiSecrect { get; set; }

        public bool Enable { get; set; } = true;
    }
}
