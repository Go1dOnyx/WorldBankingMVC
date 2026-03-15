using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Models
{
    public class BankAccounts
    {
        public Guid BankAccountId { get; set; }

        [Required]
        public int AccountNum { get; set; }
        public int RoutingNum { get; set; }

        [Column(TypeName="decimal(18,2)")]
        public decimal AccountBalance { get; set; }
        public string? AccountStatus { get; set; } //active, locked/frozen, suspended, 

        //Foreign Kets
        public Guid UserId { get; set; }
        public Users? User { get; set; }

        //Navigational Property
        public ICollection<Transaction>? Transactions { get; set; }

    }
}
