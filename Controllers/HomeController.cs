using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebHoaQua.Models;

namespace WebHoaQua.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopContext db = new ShopContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            var lstpro = db.SanPham.Where(m => m.TrangThai && m.SoLuongTon >= 1).OrderByDescending(m => m.CreateDay).Take(3).ToList();
            ViewData["lstpro"] = lstpro;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> UserStatus()
        {
            var user = new User();
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                user = await db.User.FindAsync(int.Parse(userId));
                if (user == null)
                {
                    return Json(new { success = false, message = "Tài khoản không tồn tại" });
                }
            }
            else {
                user = null;
            }
            return PartialView(user);
        }
    }
}
