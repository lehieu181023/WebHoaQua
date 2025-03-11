using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHoaQua.Models;

namespace WebHoaQua.Controllers
{
    public class CuaHangController : Controller
    {
        private readonly ShopContext db = new ShopContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<PartialViewResult> listdata(int page = 1, int MaDm =0 )
        {
            var pageSize = 3;
            List<Models.SanPham> listData = null;
            try
            {
                var list = db.SanPham.AsQueryable().Where(m => m.TrangThai);
                list = list.OrderByDescending(g => g.CreateDay);
                if (MaDm != 0)
                {
                    list = list.Where(m => m.MaDm == MaDm);
                }
                var count = Math.Ceiling((double)list.Count() / pageSize);
                listData = await list.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                ViewData["lstpro"] = listData;
                var lstdmsp = db.DanhMucSanPham.Where(m => m.TrangThai).ToList();
                ViewData["lstdmsp"] = lstdmsp;
                ViewBag.CurrentPage = page;
                ViewBag.totalPage = count;

            }
            catch (Exception ex)
            {

            }
            return PartialView(listData);
        }
    }
}
