﻿using System;
using System.Collections.Generic;
using WorldBankDB.DataAccess.EF.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorldBankDB.DataAccess.EF.Models
{
    public partial class Accounts
    {
        public Guid AccountId { get; set; }
        public Guid UserId { get; set; } //ForeignKey
        public string? AccountType { get; set; }
        public int AccountNum { get; set; }
        public int RoutingNum { get; set; }
        public decimal Amount { get; set; }
        public bool IsLocked { get; set; }

        public Cards? Cards { get; set; }
        public Users? Users { get; set; }

        public Accounts(Guid accountID, Guid userID, string acctType, int acctNum, int routeNum, decimal amount, bool isLocked, Cards card, Users user) 
        {
            AccountId = accountID;
            UserId = userID;
            AccountType = acctType;
            AccountNum = acctNum;
            RoutingNum = routeNum;
            Amount = amount;
            IsLocked = isLocked;
            Cards = card;
            Users = user;
        }
        public Accounts() { }
    }
}
