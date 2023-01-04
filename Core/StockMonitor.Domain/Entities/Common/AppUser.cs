using Microsoft.AspNetCore.Identity;
using StockMonitor.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Domain.Entities.Common
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [NotMapped]
        public string Fullname { get => Name + " " + Surname; }
        [Required]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
