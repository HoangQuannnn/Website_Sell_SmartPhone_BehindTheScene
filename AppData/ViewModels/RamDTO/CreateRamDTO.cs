using App_Data.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.RamDTO
{
    public class CreateRamDTO
    {
        public string tenRam { get; set; }
        public TrangThaiEnum trangThai { get; set; }
        public DungLuongRamEnum dungLuongRam { get; set; }

    }
}
