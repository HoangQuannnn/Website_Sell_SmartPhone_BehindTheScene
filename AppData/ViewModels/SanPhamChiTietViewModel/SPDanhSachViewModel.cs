using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.SanPhamChiTietViewModel
{
    public class SPDanhSachViewModel
    {
        public string? SumGuild { get; set; }
        public string? SanPham { get; set; }
        public string? Hang { get; set; }
        public string? Chip { get; set; }
        public string? ManHinh { get; set; }
        public string? CongSac { get; set; }
        public string? Pin { get; set; }
        public string? TheNho { get; set; }
        public int SoMau { get; set; }
        public int SoRam { get; set; }
        public int SoRom { get; set; }
        public int TongSoLuongTon { get; set; }
        public double TongSoLuongDaBan { get; set; }
    }
}
