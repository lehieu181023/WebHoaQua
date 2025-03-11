using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebHoaQua.Models;

namespace WebHoaQua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongBaoController : Controller
    {
        private readonly ShopContext db = new ShopContext();
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ThongBaoo()
        {
            var thongbaoDH = db.DonHang.Where(x => x.IsRead == false).ToList();
            var thongbaoLH = db.LienHe.Where(x => x.IsRead == false).ToList();
            ViewData["ThongBaoDH"] = thongbaoDH;
            ViewData["ThongBaoLH"] = thongbaoLH;
            return PartialView();
        }
    }
}
