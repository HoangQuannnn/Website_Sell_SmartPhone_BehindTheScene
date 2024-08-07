﻿using App_Data.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.ThuocTinh
{
    public class ThuocTinhViewModel
    {
        public string? Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public int? SoKhaySim { get; set; }
        public string? TrangThai { get; set; }
        public string? LoaiPin { get; set; }
        public string? DungLuong { get; set; }
        public int? SoBienTheDangDung { get; set; }
        public string DungLuongRamEnum { get; set; }
        public string DungLuongRomEnum { get; set; }
        public string? LoaiCongSac { get; set; }
        public string? LoaiTheSim { get; set; }
        public string? LoaiTheNho { get; set; }
        public double? KichThuoc { get;set; }
        public int? TanSoQuet { get; set; }
        public string? LoaiManHinh { get; set; }
        public string? DoPhanGiaiCamera1 { get; set; }
        public string? DoPhanGiaiCamera2 { get; set; }
        public string? DoPhanGiaiCamera3 { get; set; }
        public string? DoPhanGiaiCamera4 { get; set; }
        public string? DoPhanGiaiCamera5 { get; set; }
    }
}
