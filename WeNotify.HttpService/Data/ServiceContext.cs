using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WeNotify.HttpService.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}
