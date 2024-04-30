using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.SanPhamChiTietViewModel
{
    public class ItemDetailViewModel : ItemShopViewModel
    {
        public int? SoLuongDaBan { get; set; }
        public int? SoLuotYeuThich { get; set; }
        public List<string>? LstMauSac { get; set; }
        public List<string>? LstRam { get; set; }
        public List<string>? LstRom { get; set; }
        public List<string>? LstRamRom { get; set; }
        public List<string>? DanhSachAnh { get; set; }
        public bool IsYeuThich { get; set; }
        public double? KhoiLuong { get; set; }
        public string? Ram { get; set; }
        public string? Rom { get; set; }
        public string? Hang { get; set; }
        public string? CameraSau { get; set; }
        public string? CameraTruoc { get; set; }
        public string? TheSim { get; set; }

    }
}
