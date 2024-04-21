using App_Data.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.ThuocTinh
{
    public class ThuocTinhViewModel
    {
        public string? Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public int? SoKhaySim { get; set; }
        public string? TrangThai { get; set; }
        public string? LoaiPin { get; set; }
        public string? DungLuong { get; set; }
        public int? SoBienTheDangDung { get; set; }
        public DungLuongRamEnum DungLuongRamEnum { get; set; }
        public DungLuongRomEnum DungLuongRomEnum { get; set; }
        public string? LoaiCongSac { get; set; }
        public string? LoaiTheNho { get; set; }
        public string? DungLuong { get; set; }
        public int? KichThuoc { get;set; }
        public int? TanSoQuet { get; set; }
        public string? LoaiManHinh { get; set; }
    }
}
