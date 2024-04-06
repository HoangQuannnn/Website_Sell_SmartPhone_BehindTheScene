using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class ChiTietCamera
    {
        [Key]
        public string? IdChiTietCamera { get; set; }
        public string? IdCamera { get; set; }
        public string? IdSanPhamChiTiet { get; set; }
        public string? LoaiCamera { get; set; }
        public virtual Camera Camera { get; set; }
        public virtual SanPhamChiTiet SanPhamChiTiet { get; set; }
    }
}
