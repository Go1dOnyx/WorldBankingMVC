using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Models
{
    public enum AccountStatus
    {
        Active,
        Locked,
        Suspended,
        Closed
    }
    public class BankAccounts
    {
        public Guid BankAccountId { get; set; }
        public long AccountNum { get; set; }
        public int RoutingNum { get; set; }
        public decimal AccountBalance { get; set; }
        public AccountStatus AccountStatus { get; set; }

        //Foreign Key
        public Guid UserId { get; set; }

        //Navigational Property
        public Users? User { get; set; }

        //Navigational Property
        public ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();

    }
}
