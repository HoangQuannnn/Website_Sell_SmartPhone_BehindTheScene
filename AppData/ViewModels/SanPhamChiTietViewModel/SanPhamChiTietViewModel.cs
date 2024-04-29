using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.SanPhamChiTietViewModel
{
    public class SanPhamChiTietViewModel
    {
        public string? IdChiTietSp { get; set; }
        public string? Ma { get; set; }
        public string? MoTa { get; set; }
        public int? SoLuongTon { get; set; }
        public int? SoLuongDaBan { get; set; }
        public double? GiaBan { get; set; }
        public string NgayTao { get; set; }
        public double? GiaNhap { get; set; }
        public double? GiaThucTe { get; set; }
        public string? KhoiLuong { get; set; }
        public string? SanPham { get; set; }
        public string? Ram { get; set; }
        public string? Rom { get; set; }
        public string? CongSac { get; set; }
        public string? Hang { get; set; }
        public string? Chip { get; set; }
        public string? ManHinh { get; set; }
        public string? TheNho { get; set; }
        public string? TheSim { get; set; }
        public string? CameraTruoc { get; set; }
        public string? CameraSau { get; set; }
        public string? Pin { get; set; }
        public string? MauSac { get; set; }
        public int? TrangThai { get; set; }
        public List<string>? ListTenAnh { get; set; }
    }
}
