using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class Chip
    {
        public string? IdChip { get; set; }
        public string? MaChip { get; set; }
        public string? TenChip { get; set; }
        public int? TrangThai { get; set; }
        public virtual List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}
