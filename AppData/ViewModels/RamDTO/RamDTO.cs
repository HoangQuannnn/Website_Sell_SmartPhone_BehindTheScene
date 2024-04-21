using App_Data.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.RamDTO
{
    public class RamDTO
    {
        public string IdRam { get; set; }
        public string TenRam { get; set; }
        public DungLuongRamEnum DungLuong { get; set; }
        public TrangThaiEnum trangThai { get; set; }
    }
}
