﻿using App_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.SanPhamChiTietViewModel
{
    public class SanPhamDanhSachViewModel
    {
        public string? IdChiTietSp { get; set; }

        public string? Day { get; set; }

        public string? Ma { get; set; }

        public int? SoLuongTon { get; set; }

        public double? GiaBan { get; set; }

        public double? GiaNhap { get; set; }

        public string? SanPham { get; set; }


        public int? SoLuongDaBan { get; set; }
        public string? MauSac { get; set; }
        public string? Ram { get; set; }
        public string? Rom { get; set; }
        public string? CongSac { get; set; }
        public string? Hang { get; set; }
        public string? Chip { get; set; }
        public string? ManHinh { get; set; }
        public int? KichCoManHinh { get; set; }
        public int? TanSoQuetManHinh { get; set; }
        public string? TheNho { get; set; }
        public string? Pin { get; set; }
        public string? Anh { get; set; }
    }
}
