using StockMonitor.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Application.Features.Identity.AppUser.Commads.LoginUser
{
    public class LoginUserResponse
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public Token Token { get; set; }
    }
}
