﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBackend.Infrastructure.Models
{
    public enum CardType
    {
       Visa,
       MasterCard,
       AmericanExpress,
       Discover
    }
    public class DebitCard : BaseEntity
    {
        [Required]
        [StringLength(6)]
        public string CardNumber { get; set; }
        [Required]
        public string HolderName { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public CardType Type { get; set; }
        
        [Required]
        public Guid BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        [Required]
        public string PINHash { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        public BankUser Owner { get; set; }
    }
}
