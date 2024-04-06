using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class Imei
    {
        public string? IdImei { get; set; }
        public string? MaImei { get; set; }
        public string? MaVach { get; set; }
        public int? TrangThai { get; set; }
        public virtual List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}
