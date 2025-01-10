using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Models
{
    public class Cards
    {
        public Guid CardId { get; set; }
        public Guid AccountId { get; set; } //Foreign Key
        public Guid UserId { get; set; } //Foreign Key
        public string? CardName { get; set; }
        public int CardNumber { get; set; }
        public int ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
        public decimal CardAmount { get; set; } // make a way to use Icollection to show connect to Account model
        public bool IsLocked { get; set; } //Also this one
        public DateTime CreatedDate { get; set; }
        public bool IsCredit { get; set; }

        public Accounts? Account { get; set; }
        public Users? User { get; set; }

        public Cards(Guid cardID, Guid acctID, Guid userID, string name, int number, int expired, int security, decimal amount, bool isLocked, DateTime createDate, bool isCredit, Accounts acct, Users user) 
        {
            CardId = cardID;
            AccountId = acctID;
            UserId = userID;
            CardName = name;
            CardNumber = number;
            ExpirationDate = expired;
            SecurityCode = security;
            CardAmount = amount;
            IsLocked = isLocked;
            CreatedDate = createDate;
            IsCredit = isCredit;
            Account = acct;
            User = user;
        }
        public Cards() { }
    }
}
