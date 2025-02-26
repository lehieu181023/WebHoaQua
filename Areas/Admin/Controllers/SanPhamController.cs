
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHoaQua.Models;
using Newtonsoft.Json;


namespace WebHoaQua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly ShopContext db = new ShopContext();
        private const string KeyCache = "SanPham";

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> ListData()
        {
            List<Models.SanPham> listData = null;
            try
            {
                var list = db.SanPham.AsQueryable();

                listData = await list.OrderByDescending(g => g.CreateDay).ToListAsync();

            }
            catch (Exception ex)
            {
                
            }
            return PartialView(listData);
        }

        public async Task<ActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Không được để trống Id" });
            }
            Models.SanPham objData = await db.SanPham.FindAsync(id);
            if (objData == null)
            {
                return Json(new { success = false, message = " Bản ghi không tồn tại" });
            }
            return PartialView(objData);
        }

        public PartialViewResult Create()
        {
            var lstDanhMuc = db.DanhMucSanPham.ToList();
            ViewData["lstDanhMuc"] = lstDanhMuc;
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> Create([Bind("MaSP,TenSp,MoTa,Gia,SoLuongTon,HinhAnh,MaDm,TrangThai")] Models.SanPham obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.TrangThai = (obj.TrangThai)? true : false;
                    db.SanPham.Add(obj);
                    await db.SaveChangesAsync();
                }
                else
                {
                    return Json(new { success = false, message = "Lỗi dữ liệu nhập" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Thêm mới thất bại" });
            }
            return Json(new { success = true, message = "Thêm mới thành công" });
        }

        
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }

            Models.SanPham obj = await db.SanPham.FindAsync(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Bản ghi không tồn tại" });
            }
            var lstDanhMuc = db.DanhMucSanPham.ToList();
            ViewData["lstDanhMuc"] = lstDanhMuc;
            return PartialView(obj);
        }

        [HttpPost]

        public async Task<JsonResult> EditPost([Bind("MaSp,TenSp,MoTa,Gia,SoLuongTon,HinhAnh,MaDm,TrangThai")] Models.SanPham obj,int? MaSp)
        {
            if (MaSp == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }

            var objData = await db.SanPham.FindAsync(MaSp);
            if (objData == null)
            {
                return Json(new { success = false, message = "Không thể lưu vì có người dùng khác đang sửa hoặc đã bị xóa" });
            }

            try
            {
                objData.TenSp = obj.TenSp;
                objData.MoTa = obj.MoTa;
                objData.Gia = obj.Gia;
                objData.SoLuongTon = obj.SoLuongTon;
                objData.HinhAnh = obj.HinhAnh;
                objData.MaDm = obj.MaDm;
                objData.TrangThai = obj.TrangThai;
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var databaseEntry = entry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    return Json(new { success = false, message = "Bản ghi này đã bị xóa bởi người dùng khác" });
                }
                else
                {
                    return Json(new { success = false, message = "Bản ghi này đã bị sửa bởi người dùng khác" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Không thể lưu được" });
            }

            return Json(new { success = true, message = "Cập nhật thành công" });
        }


        public JsonResult Delete(int? id)
        {
            SanPham obj = null;

            if (id == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }
            try
            {
                obj = db.SanPham.Find(id);
                if (obj != null)
                {
                    db.SanPham.Remove(obj);
                    db.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Json(new { success = false, message = "Không xóa được bản ghi này" });
            }

            return Json(new { success = true, message = "Bản ghi đã được xóa thành công" });
        }

        
        public async Task<JsonResult> Status(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }
            var objData = await db.SanPham.FindAsync(id);
            if (objData == null)
            {
                return Json(new { success = false, message = "Bản ghi đã bị xóa" });
            }
            try
            {
                objData.TrangThai = !objData.TrangThai;
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return Json(new { success = false, message = "Không thay đổi được trạng thái bản ghi này" });
            }

            return Json(new { success = true, message = "Bản ghi đã được cập nhật trạng thái thành công" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}