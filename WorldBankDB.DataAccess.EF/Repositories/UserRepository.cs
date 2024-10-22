using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBankDB.DataAccess.EF.Context;
using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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
            var result = await _userManager.CreateAsync(user);
            try 
            {
                if (result.Succeeded)
                {
                    await _context.AddAsync(result);
                    await _context.SaveChangesAsync();
                    await _context.DisposeAsync();

                    return IdentityResult.Success;
                }

                return IdentityResult.Failed(result.Errors.ToArray());
            }
            catch (Exception ex) 
            {
                return IdentityResult.Failed(new IdentityError { Description = $"An error occurred when creating user: {ex.Message}" });
            }

        }

        public async Task<SignInResult> LoginUserAsync(string userEmail, string pass, bool isPersistent, bool lockoutOnFailure) 
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null) 
            {
                user = await _userManager.FindByNameAsync(userEmail);
            }
            if (user != null) 
            {
                return await _signInManager.PasswordSignInAsync(userEmail, pass, isPersistent: false, lockoutOnFailure: false);
            }

            return SignInResult.Failed;
        }
        public async Task SignOutUserAsync() 
        {
            await _signInManager.SignOutAsync();
        }

        //Regular Methods 
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
 