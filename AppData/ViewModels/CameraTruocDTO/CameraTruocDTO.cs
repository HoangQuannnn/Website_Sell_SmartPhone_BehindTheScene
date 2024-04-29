using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.CameraTruocDTO
{
    public class CameraTruocDTO
    {
        public string? IdCameraTruoc { get; set; }
        public string? MaCameraTruoc { get; set; }
        public string? DoPhanGiaiCamera1 { get; set; }
        public string? DoPhanGiaiCamera2 { get; set; }
        
        public int? TrangThai { get; set; }
        public string? IdSanPhamChiTiet { get; set; }

    }
}
