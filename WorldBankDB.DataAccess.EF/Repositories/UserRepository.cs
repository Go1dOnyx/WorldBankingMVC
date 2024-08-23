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

            }
        }
    }
}
