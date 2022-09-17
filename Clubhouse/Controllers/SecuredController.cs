using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Clubhouse.Controllers
{
    [Authorize]
    public class SecuredController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
