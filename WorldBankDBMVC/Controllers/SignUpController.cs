using Microsoft.AspNetCore.Mvc;
using WorldBankDBMVC.DataAcess.EF.Context;
using WorldBankDBMVC.DataAcess.EF.Models;
using WorldBankDBMVC.DataAcess.EF.Repositories;
using WorldBankDBMVC.Models;
using System.Net.Mail;
using Microsoft.IdentityModel.Tokens;

namespace WorldBankDBMVC.Controllers
{
    public class SignUpController : Controller
    {
        private WorldBankDBContext _dbContext;
        public SignUpController(WorldBankDBContext DbContext) { 
            _dbContext = DbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRecord(SignUpViewModel createAccount) {
            ViewBag.Message = null;
            string existingEmail = createAccount.EmailAddress;
            string existingUser = createAccount.UserName;
            //Checks if account exist from checkAccount indentifier
            var checkAccount = _dbContext.Accounts.FirstOrDefault(x => x.EmailAddress == existingEmail || x.UserName == existingUser);
            //If it does not exist then create new record
            if (checkAccount != null) {
                ViewBag.Message = "ExistingAccount";
            }
            else {
                ViewBag.Message = null;
                if (ModelState.IsValid)
                {
                    var newEntity = new Accounts
                    {
                        UserName = createAccount.UserName,
                        EmailAddress = createAccount.EmailAddress,
                        Password = createAccount.Password,
                        FirstName = createAccount.FirstName,
                        MiddleName = string.IsNullOrEmpty(createAccount.MiddleName) ? "" : createAccount.MiddleName,
                        LastName = createAccount.LastName,
                        CheckingBalance = createAccount.CheckingBalance,
                        SavingBalance = createAccount.SavingsBalance
                    };

                    _dbContext.Accounts.Add(newEntity);
                    _dbContext.SaveChanges();

                    //returns back to login page
                    return View("~/Views/Home/Index.cshtml");
                }
            }

            //stays back to sign up form if account exist or any errors
            return View("~/Views/SignUp/SignUp.cshtml");
        }
        public IActionResult Back() { 
            return View("~/Views/Home/Index.cshtml");
        }

        /*
        public bool ValidationCheck(SignUpViewModel model) {
            string invalidUserCharacters = "#$%^&*()=+{}[]?/|";
            string invalidPasswordCharacters = "(){}[]|%?/";
            string validName = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            model.isValid = true;

            if (invalidUserCharacters.Contains(model.UserName)) {
                model.ValidResponse += "Username format is invalid.";
                model.isValid = false;
            }
            if (invalidPasswordCharacters.Contains(model.Password)) {
                model.ValidResponse += " Password format is invalid.";
                model.isValid = false;
            }
            if (!validName.Contains(model.FirstName) || !validName.Contains(model.LastName))
            {
                model.ValidResponse += " Invalid Name Format.";
                model.isValid = false;
            }

            try {
                MailAddress mailValidation = new MailAddress(model.EmailAddress);
                model.isValid = true;
            }
            catch {
                model.ValidResponse += " Email Addres Format Invalid.";
                model.isValid = false;
            }

            return model.isValid;
        }
        */
    }
}
