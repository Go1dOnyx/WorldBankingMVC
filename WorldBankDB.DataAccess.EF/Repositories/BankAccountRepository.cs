 using WorldBankDB.DataAccess.EF.Repositories.Contract;
using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace WorldBankDB.DataAccess.EF.Repositories
{
    public class BankAccountRepository: IBankAccountRepository
    {
        private readonly WorldBankDBContext _context;
        public BankAccountRepository(WorldBankDBContext context) 
        {
            _context = context;
        }
        public async Task<List<BankAccounts>> GetAllAccountsAsync() => await _context.BankAccounts.ToListAsync();
        public async Task<BankAccounts?> GetAcctByIdAsync(Guid accountId) => await _context.BankAccounts.FindAsync(accountId);
        public async Task<BankAccounts?> CreateAccountAsync(BankAccounts acct)
        {
            await _context.AddAsync(acct);
            await _context.SaveChangesAsync();

            return acct;
        }
        public async Task<BankAccounts?> UpdateAccountAsync(BankAccounts acct) 
        {
            var updateAcct = await _context.BankAccounts.FindAsync(acct.BankAccountId);

            if (updateAcct is null)
                return null;

            updateAcct.AccountNum = acct.AccountNum;
            updateAcct.AccountBalance = acct.AccountBalance;
            updateAcct.AccountStatus = acct.AccountStatus;

            await _context.SaveChangesAsync();
            return updateAcct;
        }
        public async Task<bool> DeleteAccountAsync(BankAccounts acct)
        {
            var delAcct = await _context.BankAccounts.FindAsync(acct.BankAccountId);

            if (delAcct is null)
                return true;

            _context.Remove(delAcct);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task TransferAsync(Guid fromAccountId,  Guid toAccountId, decimal amount) 
        {
            using var transaction = await _context.Database.BeginTransactionAsync(); //not sure what this is? //might need further clarification verify is authentic

            try   
            {
                var from = await _context.BankAccounts.FindAsync(fromAccountId);
                var to = await _context.BankAccounts.FindAsync(toAccountId);

                if (from == null || to == null)
                    throw new Exception("Account not found!");

                if (from.AccountBalance < amount)
                    throw new Exception("Insufficient funds!");

                from.AccountBalance -= amount;
                to.AccountBalance += amount;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch 
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<List<Transaction>> GetTransactionsByAccountIdAsync(Guid accountId)
        {
            return await _context.Transaction
                .Where(t => t.BankAccountId == accountId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }
    }
}
