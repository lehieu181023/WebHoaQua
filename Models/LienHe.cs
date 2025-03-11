using System;
using System.Collections.Generic;

namespace WebHoaQua.Models;

public partial class LienHe
{
    public int MaLh { get; set; }

    public string? HoTen { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? ChuDe { get; set; }

    public string? TinNhan { get; set; }

    public DateTime CreateDay { get; set; }

    public bool IsRead { get; set; }
}
