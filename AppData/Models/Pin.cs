using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class Pin
    {
        [Key]
        public string? IdPin { get; set; }
        public string? MaPin { get; set; }
        public string? LoaiPin { get; set; }
        public string? DungLuong { get; set; }
        public int? TrangThai { get; set; }
        public virtual ICollection<SanPhamChiTiet>? SanPhamChiTiets { get; set; }
    }
}
