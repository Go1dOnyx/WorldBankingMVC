using Microsoft.AspNetCore.Mvc;
using WorldBankDBMVC.Models;
using WorldBankDB.DataAccess.EF.Context;
using WorldBankDB.DataAccess.EF.Repositories.Contract;

namespace WorldBankDBMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly WorldBankDBContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        public HomeController(WorldBankDBContext dbContext, IUserRepository userRepository, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = null;
            return View();
        }

        [HttpPost]
        public IActionResult LoginForm([FromForm]LoginViewModel model) 
        {
            ViewBag.Message = model.UserEmail + ", " + model.Password;
            return View("Index");
        }

      //  [HttpPost]
     //   public IActionResult Index(AccountViewModel accountModel) 
      //  {
           
       // }

        public IActionResult Privacy()
        {
            return View();
        }
        /*
        public IActionResult Admin( AccountViewModel model) {
            return View("~/Views/Admin/Index.cshtml", model);
        }
        public IActionResult Users(AccountViewModel model) {
            return View("~/Views/Users/Index.cshtml",model);
        }
        [HttpPost]
        public IActionResult Deposit(int id, decimal amount) {
            Accounts account = _dbContext.Accounts.Find(id);
            account.CheckingBalance += amount;
            _dbContext.SaveChanges();

            return RedirectToAction("Users", account);
        }
        [HttpPost]
        public IActionResult Withdraw(int id, decimal amount) {
            Accounts account = _dbContext.Accounts.Find(id);
            account.CheckingBalance = account.CheckingBalance - amount;
            _dbContext.SaveChanges();

            return RedirectToAction("Users", account);
        }
        [HttpPost]
        public IActionResult DepositSaving(int id, decimal amount) {
            Accounts account = _dbContext.Accounts.Find(id);
            account.SavingBalance += amount;
            _dbContext.SaveChanges();

            return RedirectToAction("Users", account);
        }
        [HttpPost]
        public IActionResult WithdrawSaving(int id, decimal amount)
        {
            Accounts account = _dbContext.Accounts.Find(id);
            account.SavingBalance -= amount;
            _dbContext.SaveChanges();

            return RedirectToAction("Users", account);
        }
        public IActionResult SignUp() { 
            return View("~/Views/SignUp/SignUp.cshtml");
        }
        public IActionResult Back() {
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */
    }
}

/*
     ViewBag.Message = null;
            string UserName = accountModel.UserName;
            string Password = accountModel.Password;

            var acctValidation = _dbContext.Accounts.FirstOrDefault(u => u.UserName == UserName && u.Password == Password);
            if (acctValidation != null)
            {
                //If the account exist
                ViewBag.Message = "Exist";

              //  accountModel.AccountRules = accountModel.UserName == "Admin1" && accountModel.Password == "@dmin_Pass23" ? AccountViewModel.UserRoles.AdminUser : AccountViewModel.UserRoles.StandardUser;
                accountModel.AccountRules = accountModel.AdminNameList.Contains(accountModel.UserName) || accountModel.AdminNameList.Contains(accountModel.Password) ? AccountViewModel.UserRoles.AdminUser : AccountViewModel.UserRoles.StandardUser;
                switch (accountModel.AccountRules) {
                    case AccountViewModel.UserRoles.AdminUser:
                        List<Accounts> accountList = _dbContext.Accounts
                       .Select(a => new Accounts
                       {
                           // Map properties and handle null values
                           MiddleName = a.MiddleName ?? "N/A",
                           // Other properties...
                           AccountId = a.AccountId,
                           UserName = a.UserName,
                           EmailAddress = a.EmailAddress,
                           Password = a.Password,
                           FirstName = a.FirstName,
                           LastName = a.LastName,
                           CheckingBalance = a.CheckingBalance,
                           SavingBalance = a.SavingBalance
                       })
                       .ToList();

                        AccountViewModel model = new AccountViewModel();
                        model.GetAccountList = accountList;
                        return Admin(model);

                    case AccountViewModel.UserRoles.StandardUser:
                        AccountViewModel userModel = new AccountViewModel();
                        userModel.AccountID = acctValidation.AccountId;
                        userModel.EmailAddress = acctValidation.EmailAddress;
                        userModel.UserName = acctValidation.UserName;
                        userModel.Password = acctValidation.Password;
                        userModel.FirstName = acctValidation.FirstName;
                        userModel.MiddleName = acctValidation.MiddleName;
                        userModel.LastName = acctValidation.LastName;
                        userModel.CheckingAccount = acctValidation.CheckingBalance;
                        userModel.SavingsAccount = acctValidation.SavingBalance;

                        return Users(userModel);
                }
            }
            else {
                //If it does not exist
                ViewBag.Message = "ExistNot";
            }   

            return View(accountModel);
 */