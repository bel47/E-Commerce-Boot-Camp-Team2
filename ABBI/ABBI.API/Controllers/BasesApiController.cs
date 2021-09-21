using Microsoft.AspNetCore.Mvc;

namespace ABBI.API.Controllers
{
    public class BasesApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
