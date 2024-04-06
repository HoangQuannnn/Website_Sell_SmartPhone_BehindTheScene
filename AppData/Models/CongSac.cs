using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class CongSac
    {
        [Key]
        public string? IdCongSac { get; set; }
        public string? MaCongSac { get; set; }
        public string? LoaiCongSac { get; set; }
        public string? TrangThai { get; set; }
        public virtual List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}
