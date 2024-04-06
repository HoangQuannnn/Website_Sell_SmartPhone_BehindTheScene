using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class CameraSau
    {
        [Key]
        public string? IdCameraSau { get; set; }
        public string? DoPhanGiai { get; set; }
        public string? LoaiCamera { get; set; }
        public int? TrangThai { get; set; }
        public string? IdSanPhamChiTiet { get; set; }

        public virtual SanPhamChiTiet SanPhamChiTiet { get; set; }
    }
}
