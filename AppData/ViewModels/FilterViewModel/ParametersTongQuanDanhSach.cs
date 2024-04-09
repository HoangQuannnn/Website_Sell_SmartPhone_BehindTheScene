using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.FilterViewModel
{
    public class ParametersTongQuanDanhSach
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string? SearchValue { get; set; }
        public string? IdSanPham { get; set; }
        public string? IdHang { get; set; }
        public string? IdChip { get; set; }
        public string? IdManHinh { get; set; }
        public string? IdCongSac { get; set; }
        public string? IdPin { get; set; }
        public string? IdTheNho { get; set; }
    }
}
