using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBackend.Infrastructure.Models
{
    public class BankUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{2}(?:0[1-9]|1[0-2]|2[1-9]|3[0-2]|4[1-9]|5[0-2])(?:0[1-9]|[1-2][0-9]|3[0-1])[0-9]{4}")]
        public string PersonalIdentificationNumber { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; } = new HashSet<BankAccount>();
        public ICollection<DebitCard> DebitCards { get; set; } = new HashSet<DebitCard>();
    }
}
