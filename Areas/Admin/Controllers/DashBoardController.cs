using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHoaQua.Models;

namespace WebHoaQua.Area.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {
        private readonly ShopContext db = new ShopContext();
        [Authorize (Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<PartialViewResult> listdataRecentSales()
        {
            var listdonhang = await db.DonHang.OrderByDescending(g => g.NgayDat).Take(5).ToListAsync();
            return PartialView(listdonhang);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<PartialViewResult> listdataTopSale()
        {
            var listdonhang = await db.ChiTietDonHang
                .GroupBy(g => g.MaSp)
                .Select(g => new TopSaleViewModel
                {
                    MaSp = (int)g.Key,
                    TenSp = db.SanPham.Where(sp => sp.MaSp == g.Key).Select(sp => sp.TenSp).FirstOrDefault(),
                    HinhAnh = db.SanPham.Where(sp => sp.MaSp == g.Key).Select(sp => sp.HinhAnh).FirstOrDefault(),
                    DonGia = db.SanPham.Where(sp => sp.MaSp == g.Key).Select(sp => sp.Gia).FirstOrDefault(),
                    SoLuongBan = g.Sum(ct => ct.SoLuong),
                    Revenue = g.Sum(ct => ct.SoLuong * ct.DonGia)
                })
                .OrderByDescending(g => g.SoLuongBan)
                .Take(5)
                .ToListAsync();

            return PartialView(listdonhang);
        }

        

    }
}
