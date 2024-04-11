using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.ChiTietCameraDTO
{
    public class ChiTietCameraDTO
    {
        public string? IdChiTietCamera { get; set; }
        public string? IdCamera { get; set; }
        public string? IdSanPhamChiTiet { get; set; }
        public string? LoaiCamera { get; set; }
        public string? Camera { get; set; }
        public string? SanPhamChiTiet { get; set; }
    }
}
