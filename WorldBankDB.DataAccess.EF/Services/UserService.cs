using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Repositories;
using WorldBankDB.DataAccess.EF.Services.Contract;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using Microsoft.AspNetCore.Identity;

namespace WorldBankDB.DataAccess.EF.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IdentityResult> RegisterAsync(Users user) 
        {
            if (user != null) 
            {
                await _userRepository.CreateUserAsync(user);

                return IdentityResult.Success;
            }

            return IdentityResult.Failed();
        }
        public async Task<IdentityResult> DeleteAsync(Users user) 
        {
            if (user != null) 
                return await _userRepository.DeleteUserAsync(user);

            return IdentityResult.Failed();
        }
        public async Task<SignInResult> LoginAsync(string userEmail, string password) 
        {
            if (userEmail != string.Empty && password != string.Empty) 
                return await _userRepository.LoginUserAsync(userEmail, password);

            return SignInResult.Failed;
        }
        public async Task<IdentityResult> ChangePasswordAsync(string userEmail, string oldPassword, string newPassword) 
        {
            if(userEmail != string.Empty && (oldPassword != newPassword)) 
                return await _userRepository.ChangePasswordAsync(userEmail, oldPassword, newPassword);

            return IdentityResult.Failed();
        }
        public async Task<IdentityResult> EditAsync(Users user)
        {
            if (user != null)
                return await _userRepository.UpdateUserAsync(user);

            return IdentityResult.Failed();
        }
        public async Task SignOutAsync() => await _userRepository.SignOutUserAsync();

        //Non-Identity Methods
        public async Task<Users> GetByIdAsync(Guid userID) 
        {
            if (userID != Guid.Empty) 
                return await _userRepository.GetUserByIdAsync(userID);

            throw new InvalidOperationException("Empty Guid");
        }
        public async Task<Users> GetByEmailAsync(string userEmail) 
        {
            if(userEmail != null)
                return await _userRepository.GetUserByUserEmailAsync(userEmail);

            throw new InvalidOperationException("Username or email is null.");
        }
        public async Task<List<Users>> GetAllAsync() 
        {
            var listOfUsers = await _userRepository.GetAllUsersAsync();

            if (listOfUsers != null)
                return listOfUsers;

            throw new InvalidOperationException("Could not retrieve list of users.");
        }
    }
}
