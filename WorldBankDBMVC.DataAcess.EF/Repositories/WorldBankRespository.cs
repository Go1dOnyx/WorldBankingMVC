using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBankDBMVC.DataAcess.EF.Context;
using WorldBankDBMVC.DataAcess.EF.Models;

namespace WorldBankDBMVC.DataAcess.EF.Repositories
{
    public class WorldBankRespository
    {
        //Establising a connection to database with entities classes
        private WorldBankDBContext _dbContext;


        public WorldBankRespository(WorldBankDBContext dbContext) { 
            _dbContext = dbContext;
        }

        //Creates a new account and adds to database
        public int Create(Accounts newAccount) { 

            _dbContext.Add(newAccount);
            _dbContext.SaveChanges();

            return newAccount.AccountId;
        }

        //Updates a specific record by their account ID
        public int Update(Accounts currentAccount) {
            Accounts existingAccount = _dbContext.Accounts.Find(currentAccount.AccountId);
            //Testing for non existing records
            //if (existingAccount == null) { }

            existingAccount.UserName = currentAccount.UserName;
            existingAccount.EmailAddress = currentAccount.EmailAddress;
            existingAccount.Password = currentAccount.Password;
            existingAccount.FirstName = currentAccount.FirstName;
            existingAccount.MiddleName = currentAccount.MiddleName;
            existingAccount.LastName = currentAccount.LastName;
            existingAccount.CheckingBalance = currentAccount.CheckingBalance;
            existingAccount.SavingBalance = currentAccount.SavingBalance;

            _dbContext.SaveChanges();
            return existingAccount.AccountId;
        }

        //Removes existing record by account ID from database
        public bool Delete(int acctId) {
            Accounts existingAccount = _dbContext.Accounts.Find(acctId);
            //Testing for non existing records
            //if (existingAccount == null) { }

            _dbContext.Remove(existingAccount);
            _dbContext.SaveChanges();

            return true;
        }

        //Gets a list of all the Accounts
        public List<Accounts> GetAllAccounts() { 
            List<Accounts> accountList = _dbContext.Accounts.ToList();
            return accountList; 
        }

        //Select a specific accounmt by account ID
        public Accounts GetAccountById(int acctId) {
            Accounts existingAccount = _dbContext.Accounts.Find(acctId);
            return existingAccount;
        }
    }
}
