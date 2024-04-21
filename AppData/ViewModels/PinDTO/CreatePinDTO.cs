using App_Data.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.PinDTO
{
    public class CreatePinDTO
    {
        public string? MaPin { get; set; }
        public string? LoaiPin { get; set; }
        public string? DungLuong { get; set; }
        public TrangThaiEnum trangThai { get; set; }
    }
}
