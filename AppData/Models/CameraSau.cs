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
        public string? MaCameraSau { get; set; }
        public string? DoPhanGiaiCamera1 { get; set; }
        public string? DoPhanGiaiCamera2 { get; set; }
        public string? DoPhanGiaiCamera3 { get; set; }
        public string? DoPhanGiaiCamera4 { get; set; }
        public string? DoPhanGiaiCamera5 { get; set; }
        public int? TrangThai { get; set; }
        public virtual List<SanPhamChiTiet>? SanPhamChiTiets { get; set; }
    }
}
