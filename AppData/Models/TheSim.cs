using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class TheSim
    {
        [Key]
        public string? IdTheSim { get; set; }
        public string? MaTheSim { get; set; }
        public string? Loaithesim { get; set; }
        public int? SoKhaySim { get; set; }
        public int? TrangThai {  get; set; }
        public virtual ICollection<TheSimDienThoai> TheSimDienThoais { get; set; }

    }
}
