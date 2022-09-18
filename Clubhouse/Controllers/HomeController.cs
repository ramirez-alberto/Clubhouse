using System.Security.Claims;
using Clubhouse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using Clubhouse.Data;
using Microsoft.EntityFrameworkCore;

namespace Clubhouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClubhouseContext _context;

        public HomeController(ILogger<HomeController> logger, ClubhouseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var clubhouseContext = _context.Post.Include(p => p.User);
            return View(await clubhouseContext.ToListAsync());
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
            //FindByNameAsync
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserName == username);
            if (user is not null)
                if (user.UserName == username && user.Password == password)
                {
                    var claims = new List<Claim>
                { new Claim(ClaimTypes.Name, username) };
                    var claimIdentity = new ClaimsIdentity(claims, "Login");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity));
                    return Redirect(ReturnUrl == null ? "/Members" : ReturnUrl);
                }
            
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