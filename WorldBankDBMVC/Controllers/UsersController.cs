using Microsoft.AspNetCore.Mvc;
//using WorldBankDBMVC.DataAcess.EF.Context;
//using WorldBankDBMVC.DataAcess.EF.Models;
//using WorldBankDBMVC.DataAcess.EF.Repositories;
using WorldBankDBMVC.Models;

namespace WorldBankDBMVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            AccountViewModel model = new AccountViewModel();
            return View(model);
        }
    }
}
