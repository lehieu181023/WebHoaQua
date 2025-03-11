
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHoaQua.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;


namespace WebHoaQua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhMucSanPhamController : Controller
    {
        private readonly ShopContext db = new ShopContext();
        private const string KeyCache = "DanhMucSanPham";
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<PartialViewResult> ListData()
        {
            List<Models.DanhMucSanPham> listData = null;
            try
            {
                var list = db.DanhMucSanPham.AsQueryable();

                HttpContext.Session.SetString("DanhMucSanPham", JsonConvert.SerializeObject(await list.ToListAsync()));

                listData = await list.OrderByDescending(g => g.CreateDay).ToListAsync();

            }
            catch (Exception ex)
            {
                
            }
            return PartialView(listData);
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Không được để trống Id" });
            }
            Models.DanhMucSanPham objData = await db.DanhMucSanPham.FindAsync(id);
            if (objData == null)
            {
                return Json(new { success = false, message = " Bản ghi không tồn tại" });
            }
            return PartialView(objData);
        }
        [Authorize(Roles = "Admin")]
        public PartialViewResult Create()
        {
            return PartialView();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> Create([Bind("TenDanhMuc,TrangThai")] Models.DanhMucSanPham obj, string linkFileImage_PicBS = "", string linkFile_BangCapBS = "", int Gender = 0, DateTime? DayOfBirth = null, int KhoaId = 0)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.TrangThai = (obj.TrangThai)? true : false;
                    db.DanhMucSanPham.Add(obj);
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

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }

            Models.DanhMucSanPham obj = await db.DanhMucSanPham.FindAsync(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Bản ghi không tồn tại" });
            }
            return PartialView(obj);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<JsonResult> EditPost([Bind("MaDM,TenDanhMuc,TrangThai")] Models.DanhMucSanPham obj,int? MaDM)
        {
            if (MaDM == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }

            var objData = await db.DanhMucSanPham.FindAsync(MaDM);
            if (objData == null)
            {
                return Json(new { success = false, message = "Không thể lưu vì có người dùng khác đang sửa hoặc đã bị xóa" });
            }

            try
            {
                objData.TenDanhMuc = obj.TenDanhMuc;
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

        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int? id)
        {
            DanhMucSanPham obj = null;

            if (id == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }
            try
            {
                obj = db.DanhMucSanPham.Find(id);
                if (obj != null)
                {
                    db.DanhMucSanPham.Remove(obj);
                    db.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Json(new { success = false, message = "Không xóa được bản ghi này" });
            }

            return Json(new { success = true, message = "Bản ghi đã được xóa thành công" });
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> Status(int? id, int type = 0)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }
            var objData = await db.DanhMucSanPham.FindAsync(id);
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