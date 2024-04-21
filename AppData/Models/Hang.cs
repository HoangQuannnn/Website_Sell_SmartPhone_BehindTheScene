using App_Data.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class Hang
    {
        public string? IdHang { get; set; }
        public string? MaHang { get; set; }
        public string? TenHang { get; set; }
        public TrangThaiEnum TrangThai { get; set; }
        public virtual List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}
