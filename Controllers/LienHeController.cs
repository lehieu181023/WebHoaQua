using Microsoft.AspNetCore.Mvc;
using WebHoaQua.Models;

namespace WebHoaQua.Controllers
{
    public class LienHeController : Controller
    {
        private readonly ShopContext db = new ShopContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContactForm([Bind("HoTen,Email,Sdt,ChuDe,TinNhan")] Models.LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                db.LienHe.Add(lienHe);
                await db.SaveChangesAsync();
                return Json(new { success = true, message = "Contact form submitted successfully." });
            }
            return Json(new { success = false, message = "Invalid form data." });
        }
    }
}
