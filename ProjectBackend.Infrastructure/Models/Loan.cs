using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBackend.Infrastructure.Models
{
    public enum LoanStatus
    {
        Active,
        PaidOff,
        Defaulted
    }
    public class Loan : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Principal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RemainingAmount { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal InterestRate { get; set; }

        public int TermInMonths { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime NextInterestUpdate { get; set; } = DateTime.UtcNow.AddMonths(1);
        public LoanStatus Status { get; set; } = LoanStatus.Active;

        [Required]
        public Guid BorrowerAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        [Required]
        public Guid BankLenderAccountId { get; set; }
        public BankAccount BankLenderAccount { get; set; }

        public Guid? InitialTransactionId { get; set; }
        public Transaction? InitialTransaction { get; set; }
    }
}
