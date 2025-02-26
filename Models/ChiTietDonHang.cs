using System;
using System.Collections.Generic;

namespace WebHoaQua.Models;

public partial class ChiTietDonHang
{
    public int MaCtdh { get; set; }

    public int? MaDh { get; set; }

    public int? MaSp { get; set; }

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual DonHang? MaDhNavigation { get; set; }

    public virtual SanPham? MaSpNavigation { get; set; }
}
