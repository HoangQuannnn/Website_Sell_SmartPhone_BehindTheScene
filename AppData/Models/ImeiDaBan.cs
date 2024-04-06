using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class ImeiDaBan
    {
        public string? IdImeiDaBan { get; set; }
        public string? IdHoaDonChiTiet { get; set; }
        public string? MaImeiDaBan { get; set; }
        public int? TrangThai { get; set; }
        public virtual HoaDonChiTiet HoaDonChiTiet { get; set; }
    }
}
