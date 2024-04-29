using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class CameraTruoc
    {
        [Key]
        public string? IdCameraTruoc { get; set; }
        public string? MaCameraTruoc { get; set; }
        public string? DoPhanGiaiCamera1 { get; set; }
        public string? DoPhanGiaiCamera2 { get; set; }
        public int? TrangThai { get; set; }
        public virtual List<SanPhamChiTiet>? SanPhamChiTiets { get; set; }
    }
}
