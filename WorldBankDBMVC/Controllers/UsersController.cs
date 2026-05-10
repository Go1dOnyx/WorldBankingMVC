//using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WorldBankDB.DataAccess.EF.Services;

//using WorldBankDBMVC.DataAcess.EF.Context;
//using WorldBankDBMVC.DataAcess.EF.Models;
//using WorldBankDBMVC.DataAcess.EF.Repositories;
using WorldBankDBMVC.Models;

namespace WorldBankDBMVC.Controllers
{
    [Authorize(Roles = "User")]
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        public UsersController(UserService userService) => _userService = userService;
        public IActionResult Index()
        {
            AccountViewModel model = new AccountViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]AccountViewModel model) 
        {
            if(ModelState.IsValid) 
            {
                var result = await _userService.LoginAsync(model.EmailAddress!, model.Password!, model.RemeberMe);

                if(result.Succeeded)
                    return RedirectToAction("Index", "Home");
                if (result.IsLockedOut)
                    return RedirectToAction("AccessDenied");
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
        /*
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {

        }

        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Dashboard() 
        {
        
        }
        */
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var token = await _userService.GeneratePasswordResetTokenAsync(email);
            if (token == null)
                return View("ForgotPasswordConfirmation");

            //Make sure to encode it to prevent broken token, invalid token errors, or url corruption
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            var callbackUrl = Url.Action("ResetPassword", "Account", new { encodedToken, email }, protocol: HttpContext.Request.Scheme);

            //Send callbackUrl via Email service
            return View("ForgotPasswordConfirmation");
        }

        [HttpPost]
        public async Task<IActionResult> RestPassword(PasswordResetViewModel model) 
        {
            if(!ModelState.IsValid)
                return View(model);

            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Token));
            var result = await _userService.ResetPasswordAsync(model.Email, decodedToken, model.NewPassword);

            if (result.Succeeded)
                return RedirectToAction("Login");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }
    }
}
