using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBackend.Infrastructure.Models
{
    public class BankAccount : BaseEntity
    {
        [Required, StringLength(22)]
        public string IBAN { get; set; } = string.Empty;

        [Required]
        public string AccountNumber { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 0m;

        [Required]
        public Guid BankUserId { get; set; }

        public BankUser BankUser { get; set; }

        public ICollection<DebitCard> DebitCards { get; set; } = new List<DebitCard>();
        public ICollection<Transaction> SentTransactions { get; set; } = new List<Transaction>();
        public ICollection<Transaction> ReceivedTransactions { get; set; } = new List<Transaction>();

    }
}
