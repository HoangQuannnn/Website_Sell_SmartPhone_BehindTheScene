using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class TheSimDienThoai
    {
        [Key]
        public string? IdTheSimDienThoai { get; set; }
        public string? IdTheSim { get; set; }
        public string? IdSanPhamChiTiet { get; set; }
        public virtual TheSim Thesim { get; set; }
        public virtual SanPhamChiTiet SanPhamChiTiet { get; set; }
    }
}
