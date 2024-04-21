using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class SanPhamChiTiet
    {
        [Key]
        public string? IdChiTietSp { get; set; }
        public string? Ma { get; set; }
        public bool? Day { get; set; }
        public string? MoTa { get; set; }
        public int? SoLuongTon { get; set; }
        public int? SoLuongDaBan { get; set; }
        public DateTime? NgayTao { get; set; }
        public bool? NoiBat { get; set; }
        public double? GiaBan { get; set; }
        public double? GiaNhap { get; set; }
        public double? GiaThucTe { get; set; }
        public double? KhoiLuong { get; set; }
        public int? TrangThai { get; set; }
        public int? TrangThaiSale { get; set; }
        public string IdSanPham { get; set; }
        public string IdMauSac { get; set; }
        public string IdRam { get; set; }
        public string IdRom { get; set; }
        public string IdHang { get; set; }
        public string IdCongSac { get; set; }
        public string IdChip { get; set; }
        public string IdManHinh { get; set; }
        public string IdTheNho { get; set; }
        public string IdPin { get; set; }
        public virtual Hang Hang { get; set; }
        public virtual Ram Ram { get; set; }
        public virtual Rom Rom { get; set; }
        public virtual CongSac CongSac { get; set; }
        public virtual Chip Chip { get; set; }
        public virtual ManHinh ManHinh { get; set; }
        public virtual TheNho TheNho { get; set; }
        public virtual Pin Pin { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual MauSac MauSac { get; set; }
        public virtual IEnumerable<Anh> Anh { get; set; }
        public virtual IEnumerable<HoaDonChiTiet> HoaDonChiTiet { get; set; }
        public virtual IEnumerable<SanPhamYeuThich> SanPhamYeuThichs { get; set; }
        public virtual IEnumerable<GioHangChiTiet> GioHangChiTiet { get; set; }
        public virtual IEnumerable<KhuyenMaiChiTiet> KhuyenMaiChiTiet { get; set; }
        public virtual IEnumerable<ChiTietCamera> ChiTietCameras { get; set; }
        public virtual IEnumerable<TheSimDienThoai> TheSimDienThoais { get; set; }
        public virtual IEnumerable<CameraSau> CameraSaus { get; set; }
        public virtual IEnumerable<CameraTruoc> CameraTruocs { get; set; }
        public virtual IEnumerable<Imei> Imeis { get; set; }
        public virtual List<DanhGia> DanhGias { get; set; }
    }
}
