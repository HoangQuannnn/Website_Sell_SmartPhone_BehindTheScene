using App_Data.ViewModels.DanhGia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.HoaDon
{
    public class SanPhamTest
    {
        public string? IdSanPhamChiTiet { get; set; }
        public string? TenSanPham { get; set; }
        public string? TenMauSac { get; set; }
        public int? DungLuongRam { get; set; }
        public int? DungLuongRom { get; set; }
        public string? TenHang { get; set; }
        public int? SoLuong { get; set; }
        public double? GiaBan { get; set; }
        public double? TongTien { get; set; }
        public int? TrangThaiGiaoHang { get; set; }
        public DanhGiaViewModel? DanhGia { get; set; }
        public List<string?> LinkAnh { get; set; }

        //public static implicit operator SanPhamTest(SanPhamTest v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
