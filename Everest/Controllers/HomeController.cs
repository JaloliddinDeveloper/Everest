using Microsoft.AspNetCore.Mvc;

namespace Everest.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index() => View();
    }
}
