using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<Accounts> CreateAccountAsync(Accounts acct) //verify if acct model valid data
        {
            if (acct != null) 
            {
                try
                {
                    await _context.AddAsync(acct);
                    await _context.SaveChangesAsync();
                    await _context.DisposeAsync();

                    return acct;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Account could not be created. Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException("Invalid model data or empty.");
        }
        public async Task<Accounts> UpdateAccountAsync(Accounts acct) 
        {
            Accounts updateAcct = await _context.Accounts.FindAsync(acct.AccountId);

            if (updateAcct != null) 
            {
                try
                {
                    updateAcct.AccountType = acct.AccountType;
                    updateAcct.AccountNum = acct.AccountNum;
                    updateAcct.RoutingNum = acct.RoutingNum;
                    updateAcct.Amount = acct.Amount;
                    updateAcct.IsLocked = acct.IsLocked;

                    await _context.SaveChangesAsync();
                    await _context.DisposeAsync();

                    return updateAcct;
                }
                catch (Exception ex) 
                {
                    throw new InvalidOperationException($"Could not make change for account of {acct.AccountNum}. Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException($"Account of {acct.AccountNum} was not found.");
        }
        public async Task<Accounts> GetAcctByIdAsync(Guid acctID) 
        {
            Accounts getAcct = await _context.Accounts.FindAsync(acctID);

            if (getAcct != null)
                return getAcct;
            else
                throw new InvalidOperationException($"Could not find account of {acctID}");
        }
        public async Task<List<Accounts>> GetAllAccountAsync() 
        {
            List<Accounts> acctList = await _context.Accounts.ToListAsync();

            await _context.DisposeAsync();

            if (acctList != null)
                return acctList;
            else
                throw new InvalidOperationException("Could not retrieve all list of accounts of users");
        }
        public async Task<bool> DeleteAccountAsync(Accounts acct) 
        {
            Accounts delAcct = await _context.Accounts.FindAsync(acct.AccountId);

            if (delAcct != null) 
            {
                try
                {
                    _context.Remove(delAcct);

                    await _context.SaveChangesAsync();

                    await _context.DisposeAsync();

                    return true;
                }
                catch (Exception ex) 
                {
                    throw new InvalidOperationException($"Account of {acct.AccountNum} could not be deleted. Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException("Could not find account.");
        }
    }
}
