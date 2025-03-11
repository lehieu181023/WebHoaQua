using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHoaQua.Models;

namespace WebHoaQua.Controllers
{
    public class TraiCayController : Controller
    {
        private readonly ShopContext db = new ShopContext();
        public async Task<IActionResult> Index(int MaSp = 0)
        {
            if (MaSp == 0)
            {
                TempData["ErrorMessage"] = "Mã sản phẩm không hợp lệ!";
                return RedirectToAction("Index", "Home"); // Chuyển hướng về trang chủ
            }

            SanPham sanpham = await db.SanPham.FindAsync(MaSp);

            if (sanpham == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy sản phẩm!";
                return RedirectToAction("Index", "Home"); // Chuyển hướng về trang chủ
            }

            var lstpro = db.SanPham.Where(m => m.TrangThai && m.MaDm == sanpham.MaDm && m.MaSp != sanpham.MaSp).OrderByDescending(g => g.CreateDay).Take(3).ToList();
            ViewData["lstpro"] = lstpro;

            return View(sanpham);
        }

        

    }
}
