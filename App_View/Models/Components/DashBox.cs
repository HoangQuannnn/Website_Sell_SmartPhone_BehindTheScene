﻿using App_Data.DbContext;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.DashBox;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App_View.Models.Components
{
    public class DashBox : ViewComponent
    {
        private readonly AppDbContext _appContext;
        private readonly SignInManager<NguoiDung> _signInManager;
        private readonly UserManager<NguoiDung> _userManager;
        public DashBox(UserManager<NguoiDung> userManager, SignInManager<NguoiDung> signInManager = null)
        {
            _appContext = new AppDbContext();
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IViewComponentResult Invoke()
        {
            var idNguoiDung = _userManager.GetUserId(HttpContext.User);
            var dashbox = new DashBoxViewModel()
            {
                SoHoaDonCho = _appContext.HoaDons.Where(hd=>hd.IdNguoiDung==idNguoiDung && hd.TrangThaiGiaoHang == (int)TrangThai.TrangThaiGiaoHang.ChoXacNhan).ToList().Count(),
                SoHoaDonHuy = _appContext.HoaDons.Where(hd=>hd.IdNguoiDung==idNguoiDung && hd.TrangThaiGiaoHang == (int)TrangThai.TrangThaiGiaoHang.DaHuy).ToList().Count(),
                SoSanPhamYeuThich = _appContext.SanPhamYeuThichs.Where(spyt=>spyt.IdNguoiDung==idNguoiDung).ToList().Count(),
            };
            return View(dashbox);
        }
    }
}
