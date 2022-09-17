using System.Security.Claims;
using Clubhouse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Clubhouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string? ReturnUrl)
        {

            if (username == "admin" && password == "admin")
            {
                var claims = new List<Claim>
                { new Claim(ClaimTypes.Name, username) };
                var claimIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimIdentity));
                return Redirect(ReturnUrl == null ? "/Secured" : ReturnUrl);
            }
            else
                return View();


        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}