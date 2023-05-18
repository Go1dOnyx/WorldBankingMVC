using WorldBankDBMVC.DataAcess.EF.Models;
using WorldBankDBMVC.DataAcess.EF.Repositories;
using WorldBankDBMVC.DataAcess.EF.Context;

namespace WorldBankDBMVC.Models
{
    public class AdminViewModel
    {
        private WorldBankRespository _bankRepo;

        public List<Accounts> AccountList { get; set; }

        public Accounts CurrentAccount { get; set; } = new Accounts();

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; } = "";

        public AdminViewModel(WorldBankDBContext context)
        {
            _bankRepo = new WorldBankRespository(context);
            AccountList = GetAllAccounts();
            CurrentAccount = AccountList.FirstOrDefault()!;
        }

        public AdminViewModel(WorldBankDBContext context, int acctID)
        {
            _bankRepo = new WorldBankRespository(context);
            AccountList = GetAllAccounts();

            if (acctID > 0)
            {
                CurrentAccount = GetAccount(acctID);
            }
            else
            {
                CurrentAccount = new Accounts();
            }
        }

        public void SaveAccount(Accounts account)
        {
            if (account.AccountId > 0)
            {
                _bankRepo.Update(account);
            }
            else
            {
                account.AccountId = _bankRepo.Create(account);
            }

            AccountList = GetAllAccounts();
            CurrentAccount = GetAccount(account.AccountId);
        }

        public void RemoveAccount(int acctID)
        {
            _bankRepo.Delete(acctID);
            AccountList = GetAllAccounts();
            CurrentAccount = AccountList.FirstOrDefault()!;
        }

        public List<Accounts> GetAllAccounts()
        {
            return _bankRepo.GetAllAccounts();
        }

        public Accounts GetAccount(int acctID)
        {
            return _bankRepo.GetAccountById( acctID);
        }
    }
}

