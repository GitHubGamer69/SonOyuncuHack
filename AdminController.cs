using Microsoft.AspNetCore.Mvc;

namespace Tema_Giydirme.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
