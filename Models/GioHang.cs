using System;
using System.Collections.Generic;

namespace WebHoaQua.Models;

public partial class GioHang
{
    public int MaGioHang { get; set; }

    public int? MaKh { get; set; }

    public int? MaSp { get; set; }

    public int SoLuong { get; set; }

    public virtual User? MaKhNavigation { get; set; }

    public virtual SanPham? MaSpNavigation { get; set; }
}
