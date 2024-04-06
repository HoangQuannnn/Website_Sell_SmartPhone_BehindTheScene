using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class ImeiChuaBan
    {
        public string? IdImeiChuaBan { get; set; }
        public string? IdGioHangChiTiet { get; set; }
        public string? MaImeiChuaBan { get; set; }
        public int? TrangThai { get; set; }
        public virtual GioHangChiTiet GioHangChiTiet { get; set; }
    }
}
