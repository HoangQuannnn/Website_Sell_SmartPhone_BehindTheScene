﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class Rom
    {
        [Key]
        public string? IdRom { get; set; }
        public string? MaRom { get; set; }
        public string? DungLuong { get; set; }
        public string? TrangThai { get; set; }
        public virtual List<SanPhamChiTiet>? SanPhamChiTiets { get; set; }
    }
}
