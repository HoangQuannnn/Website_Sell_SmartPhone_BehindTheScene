using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.FilterViewModel
{
    public class FiltersVM
    {
        public List<ItemFilter>? LstItemFilterHang { get; set; }
        public List<ItemFilter>? LstItemFilterTheLoai { get; set; }
        public List<ItemFilter>? LstItemFilterMauSac { get; set; }
        public List<ItemFilter>? LstItemFilterRom { get; set; }
    }
}
