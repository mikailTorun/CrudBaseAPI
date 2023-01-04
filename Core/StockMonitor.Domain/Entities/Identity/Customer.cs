using StockMonitor.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Domain.Entities.Identity
{
    public class Customer : BaseEntity
    {
        [Required]
        public string Name{ get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

    }
}
