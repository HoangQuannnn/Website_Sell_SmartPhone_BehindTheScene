using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class ManHinh
    {
        public string? IdManHinh { get; set; }
        public string? MaManHinh { get; set; }
        public double? KichThuoc { get; set; }
        public string? LoaiManHinh { get; set; }
        public int? TanSoQuet { get; set; }
        public int? TrangThai { get; set; }
        public virtual List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}
