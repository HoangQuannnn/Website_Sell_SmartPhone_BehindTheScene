using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.SanPhamChiTietDTO
{
    public class SanPhamChiTietDTO
    {
        private double? giaThucTe;
        public string? IdChiTietSp { get; set; }

        public string? FullName { get; set; }

        public bool? Day { get; set; }

        public string? MoTa { get; set; }

        public int? SoLuongTon { get; set; }

        public double? GiaBan { get; set; }

        public double? KhoiLuong { get; set; }

        public double? GiaThucTe
        {
            get
            {
                return giaThucTe ?? GiaBan;
            }
            set
            {
                giaThucTe = value;
            }
        }

        public bool TrangThaiKhuyenMai { get; set; }

        public bool? NoiBat { get; set; }

        public double? GiaNhap { get; set; }

        public string? IdSanPham { get; set; }
        public string? IdMauSac { get; set; }
        public string? IdRam { get; set; }
        public string? IdRom { get; set; }
        public string? IdCongSac { get; set; }
        public string? IdHang { get; set; }
        public string? IdChip { get; set; }
        public string? IdManHinh { get; set; }
        public string? IdTheNho { get; set; }
        public string? IdPin { get; set; }
        public List<string>? DanhSachAnh { get; set; }
    }
}
