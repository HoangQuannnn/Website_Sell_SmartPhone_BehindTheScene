using App_Data.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.RomDTO
{
    public class RomDTO
    {
        public string IdRom { get; set; }
        public string TenRom { get; set; }
        public DungLuongRomEnum DungLuong { get; set; }
        public TrangThaiEnum trangThai { get; set; }
    }
}
