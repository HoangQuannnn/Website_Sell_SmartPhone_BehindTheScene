using App_Data.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.RomDTO
{
    public class CreateRomDTO
    {
        public TrangThaiEnum trangThai { get; set; }
        public string dungLuongRom { get; set; }
    }
}
