using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Services.Contract;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using Microsoft.AspNetCore.Identity;

namespace WorldBankDB.DataAccess.EF.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        public UserService(IUserRepository userRepository, UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<SignInResult> LoginAsync(string email, string password, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return SignInResult.Failed;
            if(user.Status != UserStatus.Active) 
                return SignInResult.LockedOut;

            return await _signInManager.PasswordSignInAsync
                (
                    user,
                    password,
                    rememberMe, //or isPersistent: true
                    lockoutOnFailure: true
                );
        }
        public async Task<IdentityResult> RegisterAsync(Users user) 
        {
            var newUser = new Users 
            {
                Email = user.Email,
                UserName = user.Email,
                FirstName = user.FirstName,
                MiddleName = user.LastName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                CreatedAt = DateTime.UtcNow,
            };

            var result = await _userManager.CreateAsync(newUser, user.PasswordHash!);

            if (result.Succeeded) 
                await _userManager.AddToRoleAsync(user, "User");

            return result;
        }
        public async Task<IdentityResult> DeleteAsync(Users user) 
        {
            //Want to use _userManager, to properly delete roles, claims,
            //and maintain consistency than doing it manually
            //The same for update
            var delUser = await _userManager.FindByIdAsync(user.Id.ToString());

            if (delUser == null)
                return IdentityResult.Failed();

            return await _userManager.DeleteAsync(delUser);
        }
        public async Task<IdentityResult> UpdateAsync(Users user)
        {
            var updatedUser = await _userManager.FindByIdAsync(user.Id.ToString());

            if (updatedUser == null)
                return IdentityResult.Failed();

            updatedUser.Email = user.Email;
            updatedUser.FirstName = user.FirstName;
            updatedUser.MiddleName = user.MiddleName;
            updatedUser.LastName = user.LastName;
            updatedUser.PhoneNumber = user.PhoneNumber;
            updatedUser.CreatedAt = DateTime.UtcNow;

            return await _userManager.UpdateAsync(updatedUser);
        }
        public async Task<string?> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return null;

            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }
        public async Task<IdentityResult> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return IdentityResult.Failed();

            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }
        public async Task<Users?> GetByIdAsync(Guid userID) => await _userRepository.GetUserByIdAsync(userID);
        public async Task<List<Users>> GetAllAsync() => await _userRepository.GetAllUsersAsync();
        public async Task LogoutAsync() => await _signInManager.SignOutAsync();
    }
}
