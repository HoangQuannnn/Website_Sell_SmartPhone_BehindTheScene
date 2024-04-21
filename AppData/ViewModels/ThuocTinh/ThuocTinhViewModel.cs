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
        public string? TrangThai { get; set; }
        public int? SoBienTheDangDung { get; set; }
        public string? LoaiCongSac { get; set; }
        public string? LoaiTheNho { get; set; }
        public string? DungLuong { get; set; }
        public int? KichThuoc { get;set; }
        public int? TanSoQuet { get; set; }
        public string? LoaiManHinh { get; set; }
    }
}
