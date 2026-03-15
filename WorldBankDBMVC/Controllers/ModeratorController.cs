using Microsoft.AspNetCore.Mvc;

namespace WorldBankDBMVC.Controllers
{
    public class ModeratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
