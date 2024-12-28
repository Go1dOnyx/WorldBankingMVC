using WorldBankDB.DataAccess.EF.Repositories.Contract;
using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace WorldBankDB.DataAccess.EF.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private WorldBankDBContext _context;
        public AccountRepository(WorldBankDBContext context) 
        {
            _context = context;
        }
        public async Task<List<Accounts>> GetAllAccountsAsync() => await _context.Accounts.ToListAsync();
        public async Task<Accounts?> GetAcctByIdAsync(Guid acctID) => await _context.Accounts.FindAsync(acctID);
        public async Task<Accounts?> GetAcctByNumAsync(int acctNum) => await _context.Accounts.FirstOrDefaultAsync(e => e.AccountNum == acctNum);
        public async Task<List<Accounts>> GetListByUserIdAsync(Guid userID) => await _context.Accounts.Where(e => e.UserId == userID).ToListAsync();
        public async Task<Accounts> CreateAccountAsync(Accounts acct) //verify if acct model valid data
        {
            await _context.AddAsync(acct);
            await _context.SaveChangesAsync();

            return acct;
        }
        public async Task<Accounts> UpdateAccountAsync(Accounts acct) 
        {
            var updateAcct = await _context.Accounts.FindAsync(acct.AccountId);

            if (updateAcct == null) { throw new InvalidOperationException("Could not find account."); }

            updateAcct.AccountType = acct.AccountType;
            updateAcct.AccountNum = acct.AccountNum;
            updateAcct.RoutingNum = acct.RoutingNum;
            updateAcct.Amount = acct.Amount;
            updateAcct.IsLocked = acct.IsLocked;

            try
            {
                await _context.SaveChangesAsync();
                return updateAcct;
            }
            catch (Exception ex) { throw new InvalidOperationException($"Could not update account. Error: {ex.Message} "); }
        }
        public async Task<bool> DeleteAccountAsync(Accounts acct) 
        {
            var delAcct = await _context.Accounts.FindAsync(acct.AccountId);

            if(delAcct == null) { throw new InvalidOperationException("Account not found."); }

            try
            {
                _context.Remove(delAcct);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex) { throw new InvalidOperationException($"Account could not be deleted. {ex.Message}"); }   
        }
    }
}
