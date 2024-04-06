using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class Ram
    {
        [Key]
        public string? IdRam { get; set; }
        public string? MaRam { get; set; }
        public string? DungLuong { get; set; }
        public string? TrangThai { get; set; }
        public virtual List<SanPhamChiTiet>? SanPhamChiTiets { get; set; }
    }
}
