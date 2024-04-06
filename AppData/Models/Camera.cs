using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class Camera
    {
        [Key]
        public string? IdCamera { get; set; }
        public string? MaCamera { get; set; }
        public string? DoPhanGiai { get; set; }
        public int? TrangThai { get; set; }
        public virtual ICollection<ChiTietCamera> ChiTietCameras { get; set; }
    }
}
