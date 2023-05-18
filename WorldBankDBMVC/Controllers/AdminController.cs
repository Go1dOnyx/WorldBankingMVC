using Microsoft.AspNetCore.Mvc;

namespace WorldBankDBMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Back() {
            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult SignUp() {
            return View("~/Views/SignUp/SignUp.cshtml");
        }
    }
}
