using Microsoft.AspNetCore.Mvc;
using PremiumTesh.TwitterNotifier.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeNotify.HttpService.Contracts;
using WeNotify.HttpService.Data;

namespace WeNotify.HttpService.Controllers
{
    [ApiController]
    public class AccountController : GenericController<Account, uint>
    {
        public AccountController(IRepository<Account> repository) : base(repository)
        {
        }
    }
}
