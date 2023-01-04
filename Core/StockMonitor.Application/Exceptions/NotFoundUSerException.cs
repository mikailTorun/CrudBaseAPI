using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Application.Exceptions
{
    public class NotFoundUSerException : Exception
    {
        public NotFoundUSerException()
        {
        }

        public NotFoundUSerException(string? message) : base(message)
        {
        }

        public NotFoundUSerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
