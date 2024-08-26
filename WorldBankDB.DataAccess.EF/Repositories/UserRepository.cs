using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBankDB.DataAccess.EF.Context;
using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace WorldBankDB.DataAccess.EF.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private WorldBankDBContext _context;

        public UserRepository(WorldBankDBContext context)
        {
            _context = context;
        }
        public async Task<Users> CreateUserAsync(Users user)
        {
            if (user != null)
            {
                try
                {
                    await _context.AddAsync(user);
                    await _context.SaveChangesAsync();
                    await _context.DisposeAsync();

                    return user;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"User could not be created. Error {ex.Message}");
                }
            }

            throw new InvalidOperationException("Invalid model data.");
        }
        public async Task<Users> UpdateUserAsync(Users user) 
        {
            Users updateUser = await _context.Users.FindAsync(user.UserId);

            if (updateUser != null) 
            {
                try
                {
                    updateUser.Username = user.Username;
                    updateUser.EmailAddr = user.EmailAddr;
                    updateUser.Password = user.Password;
                    updateUser.FirstName = user.FirstName;
                    updateUser.MiddleName = user.MiddleName;
                    updateUser.LastName = user.LastName;
                    updateUser.Status = user.Status;

                    await _context.SaveChangesAsync();
                    await _context.DisposeAsync();

                    return updateUser;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Could not update user. Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException("Could not find user.");
        }
        public async Task<Users> GetUserByIdAsync(Guid userID) 
        {
            Users getUser = await _context.Users.FindAsync(userID);

            await _context.DisposeAsync();

            if (getUser != null)
                return getUser;
            else
                throw new InvalidOperationException("Could not retrieve user.");
        }
        public async Task<List<Users>> GetAllUsersAsync() 
        {
            List<Users> userList = await _context.Users.ToListAsync();

            await _context.DisposeAsync();

            if (userList != null)
                return userList;
            else
                throw new InvalidOperationException("Could not retrieve user list.");
        }
        public async Task<bool> DeleteUserAsync(Users user) 
        {
            Users delUser = await _context.Users.FindAsync(user.UserId);

            if (delUser != null) 
            {
                try
                {
                    _context.Remove(delUser);

                    await _context.SaveChangesAsync();
                    await _context.DisposeAsync();

                    return true;
                }
                catch (Exception ex) 
                {
                    throw new InvalidOperationException($"Could not delete user. Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException("Could not find user.");
        }
    }
}
 