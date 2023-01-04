using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Application.Exceptions
{
    public class AppUserCreateFailedException : Exception
    {
        public AppUserCreateFailedException() : base("Kullanıcı oluşturulurken beklenmeyen bir hata oluştu")
        {
        }

        public AppUserCreateFailedException(string? message) : base(message)
        {
        }

        public AppUserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
