using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WorldBankDB.DataAccess.EF.Context;
using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Repositories.Contract;

namespace WorldBankDB.DataAccess.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WorldBankDBContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public UserRepository(WorldBankDBContext context, UserManager<Users> userManager, SignInManager<Users> singInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = singInManager;
        }

        //Methods using Identity
        public async Task<IdentityResult> CreateUserAsync(Users user)
        {
             return await _userManager.CreateAsync(user);
        }
        public async Task<IdentityResult> DeleteUserAsync(Users user)
        {
            var delUser = await _userManager.FindByIdAsync(user.UserId.ToString());

            return await _userManager.DeleteAsync(delUser!);
        }
        public async Task<SignInResult> LoginUserAsync(string userEmail, string pass) 
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user == null) 
            {
                user = await _userManager.FindByNameAsync(userEmail);
            }
            if (user != null) 
            {
                return await _signInManager.PasswordSignInAsync(userEmail, pass, isPersistent: true, lockoutOnFailure: true);
            }

            return SignInResult.Failed;
        }
        public async Task<IdentityResult> ChangePasswordAsync(string userEmail, string oldPassword, string newPassword)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(e => e.UserName == userEmail || e.EmailAddr == userEmail && e.Password == oldPassword);

            if (getUser != null)
            {
                var result = await _userManager.ChangePasswordAsync(getUser, oldPassword, newPassword);

                return IdentityResult.Success;
            }

            return IdentityResult.Failed();
        }
        public async Task<IdentityResult> UpdateUserAsync(Users user)
        {
            var updateUser = await _userManager.FindByIdAsync(user.UserId.ToString());

            if (updateUser != null) 
            {
                updateUser.Username = user.Username;
                updateUser.EmailAddr = user.EmailAddr;
                updateUser.FirstName = user.FirstName;
                updateUser.MiddleName = user.MiddleName;
                updateUser.LastName = user.LastName;
                updateUser.Status = user.Status;

                return await _userManager.UpdateAsync(updateUser);
            }

            return IdentityResult.Failed();
        }
        public async Task SignOutUserAsync() =>  await _signInManager.SignOutAsync();

        //Regular Methods 
        public async Task<Users> GetUserByIdAsync(Guid userID) 
        {
            var getUser = await _userManager.FindByIdAsync(userID.ToString());

            if (getUser != null)
                return getUser;

            throw new InvalidOperationException("Could not retrieve user.");
        }
        public async Task<Users> GetUserByUserEmailAsync(string userEmail)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(e => e.Username == userEmail || e.EmailAddr == userEmail);

            if (getUser != null)
                return getUser;

            throw new InvalidOperationException("Could not retrieve user.");
        }
        public async Task<List<Users>> GetAllUsersAsync() => await _userManager.Users.ToListAsync();
    }
}
 