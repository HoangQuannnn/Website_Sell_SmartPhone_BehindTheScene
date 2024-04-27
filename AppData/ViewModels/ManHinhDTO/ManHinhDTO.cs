using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App_Data.ViewModels.ManHinhDTO
{
    public class ManHinhDTO
    {
        public string? IdManHinh { get; set; }
        public double? KichThuoc { get; set; }
        public string? LoaiManHinh { get; set; }
        public int? TanSoQuet { get; set; }
        public int? TrangThai { get; set; }
    }
}
