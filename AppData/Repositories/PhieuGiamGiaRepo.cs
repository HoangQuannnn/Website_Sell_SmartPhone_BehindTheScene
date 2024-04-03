using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App_Data.Repositories.TrangThai;

namespace App_Data.Repositories
{
    public class PhieuGiamGiaRepo : IPhieuGiamGiaRepo
    {
        private readonly AppDbContext _context;
        public PhieuGiamGiaRepo(AppDbContext context)
        {
            _context = context;
        }
        public HoaDon TaoHoaDon(HoaDon hoaDon)
        {
            _context.HoaDons.Add(hoaDon);
            var hoadonchitiet = new HoaDonChiTiet();
            hoadonchitiet.IdHoaDonChiTiet = Guid.NewGuid().ToString();
            hoadonchitiet.IdHoaDon = hoaDon.IdHoaDon;
            hoadonchitiet.TrangThai = (int)TrangThaiCoBan.KhongHoatDong;
            _context.HoaDonChiTiets.Add(hoadonchitiet);
            throw new NotImplementedException();
        }
    }
}
