using Microsoft.EntityFrameworkCore;

namespace WebHoaQua.Models
{
    public partial class SanPham {
        ShopContext db = new ShopContext();

        public DanhMucSanPham DanhMucSanPham => db.DanhMucSanPham.Find(MaDm);

    }
}
