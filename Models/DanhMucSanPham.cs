using System;
using System.Collections.Generic;

namespace WebHoaQua.Models;

public partial class DanhMucSanPham
{
    public int MaDm { get; set; }

    public string TenDanhMuc { get; set; } = null!;

    public bool TrangThai { get; set; }

    public DateTime CreateDay { get; set; }

    public virtual ICollection<SanPham> SanPham { get; set; } = new List<SanPham>();
}
