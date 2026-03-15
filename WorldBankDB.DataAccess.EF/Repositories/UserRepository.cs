using Microsoft.EntityFrameworkCore;
using WorldBankDB.DataAccess.EF.Context;
using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Repositories.Contract;

namespace WorldBankDB.DataAccess.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WorldBankDBContext _context;
        public UserRepository(WorldBankDBContext context) => _context = context;
        public async Task<Users?> GetUserByIdAsync(Guid userID) => await _context.Users.FindAsync(userID);
        public async Task<List<Users>> GetAllUsersAsync() => await _context.Users.ToListAsync();
    }
}
