﻿using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Migrations;
using App_Data.Models;
using App_Data.ViewModels.FilterViewModel;
using App_Data.ViewModels.SanPhamChiTietDTO;
using App_Data.ViewModels.SanPhamChiTietViewModel;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using Microsoft.EntityFrameworkCore;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App_Data.Repositories.TrangThai;

namespace App_Data.Repositories
{
    public class SanPhamChiTietRespo : ISanPhamChiTietRespo
    {

        private readonly AppDbContext _context;
        private readonly IDanhGiaRepo _danhGiaRespo;
        private readonly IMapper _mapper;

        public SanPhamChiTietRespo(IMapper mapper)
        {
            _mapper = mapper;
            _danhGiaRespo = new DanhGiaRepo();
            _context = new AppDbContext();
        }
        public async Task<bool> AddAsync(SanPhamChiTiet entity)
        {
            try
            {
                await _context.SanPhamChiTiets.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var entity = await GetByKeyAsync(id)!;
                if (entity == null) return false;
                _context.SanPhamChiTiets.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<SanPhamChiTiet?> GetByKeyAsync(string id)
        {
            return await _context.SanPhamChiTiets.FirstOrDefaultAsync(x => x.IdChiTietSp == id);
        }

        public async Task<List<SanPhamChiTietDTO>> GetListSanPhamChiTietDTOAsync(List<string> lstGuid)
        {
            var lstSanPhamChiTiet = await _context.SanPhamChiTiets
                 .Where(sp => lstGuid.Contains(sp.IdChiTietSp!))
                 .Include(x => x.Anh)
                 .Include(x => x.SanPham)
                 .Include(x => x.MauSac)
                 .Include(x => x.Rom)
                 .Include(x => x.Ram)
                 .Include(x => x.Hang)
                 .Include(x => x.Pin)
                 .Include(x => x.ManHinh)
                 .Include(x => x.Chip)
                 .Include(x => x.CongSac)
                 .Include(x => x.TheNho)
                 .ToListAsync();
            return _mapper.Map<List<SanPhamChiTietDTO>>(lstSanPhamChiTiet);
        }

        public async Task<DanhSachGiayViewModel> GetDanhSachGiayViewModelAsync()
        {
            using (var dbContext = new AppDbContext())
            {
                var dateTimeNow = DateTime.Now;
                var query = dbContext.SanPhamChiTiets.AsQueryable();
                var lstAllSp = await query
                     .Include(x => x.Anh)
                     .Include(x => x.SanPham)
                     .Include(x => x.MauSac)
                     .Include(x => x.Rom)
                     .Include(x => x.Ram)
                     .Include(x => x.Hang)
                     .Include(x => x.Pin)
                     .Include(x => x.ManHinh)
                     .Include(x => x.Chip)
                     .Include(x => x.CongSac)
                     .Include(x => x.TheNho)
                      .ToListAsync();
                var groupedResults1 = lstAllSp
                  .GroupBy(gr =>
                      new
                      {
                          gr.IdChiTietSp
                      })
                  .ToList();
                var lstAllSpViewModel = groupedResults1
                   .Select(gr => CreateAllItemShopViewModelAsync(gr))
                   .ToList();
                var lstSPNoiBat = await query
                      .Where(sp => sp.TrangThai == (int)TrangThaiCoBan.HoatDong && sp.NoiBat == true)
                     .Include(x => x.Anh)
                     .Include(x => x.SanPham)
                     .Include(x => x.MauSac)
                     .Include(x => x.Rom)
                     .Include(x => x.Ram)
                     .Include(x => x.Hang)
                     .Include(x => x.Pin)
                     .Include(x => x.ManHinh)
                     .Include(x => x.Chip)
                     .Include(x => x.CongSac)
                     .Include(x => x.TheNho)
                      .ToListAsync();

                var groupedResults = lstSPNoiBat
                    .GroupBy(gr =>
                        new
                        {
                            gr.IdRam,
                            gr.IdSanPham,
                            gr.IdRom,
                            gr.IdHang,
                            gr.IdManHinh,
                            gr.IdPin,
                            gr.IdTheNho,
                            gr.IdCongSac,
                            gr.IdChip,
                        })
                    .ToList();

                var lstSPNoiBatViewModels = groupedResults
                    .Select(gr => CreateItemShopViewModelAsync(gr))
                    .ToList();

                var lstSPMoi = await query
                    .Where(sp => EF.Functions.DateDiffDay(sp.NgayTao, dateTimeNow) < 7 && sp.TrangThai == (int)TrangThaiCoBan.HoatDong)
                     .Include(x => x.Anh)
                     .Include(x => x.SanPham)
                     .Include(x => x.MauSac)
                     .Include(x => x.Rom)
                     .Include(x => x.Ram)
                     .Include(x => x.Hang)
                     .Include(x => x.Pin)
                     .Include(x => x.ManHinh)
                     .Include(x => x.Chip)
                     .Include(x => x.CongSac)
                     .Include(x => x.TheNho)
                    .ToListAsync();

                groupedResults = lstSPMoi
                    .GroupBy(gr =>
                        new
                        {
                            gr.IdRam,
                            gr.IdSanPham,
                            gr.IdRom,
                            gr.IdHang,
                            gr.IdManHinh,
                            gr.IdPin,
                            gr.IdTheNho,
                            gr.IdCongSac,
                            gr.IdChip,
                        })
                    .ToList();

                var lstSPMoiViewModels = groupedResults
                    .Select(gr => CreateItemShopViewModelAsync(gr))
                    .ToList();

                var lstBanChay = await query
                   .Where(sp => sp.SoLuongDaBan > 0 && sp.TrangThai == (int)TrangThaiCoBan.HoatDong)
                    .Include(x => x.Anh)
                     .Include(x => x.SanPham)
                     .Include(x => x.MauSac)
                     .Include(x => x.Rom)
                     .Include(x => x.Ram)
                     .Include(x => x.Hang)
                     .Include(x => x.Pin)
                     .Include(x => x.ManHinh)
                     .Include(x => x.Chip)
                     .Include(x => x.CongSac)
                     .Include(x => x.TheNho)
                   .ToListAsync();

                groupedResults = lstBanChay
                   .GroupBy(gr =>
                       new
                       {
                           gr.IdRam,
                           gr.IdSanPham,
                           gr.IdRom,
                           gr.IdHang,
                           gr.IdManHinh,
                           gr.IdPin,
                           gr.IdTheNho,
                           gr.IdCongSac,
                           gr.IdChip,
                       })
                   .Where(gr => gr.Sum(it => it.SoLuongDaBan) > 0)
                   .OrderByDescending(gr => gr.Sum(it => it.SoLuongDaBan))
                   .ToList();

                var lstBanChayViewModels = groupedResults
                    .Select(gr => CreateItemShopViewModelAsync(gr))
                    .ToList();

                var lstIDSPDanhGia = await dbContext.DanhGias.Select(it => it.IdSanPhamChiTiet).Distinct().ToListAsync();
                var lstDanhGia = await query
                   .Where(sp => sp.TrangThai == (int)TrangThaiCoBan.HoatDong && lstIDSPDanhGia.Contains(sp.IdChiTietSp))
                    .Include(x => x.Anh)
                     .Include(x => x.SanPham)
                     .Include(x => x.MauSac)
                     .Include(x => x.Rom)
                     .Include(x => x.Ram)
                     .Include(x => x.Hang)
                     .Include(x => x.Pin)
                     .Include(x => x.ManHinh)
                     .Include(x => x.Chip)
                     .Include(x => x.CongSac)
                     .Include(x => x.TheNho)
                   .Include(x => x.DanhGias)
                   .ToListAsync();

                groupedResults = lstDanhGia
                   .GroupBy(gr =>
                       new
                       {
                           gr.IdRam,
                           gr.IdSanPham,
                           gr.IdRom,
                           gr.IdHang,
                           gr.IdManHinh,
                           gr.IdPin,
                           gr.IdTheNho,
                           gr.IdCongSac,
                           gr.IdChip,
                       })
                   .OrderByDescending(gr => (double)Math.Round((double)gr.Sum(sp => sp.DanhGias!.Sum(dg => dg.SaoSp))! / gr.Sum(sp => sp.DanhGias.Count)))
                   .ToList();

                var lstDanhGiaViewModels = groupedResults
                    .Select(gr => CreateItemShopViewModelAsync(gr))
                    .ToList();

                return new DanhSachGiayViewModel()
                {
                    LstAllSanPham = lstAllSpViewModel,
                    LstSanPhamNoiBat = lstSPNoiBatViewModels,
                    LstSanPhamMoi = lstSPMoiViewModels,
                    LstBanChay = lstBanChayViewModels,
                    LstTopDanhGia = lstDanhGiaViewModels
                };
            }

        }

        private ItemShopViewModel CreateItemShopViewModelAsync(IGrouping<object, SanPhamChiTiet> gr)
        {
            var firstItem = gr.First();
            var grSp = _context
                .SanPhamChiTiets
                .Where(sp =>
                sp.IdRam == firstItem.IdRam &&
                sp.IdSanPham == firstItem.IdSanPham &&
                sp.IdHang == firstItem.IdHang &&
                sp.IdRom == firstItem.IdRom &&
                sp.IdManHinh == firstItem.IdManHinh &&
                sp.IdCongSac == firstItem.IdCongSac &&
                sp.IdChip == firstItem.IdChip &&
                sp.IdPin == firstItem.IdPin &&
                sp.IdTheNho == firstItem.IdTheNho)
                .ToList();
            var listGia = grSp.Select(sp => sp.GiaThucTe).ToList();
            return new ItemShopViewModel()
            {
                IdChiTietSp = firstItem.IdChiTietSp,
                Anh = firstItem.Anh
                    .Where(a => a.TrangThai == (int)TrangThaiCoBan.HoatDong)
                    .OrderBy(a => a.NgayTao)
                    .FirstOrDefault()?.Url,
                TenSanPham = $"{firstItem.Hang.TenHang?.ToUpper()} {firstItem.SanPham.TenSanPham?.ToUpper()}",
                Hang = firstItem.Hang.TenHang,
                GiaMin = listGia.Min(),
                GiaMax = listGia.Max()
            };
        }
        private ItemShopViewModel CreateAllItemShopViewModelAsync(IGrouping<object, SanPhamChiTiet> gr)
        {
            var firstItem = gr.First();
            var grSp = _context
                .SanPhamChiTiets
                .Where(sp =>
               sp.IdChiTietSp == firstItem.IdChiTietSp)
                .ToList();
            var listGia = grSp.Select(sp => sp.GiaThucTe).ToList();
            return new ItemShopViewModel()
            {
                IdChiTietSp = firstItem.IdChiTietSp,
                Anh = firstItem.Anh
                    .Where(a => a.TrangThai == (int)TrangThaiCoBan.HoatDong)
                    .OrderBy(a => a.NgayTao)
                    .FirstOrDefault()?.Url,
                TenSanPham = $"{firstItem.Hang.TenHang?.ToUpper()} {firstItem.SanPham.TenSanPham?.ToUpper()}",
                Hang = firstItem.Hang.TenHang,
                GiaMin = listGia.Min(),
                GiaMax = listGia.Max(),
                GiaThucTe = firstItem.GiaThucTe,
                GiaGoc = firstItem.GiaBan,
                MauSac = firstItem.MauSac.TenMauSac,
                Ram = firstItem.Ram.DungLuong,
                Rom = firstItem.Rom.DungLuong
            };
        }

        public async Task<IEnumerable<SanPhamChiTiet>> GetListAsync()
        {
            return await _context.SanPhamChiTiets.ToListAsync();
        }


        public SanPhamDanhSachViewModel CreateSanPhamDanhSachViewModel(SanPhamChiTiet sanPham)
        {
            using (var context = new AppDbContext())
            {
                return new SanPhamDanhSachViewModel()
                {
                    IdChiTietSp = sanPham.IdChiTietSp,
                    Ram = context.Rams.ToList().FirstOrDefault(x => x.IdRam == sanPham.IdRam)?.DungLuong,
                    SanPham = context.Hangs.ToList().FirstOrDefault(x => x.IdHang == sanPham.IdHang)?.TenHang + " " + context.SanPhams.ToList().FirstOrDefault(x => x.IdSanPham == sanPham.IdSanPham)?.TenSanPham,
                    GiaBan = sanPham.GiaBan,
                    MauSac = context.MauSacs.ToList().FirstOrDefault(ms => ms.IdMauSac == sanPham.IdMauSac)?.TenMauSac,
                    Rom = context.Roms.ToList().FirstOrDefault(x => x.IdRom == sanPham.IdRom)?.DungLuong,
                    Anh = context.Anh.ToList().Where(x => x.IdSanPhamChiTiet == sanPham.IdChiTietSp && x.TrangThai == 0).OrderBy(x => x.NgayTao).FirstOrDefault()?.Url,
                    SoLuongDaBan = sanPham.SoLuongDaBan,
                    ManHinh = context.ManHinhs.ToList().FirstOrDefault(x => x.IdManHinh == sanPham.IdManHinh)?.LoaiManHinh + " " + context.ManHinhs.ToList().FirstOrDefault(x => x.IdManHinh == sanPham.IdManHinh)?.KichThuoc + " " + context.ManHinhs.ToList().FirstOrDefault(x => x.IdManHinh == sanPham.IdManHinh)?.TanSoQuet,
                    CongSac = context.CongSacs.ToList().FirstOrDefault(x => x.IdCongSac == sanPham.IdCongSac)?.LoaiCongSac,
                    Chip = context.Chips.ToList().FirstOrDefault(x => x.IdChip == sanPham.IdChip)?.TenChip,
                    TheNho = context.TheNhos.ToList().FirstOrDefault(x => x.IdTheNho == sanPham.IdTheNho)?.LoaiTheNho,
                    Pin = context.Pins.ToList().FirstOrDefault(x => x.IdPin == sanPham.IdPin)?.LoaiPin,
                    SoLuongTon = context.Imeis.Where(x => x.IdSanPhamChiTiet == sanPham.IdChiTietSp).Count(),
                    Ma = sanPham.Ma
                };
            }
        }

        public async Task<IEnumerable<SanPhamDanhSachViewModel>> GetListViewModelAsync()
        {
            var sanPhamChiTietViewModels =
                (await _context.SanPhamChiTiets.ToListAsync()).Where(it => it.TrangThai == 0).OrderByDescending(x => x.NgayTao).Select(item => CreateSanPhamDanhSachViewModel(item)).ToList();
            return sanPhamChiTietViewModels;
        }
        public async Task<IEnumerable<SanPhamDanhSachViewModel>> GetAllListViewModelAsync()
        {
            var sanPhamChiTietViewModels =
                (await _context.SanPhamChiTiets.ToListAsync()).OrderByDescending(x => x.NgayTao).Select(item => CreateSanPhamDanhSachViewModel(item)).ToList();
            return sanPhamChiTietViewModels;
        }
        public async Task<bool> UpdateAsync(SanPhamChiTiet entity)
        {
            try
            {
                _context.SanPhamChiTiets.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public async Task<List<ItemShopViewModel>> GetDanhSachItemShopViewModelAsync()
        {
            using (var dbContext = new AppDbContext())
            {
                var listSanPham = await dbContext.SanPhamChiTiets
                 .Include(x => x.Anh)
                     .Include(x => x.SanPham)
                     .Include(x => x.MauSac)
                     .Include(x => x.Rom)
                     .Include(x => x.Ram)
                     .Include(x => x.Hang)
                     .Include(x => x.Pin)
                     .Include(x => x.ManHinh)
                     .Include(x => x.Chip)
                     .Include(x => x.CongSac)
                     .Include(x => x.TheNho)
                .Where(sp => sp.TrangThai == 0)
                .GroupBy(
                  gr => new
                  {
                      gr.IdRam,
                      gr.IdSanPham,
                      gr.IdRom,
                      gr.IdHang,
                      gr.IdManHinh,
                      gr.IdPin,
                      gr.IdTheNho,
                      gr.IdCongSac,
                      gr.IdChip,
                  })
                .Select(gr => gr.First())
                .ToListAsync();

                var itemShops = _mapper.Map<List<ItemShopViewModel>>(listSanPham.OrderByDescending(x => x.NgayTao));
                return itemShops;
            }
        }

        public async Task<List<ItemShopViewModel>> GetDanhSachBienTheItemShopViewModelAsync()
        {
            using (var dbContext = new AppDbContext())
            {
                var listSanPham = await dbContext.SanPhamChiTiets
           .Where(sp => sp.TrangThai == 0)
            .Include(x => x.Anh)
           .Include(x => x.SanPham)
           .Include(x => x.MauSac)
           .Include(x => x.Rom)
           .Include(x => x.Ram)
           .Include(x => x.Hang)
           .Include(x => x.Pin)
           .Include(x => x.ManHinh)
           .Include(x => x.Chip)
           .Include(x => x.CongSac)
           .Include(x => x.TheNho)
           .OrderByDescending(x => x.NgayTao)
           .AsNoTracking()
           .ToListAsync();

                var itemShops = listSanPham.Select(sp => new ItemShopViewModel()
                {
                    Anh = dbContext.Anh.Where(a => a.IdSanPhamChiTiet == sp.IdChiTietSp).OrderBy(a => a.NgayTao).FirstOrDefault()!.Url,
                    GiaGoc = sp.GiaBan,
                    MaSanPham = sp.Ma,
                    GiaKhuyenMai = sp.GiaThucTe,
                    MauSac = sp.MauSac!.TenMauSac,
                    Ram = sp.Ram!.DungLuong,
                    Rom = sp.Ram!.DungLuong,
                    ManHinh = sp.ManHinh.LoaiManHinh + " " + sp.ManHinh.KichThuoc + " " + sp.ManHinh.TanSoQuet,
                    CongSac = sp.CongSac!.LoaiCongSac,
                    Chip = sp.Chip!.TenChip,
                    Pin = sp.Pin!.LoaiPin,
                    TheNho = sp.TheNho!.LoaiTheNho,
                    IdChiTietSp = sp.IdChiTietSp,
                    SoLanDanhGia = _danhGiaRespo.GetTongSoDanhGia(sp.IdChiTietSp!).Result,
                    SoSao = _danhGiaRespo.SoSaoTB(sp.IdChiTietSp!).Result,
                    TenSanPham = sp.SanPham!.TenSanPham,
                    Hang = sp.Hang.TenHang,
                    GiaThucTe = sp.GiaThucTe,
                    IsKhuyenMai = sp.TrangThaiSale == 2 ? true : false,
                    SoLuongTon = sp.SoLuongTon,
                    MoTaNgan = "Sản phẩm chính hãng",
                    IsNew = (DateTime.Now - sp.NgayTao.GetValueOrDefault()).Days < 7,
                    IsNoiBat = sp.NoiBat.GetValueOrDefault()
                }).ToList();
                return itemShops;
            }
        }

        public async Task<List<ItemShopViewModel>> GetDanhSachBienTheItemShopViewModelSaleAsync()
        {
            var listSanPham = await _context.SanPhamChiTiets
                .Where(sp => sp.TrangThai == 0 && sp.TrangThaiSale == 2)
                .Include(x => x.Anh)
                .Include(x => x.SanPham)
                .Include(x => x.Hang)
                .Include(x => x.Ram)
                .Include(x => x.MauSac)
                .Include(x => x.Rom)
                .OrderByDescending(x => x.NgayTao)
                .AsNoTracking()
                .ToListAsync();

            var itemShops = listSanPham.Select(sp => new ItemShopViewModel()
            {
                Anh = _context.Anh.Where(a => a.IdSanPhamChiTiet == sp.IdChiTietSp).OrderBy(a => a.NgayTao).FirstOrDefault()!.Url,
                GiaGoc = sp.GiaBan,
                GiaKhuyenMai = sp.GiaThucTe,
                MauSac = sp.MauSac!.TenMauSac,
                Ram = sp.Ram.DungLuong,
                Rom = sp.Rom.DungLuong,
                IdChiTietSp = sp.IdChiTietSp,
                SoLanDanhGia = _danhGiaRespo.GetTongSoDanhGia(sp.IdChiTietSp!).Result,
                SoSao = _danhGiaRespo.SoSaoTB(sp.IdChiTietSp!).Result,
                TenSanPham = sp.SanPham!.TenSanPham,
                Hang = sp.Hang.TenHang,
                GiaThucTe = sp.GiaThucTe,
                IsNew = (DateTime.Now - sp.NgayTao.GetValueOrDefault()).Days < 7,
                IsNoiBat = sp.NoiBat.GetValueOrDefault()
            }).ToList();
            return itemShops;
        }

        public async Task<ItemDetailViewModel?> GetItemDetailViewModelAynsc(string id)
        {
            var sanPhamChiTiet = await _context.SanPhamChiTiets
                 .Include(x => x.Anh)
                   .Include(x => x.SanPham)
                   .Include(x => x.MauSac)
                   .Include(x => x.Rom)
                   .Include(x => x.Ram)
                   .Include(x => x.Hang)
                   .Include(x => x.Pin)
                   .Include(x => x.ManHinh)
                   .Include(x => x.Chip)
                   .Include(x => x.CongSac)
                   .Include(x => x.TheNho).
                Include(x => x.SanPhamYeuThichs).
                FirstOrDefaultAsync(sp => sp.IdChiTietSp == id);
            if (sanPhamChiTiet == null) return null;
            var itemDetailViewModel = _mapper.Map<ItemDetailViewModel>(sanPhamChiTiet);
            var lstBienThe = await _context.SanPhamChiTiets
                .Include(x => x.MauSac)
                .Include(x => x.Ram)
                .Include(x => x.Rom)
                .Where(sp =>
                sp.TrangThai == 0 &&
                sp.IdChip == sanPhamChiTiet!.IdChip &&
                sp.IdPin == sanPhamChiTiet.IdPin &&
                sp.IdHang == sanPhamChiTiet.IdHang &&
                sp.IdManHinh == sanPhamChiTiet.IdManHinh &&
                sp.IdCongSac == sanPhamChiTiet.IdCongSac &&
                sp.IdTheNho == sanPhamChiTiet.IdTheNho &&
                sp.IdSanPham == sanPhamChiTiet.IdSanPham
                ).ToListAsync();
            itemDetailViewModel.LstMauSac = lstBienThe.Select(x => x.MauSac.TenMauSac).Distinct().ToList()!;
            itemDetailViewModel.LstRam = lstBienThe.Where(sp => sp.IdMauSac == sanPhamChiTiet.IdMauSac).Select(x => x.Ram.DungLuong!).Distinct().OrderBy(item => item).ToList();
            itemDetailViewModel.LstRom = lstBienThe.Where(sp => sp.IdMauSac == sanPhamChiTiet.IdMauSac).Select(x => x.Rom.DungLuong!).Distinct().OrderBy(item => item).ToList();
            return itemDetailViewModel;
        }

        public async Task<ItemDetailViewModel?> GetItemDetailViewModelWhenSelectColorAynsc(string id, string mauSac)
        {
            var sanPhamGet = await _context.SanPhamChiTiets.FirstOrDefaultAsync(sp => sp.IdChiTietSp == id);

            if (sanPhamGet == null)
                return null;

            var mauSacEntity = await _context.MauSacs.FirstOrDefaultAsync(x => x.TenMauSac == mauSac);

            if (mauSacEntity == null)
                return null;

            var idMauSac = mauSacEntity.IdMauSac;

            var query = _context.SanPhamChiTiets
                .Where(sp =>
                    sp.TrangThai == 0 &&
                    sp.IdRam == sanPhamGet!.IdRam &&
                    sp.IdRom == sanPhamGet.IdRom &&
                    sp.IdManHinh == sanPhamGet.IdManHinh &&
                    sp.IdCongSac == sanPhamGet.IdCongSac &&
                    sp.IdChip == sanPhamGet.IdChip &&
                    sp.IdPin == sanPhamGet.IdPin &&
                    sp.IdTheNho == sanPhamGet.IdTheNho &&
                    sp.IdSanPham == sanPhamGet.IdSanPham &&
                    sp.IdMauSac == idMauSac
                )
                .Include(x => x.MauSac)
                .Include(x => x.Ram)
                .Include(x => x.Rom)
                .Include(x => x.Hang)
                .Include(x => x.ManHinh)
                .Include(x => x.CongSac)
                .Include(x => x.Chip)
                .Include(x => x.Pin)
                .Include(x => x.TheNho)
                .Include(x => x.Anh);

            var lstBienThe = await query.ToListAsync();

            var lstRam = lstBienThe
                .GroupBy(sp => sp.Ram.DungLuong)
                .OrderBy(item => item.Key)
                .Select(group => group.First()); 
            var lstRom = lstBienThe
                .GroupBy(sp => sp.Rom.DungLuong)
                .OrderBy(item => item.Key)
                .Select(group => group.First());

            var idRamGet = lstRam.FirstOrDefault()?.Ram.IdRam;
            var idRomGet = lstRom.FirstOrDefault()?.Rom.IdRom;

            var sanPhamChiTiet = lstBienThe.FirstOrDefault(sp => sp.IdRam == idRamGet && sp.IdRom == idRomGet);

            var itemDetailViewModel = _mapper.Map<ItemDetailViewModel>(sanPhamChiTiet);
            var lstRamRom = new List<string>();
            lstRamRom.AddRange(lstRam.Select(x => x.Ram.DungLuong));
            lstRamRom.AddRange(lstRom.Select(x => x.Rom.DungLuong));
            itemDetailViewModel.lstRamRom = lstRamRom;

            return itemDetailViewModel;


        }

        public async Task<ItemDetailViewModel?> GetItemDetailViewModelWhenSelectSizeAynsc(string id, string ram, string rom)
        {
            var sanPhamGet = await _context.SanPhamChiTiets.FirstOrDefaultAsync(sp => sp.IdChiTietSp == id);

            var idsRam = (await _context.Rams.FirstOrDefaultAsync(x => x.DungLuong == ram))!.IdRam;
            var idsRom = (await _context.Roms.FirstOrDefaultAsync(x => x.DungLuong == rom))!.IdRom;
            var sanPhamChiTiet = (await _context.SanPhamChiTiets.Where(sp =>
                sp.IdManHinh == sanPhamGet!.IdManHinh &&
                sp.IdMauSac == sanPhamGet.IdMauSac &&
                sp.IdPin == sanPhamGet.IdPin &&
                sp.IdTheNho == sanPhamGet.IdTheNho &&
                sp.IdCongSac == sanPhamGet.IdCongSac &&
                sp.IdSanPham == sanPhamGet.IdSanPham &&
                sp.IdChip == sanPhamGet.IdChip &&
                sp.IdHang == sanPhamGet.IdHang &&
                sp.IdRom == idsRom &&
                sp.IdRam == idsRam).
                Include(x => x.Anh).
                Include(x => x.SanPham).
                Include(x => x.Hang).
                Include(x => x.ManHinh).
                Include(x => x.CongSac).
                Include(x => x.Pin).
                Include(x => x.TheNho).
                Include(x => x.Chip).
                Include(x => x.Ram).
                Include(x => x.Rom).
                Include(x => x.MauSac).FirstOrDefaultAsync());
            if (sanPhamChiTiet == null) return null;
            var itemDetailViewModel = _mapper.Map<ItemDetailViewModel>(sanPhamChiTiet);
            return itemDetailViewModel;
        }

        public async Task<SanPhamChiTietViewModel?> GetSanPhamChiTietViewModelAynsc(string id)
        {
            var sanPhamChiTiet = await _context.SanPhamChiTiets.
                Include(x => x.Anh).
                Include(x => x.SanPham).
                Include(x => x.Hang).
                Include(x => x.ManHinh).
                Include(x => x.CongSac).
                Include(x => x.Pin).
                Include(x => x.TheNho).
                Include(x => x.Chip).
                Include(x => x.Ram).
                Include(x => x.Rom).
                Include(x => x.MauSac)
                .FirstOrDefaultAsync(x => x.IdChiTietSp == id);
            return _mapper.Map<SanPhamChiTietViewModel>(sanPhamChiTiet);
        }

        public async Task<IEnumerable<SanPhamDanhSachViewModel>> GetListSanPhamNgungKinhDoanhViewModelAsync()
        {
            var sanPhamChiTietViewModels = (await _context.SanPhamChiTiets.ToListAsync()).Where(it => it.TrangThai == (int)TrangThaiCoBan.KhongHoatDong).Select(item => CreateSanPhamDanhSachViewModel(item)).ToList();
            return sanPhamChiTietViewModels;
        }

        public async Task<bool> NgungKinhDoanhSanPhamAynsc(List<string> lstguid)
        {
            try
            {
                var sanPhams = await _context.SanPhamChiTiets
                    .Where(sp => lstguid.Contains(sp.IdChiTietSp!))
                    .ToListAsync();

                if (sanPhams.Count != lstguid.Count)
                {
                    return false;
                }

                foreach (var sanPham in sanPhams)
                {
                    sanPham.TrangThai = (int)TrangThaiCoBan.KhongHoatDong;
                    _context.SanPhamChiTiets.Update(sanPham);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> KinhDoanhLaiSanPhamAynsc(List<string> lstguid)
        {
            try
            {
                var sanPhams = await _context.SanPhamChiTiets
                    .Where(sp => lstguid.Contains(sp.IdChiTietSp!))
                    .ToListAsync();

                if (sanPhams.Count != lstguid.Count)
                {
                    return false;
                }

                foreach (var sanPham in sanPhams)
                {
                    sanPham.TrangThai = (int)TrangThaiCoBan.HoatDong;
                    _context.SanPhamChiTiets.Update(sanPham);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> KhoiPhucKinhDoanhAynsc(string id)
        {
            try
            {
                var entity = await GetByKeyAsync(id)!;
                if (entity == null) return false;
                entity.TrangThai = (int)TrangThaiCoBan.HoatDong;
                _context.SanPhamChiTiets.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<SanPhamChiTietExcelViewModel>> GetListSanPhamExcelAynsc()
        {
            var listSanPhamChiTiet = (await _context.SanPhamChiTiets.
                Include(x => x.Anh).
                Include(x => x.SanPham).
                Include(x => x.Hang).
                Include(x => x.ManHinh).
                Include(x => x.CongSac).
                Include(x => x.Pin).
                Include(x => x.TheNho).
                Include(x => x.Chip).
                Include(x => x.Ram).
                Include(x => x.Rom).
                Include(x => x.MauSac)
                .ToListAsync()).Where(sp => sp.TrangThai == 0).ToList();
            return _mapper.Map<List<SanPhamChiTiet>, List<SanPhamChiTietExcelViewModel>>(listSanPhamChiTiet);
        }

        public async Task<SanPhamChiTietDTO?> GetItemExcelAynsc(BienTheDTO bienTheDTO)
        {
            try
            {
                var manHinhLower = bienTheDTO.ManHinh!.Trim();
                var manHinh = await _context.ManHinhs.FirstOrDefaultAsync(cl => cl.LoaiManHinh!.ToLower().Trim() == manHinhLower);
                if (manHinh == null)
                {
                    manHinh = new ManHinh()
                    {
                        IdManHinh = Guid.NewGuid().ToString(),
                        MaManHinh = !_context.ManHinhs.Any() ? "MH1" : "MH2" + (_context.ManHinhs.Count() + 1),
                        LoaiManHinh = bienTheDTO.ManHinh.Trim(),
                        TrangThai = 0
                    };
                    await _context.ManHinhs.AddAsync(manHinh);
                }

                var hangLower = bienTheDTO.Hang!.Trim().ToLower();
                var hang = await _context.Hangs.FirstOrDefaultAsync(cl => cl.TenHang!.Trim().ToLower() == hangLower);
                if (hang == null)
                {
                    hang = new Hang()
                    {
                        IdHang = Guid.NewGuid().ToString(),
                        MaHang = !_context.Hangs.Any() ? "HANG1" : "HANG" + (_context.Hangs.Count() + 1),
                        TenHang = bienTheDTO.Hang.Trim(),
                        TrangThai = 0
                    };
                    await _context.Hangs.AddAsync(hang);
                }

                var mauSacLower = bienTheDTO.MauSac!.Trim().ToLower();
                var mauSac = await _context.MauSacs.FirstOrDefaultAsync(cl => cl.TenMauSac!.Trim().ToLower() == mauSacLower);
                if (mauSac == null)
                {
                    mauSac = new MauSac()
                    {
                        IdMauSac = Guid.NewGuid().ToString(),
                        MaMauSac = !_context.MauSacs.Any() ? "MS1" : "MS" + (_context.MauSacs.Count() + 1),
                        TenMauSac = bienTheDTO.MauSac.Trim(),
                        TrangThai = 0
                    };
                    await _context.MauSacs.AddAsync(mauSac);
                }

                var ram = await _context.Rams.FirstOrDefaultAsync(cl => cl.DungLuong == bienTheDTO.Ram!.Trim());
                if (ram == null)
                {
                    ram = new Ram()
                    {
                        IdRam = Guid.NewGuid().ToString(),
                        MaRam = !_context.Rams.Any() ? "RAM1" : "RAM" + (_context.Rams.Count() + 1),
                        DungLuong = bienTheDTO.Ram!.Trim(),
                        TrangThai = 0
                    };
                    await _context.Rams.AddAsync(ram);
                } 

                var rom = await _context.Roms.FirstOrDefaultAsync(cl => cl.DungLuong == bienTheDTO.Rom!.Trim());
                if (rom == null)
                {
                    rom = new Rom()
                    {
                        IdRom = Guid.NewGuid().ToString(),
                        MaRom = !_context.Rams.Any() ? "ROM1" : "ROM" + (_context.Rams.Count() + 1),
                        DungLuong = bienTheDTO.Ram!.Trim(),
                        TrangThai = 0
                    };
                    await _context.Roms.AddAsync(rom);
                }

                var pinLower = bienTheDTO.Pin!.Trim().ToLower();
                var pin = await _context.Pins.FirstOrDefaultAsync(cl => cl.LoaiPin!.Trim().ToLower() == pinLower);
                if (pin == null)
                {
                    pin = new Pin()
                    {
                        IdPin = Guid.NewGuid().ToString(),
                        MaPin = !_context.Pins.Any() ? "PIN1" : "PIN" + (_context.Pins.Count() + 1),
                        LoaiPin = bienTheDTO.Pin.Trim(),
                        TrangThai = 0
                    };
                    await _context.Pins.AddAsync(pin);
                }
                
                var chipLower = bienTheDTO.Chip!.Trim().ToLower();
                var chip = await _context.Chips.FirstOrDefaultAsync(cl => cl.TenChip!.Trim().ToLower() == chipLower);
                if (chip == null)
                {
                    chip = new Chip()
                    {
                        IdChip = Guid.NewGuid().ToString(),
                        MaChip = !_context.Chips.Any() ? "CHIP1" : "CHIP" + (_context.Chips.Count() + 1),
                        TenChip = bienTheDTO.Chip.Trim(),
                        TrangThai = 0
                    };
                    await _context.Chips.AddAsync(chip);
                }

                var theNhoLower = bienTheDTO.TheNho!.Trim().ToLower();
                var theNho = await _context.TheNhos.FirstOrDefaultAsync(cl => cl.LoaiTheNho!.Trim().ToLower() == theNhoLower);
                if (theNho == null)
                {
                    theNho = new TheNho()
                    {
                        IdTheNho = Guid.NewGuid().ToString(),
                        MaTheNho = !_context.TheNhos.Any() ? "TN1" : "TN" + (_context.TheNhos.Count() + 1),
                        LoaiTheNho = bienTheDTO.TheNho.Trim(),
                        TrangThai = 0
                    };
                    await _context.TheNhos.AddAsync(theNho);
                }

                var sanSanPhamLower = bienTheDTO.SanPham!.Trim().ToLower();
                var sanPham = await _context.SanPhams.FirstOrDefaultAsync(cl => cl.TenSanPham!.Trim().ToLower() == sanSanPhamLower);
                if (sanPham == null)
                {
                    sanPham = new SanPham()
                    {
                        IdSanPham = Guid.NewGuid().ToString(),
                        MaSanPham = !_context.SanPhams.Any() ? "SP1" : "SP" + (_context.SanPhams.Count() + 1),
                        TenSanPham = bienTheDTO.SanPham.Trim(),
                        Trangthai = 0
                    };
                    await _context.SanPhams.AddAsync(sanPham);
                }

                var congSacLower = bienTheDTO.Hang!.Trim().ToLower();
                var congSac = await _context.CongSacs.FirstOrDefaultAsync(cl => cl.LoaiCongSac!.Trim().ToLower() == congSacLower);
                if (congSac == null)
                {
                    congSac = new CongSac()
                    {
                        IdCongSac = Guid.NewGuid().ToString(),
                        MaCongSac = !_context.CongSacs.Any() ? "CS1" : "CS" + (_context.CongSacs.Count() + 1),
                        LoaiCongSac = bienTheDTO.CongSac.Trim(),
                        TrangThai = 0
                    };
                    await _context.CongSacs.AddAsync(congSac);
                }

                await _context.SaveChangesAsync();

                var spDTO = new SanPhamChiTietDTO()
                {
                    IdHang = hang.IdHang,
                    IdRam = ram.IdRam,
                    IdRom = rom.IdRom,
                    IdManHinh = manHinh.IdManHinh,
                    IdMauSac = mauSac.IdMauSac,
                    IdPin = pin.IdPin,
                    IdSanPham = sanPham.IdSanPham,
                    IdChip = chip.IdChip,
                    IdCongSac = congSac.IdCongSac,
                    IdTheNho = theNho.IdTheNho,
                };
                return spDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        public async Task UpdateSoLuongSanPhamChiTietAynsc(string IdSanPhamChiTiet, int soLuong)
        {
            try
            {
                var sanPhamChiTiet = await _context.SanPhamChiTiets.FirstOrDefaultAsync(x => x.IdChiTietSp == IdSanPhamChiTiet);
                sanPhamChiTiet!.SoLuongTon = sanPhamChiTiet.SoLuongTon - soLuong;
                sanPhamChiTiet!.SoLuongDaBan += soLuong;
                _context.SanPhamChiTiets.Update(sanPhamChiTiet);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        //Filter
        public async Task<FiltersVM> GetFiltersVMAynsc()
        {
            try
            {
                var query = _context.SanPhamChiTiets
                        .Where(sp => sp.TrangThai == (int)TrangThaiCoBan.HoatDong)
                        .Include(sp => sp.MauSac)
                        .Include(sp => sp.Hang)
                        .Include(sp => sp.Ram)
                        .Include(sp => sp.Rom);

                var data = await query.ToListAsync();

                return new FiltersVM()
                {
                    LstItemFilterMauSac = data
                    .GroupBy(sp => sp.MauSac.TenMauSac)
                    .Select(gr => new ItemFilter()
                    {
                        Ten = gr.Key,
                        SoLuong = data
                        .Where(sp => sp.MauSac.TenMauSac == gr.Key)
                        .GroupBy(
                          gr => new
                          {
                              gr.IdRam,
                              gr.IdSanPham,
                              gr.IdRom,
                              gr.IdChip,
                              gr.IdCongSac,
                              gr.IdManHinh,
                              gr.IdPin,
                              gr.IdHang,
                              gr.IdTheNho,
                          })
                        .Count()
                    })
                    .ToList(),
                    LstItemFilterRom = GetListItemFilter(data, sp => sp.Rom.DungLuong.ToString()!).OrderBy(x => x.Ten).ToList(),
                    LstItemFilterRam = data
                    .GroupBy(sp => sp.Ram.DungLuong)
                    .Select(gr => new ItemFilter()
                    {
                        Ten = gr.Key,
                        SoLuong = data
                        .Where(sp => sp.Ram.DungLuong == gr.Key)
                        .GroupBy(
                          gr => new
                          {
                              gr.IdMauSac,
                              gr.IdSanPham,
                              gr.IdRom,
                              gr.IdChip,
                              gr.IdCongSac,
                              gr.IdManHinh,
                              gr.IdPin,
                              gr.IdHang,
                              gr.IdTheNho,
                          })
                        .Count()
                    })
                    .ToList(),
                    LstItemFilterHang = data
                    .GroupBy(sp => sp.Hang.TenHang)
                    .Select(gr => new ItemFilter()
                    {
                        Ten = gr.Key,
                        SoLuong = data
                        .Where(sp => sp.Hang.TenHang == gr.Key)
                        .GroupBy(
                          gr => new
                          {
                              gr.IdRam,
                              gr.IdSanPham,
                              gr.IdRom,
                              gr.IdChip,
                              gr.IdCongSac,
                              gr.IdManHinh,
                              gr.IdPin,
                              gr.IdMauSac,
                              gr.IdTheNho,
                          })
                        .Count()
                    })
                    .ToList(),
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new FiltersVM();
            }

        }

        private List<ItemFilter> GetListItemFilter(List<SanPhamChiTiet> data, Func<SanPhamChiTiet, string> selector)
        {
            return data
                .GroupBy(selector)
                .Select(group => new ItemFilter()
                {
                    Ten = group.Key,
                    SoLuong = group.Count(),
                })
                .ToList();
        }

        public async Task<bool> ProductIsNull(SanPhamChiTietCopyDTO sanPhamChiTietCopyDTO)
        {
            var sanPhamChiTiet = await _context.SanPhamChiTiets
                .FirstOrDefaultAsync(x =>
                x.IdSanPham == sanPhamChiTietCopyDTO.SanPhamChiTietData!.IdSanPham &&
                x.IdMauSac == sanPhamChiTietCopyDTO.SanPhamChiTietData.IdMauSac &&
                x.IdTheNho == sanPhamChiTietCopyDTO.SanPhamChiTietData.IdTheNho &&
                x.IdMauSac == sanPhamChiTietCopyDTO.SanPhamChiTietData.IdMauSac &&
                x.IdPin == sanPhamChiTietCopyDTO.SanPhamChiTietData.IdPin &&
                x.IdCongSac == sanPhamChiTietCopyDTO.SanPhamChiTietData.IdCongSac &&
                x.IdChip == sanPhamChiTietCopyDTO.SanPhamChiTietData.IdChip &&
                x.IdRam == sanPhamChiTietCopyDTO.SanPhamChiTietData.IdRam &&
                x.IdRom == sanPhamChiTietCopyDTO.SanPhamChiTietData.IdRom &&
                x.IdManHinh == sanPhamChiTietCopyDTO.SanPhamChiTietData.IdManHinh
                );
            return sanPhamChiTiet != null ? false : true;
        }

        public async Task UpdateLstSanPhamTableAynsc(List<SanPhamTableDTO> sanPhamTableDTOs)
        {
            try
            {
                var lstSanPhamChiTiet = _mapper.Map<List<SanPhamTableDTO>, List<SanPhamChiTiet>>(sanPhamTableDTOs);
                foreach (var sanPhamChiTiet in lstSanPhamChiTiet)
                {
                    _context.Attach(sanPhamChiTiet);
                    _context.Entry(sanPhamChiTiet).Property(x => x.GiaBan).IsModified = true;
                    _context.Entry(sanPhamChiTiet).Property(x => x.SoLuongTon).IsModified = true;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<RelatedProductViewModel> GetRelatedProducts(string sumGuid)
        {
            try
            {
                var listGuid = sumGuid.Split('/');
                var idSanPham = listGuid[0];
                var idHang = listGuid[1];
                var idRam = listGuid[2];
                var idRom = listGuid[3];
                var idMauSac = listGuid[4];
                var idTheNho = listGuid[5];
                var idPin = listGuid[6];
                var idManHinh = listGuid[7];
                var idCongSac = listGuid[8];
                var idChip = listGuid[9];
                return _context
                        .SanPhamChiTiets
                        .Where(sp =>
                        sp.IdSanPham == idSanPham &&
                        sp.IdHang == idHang &&
                        sp.IdRam == idRam &&
                        sp.IdRom == idRom &&
                        sp.IdMauSac == idMauSac &&
                        sp.IdTheNho == idTheNho &&
                        sp.IdPin == idPin &&
                        sp.IdManHinh == idManHinh &&
                        sp.IdCongSac == idCongSac &&
                        sp.IdChip == idChip
                        ).
                        Include(sp => sp.SanPham).
                        Include(sp => sp.MauSac).
                        Include(sp => sp.Ram).
                        Include(sp => sp.Rom).
                        Include(sp => sp.Anh).
                        AsEnumerable().
                        GroupBy(sp => sp.IdMauSac).
                        OrderBy(gr => gr.Key).
                        SelectMany(gr => gr.OrderBy(sp => sp.Ram.DungLuong).
                        Select(sp => new RelatedProductViewModel()
                        {
                            IdSanPham = sp.IdChiTietSp,
                            MaSanPham = sp.Ma,
                            GiaNhap = sp.GiaNhap.GetValueOrDefault(),
                            Anh = sp.Anh.Where(a => a.TrangThai == 0).OrderBy(a => a.NgayTao).FirstOrDefault()!.Url,
                            MauSac = sp.MauSac.TenMauSac,
                            GiaBan = sp.GiaBan.GetValueOrDefault(),
                            Ram = sp.Ram.DungLuong,
                            Rom = sp.Rom.DungLuong,
                            SanPham = sp.SanPham.TenSanPham,
                            SoLuong = sp.SoLuongTon.GetValueOrDefault(),
                            SoLuongDaBan = sp.SoLuongDaBan.GetValueOrDefault(),
                            KhoiLuong = sp.KhoiLuong.GetValueOrDefault(),
                            TrangThai = sp.TrangThai.GetValueOrDefault()
                        })).ToList();
            }
            catch (Exception)
            {

                return new List<RelatedProductViewModel>();
            }

        }

        public async Task<List<SPDanhSachViewModel>> GetFilteredDaTaDSTongQuanAynsc(ParametersTongQuanDanhSach parametersTongQuanDanhSach)
        {
            var query = _context.SanPhamChiTiets.AsQueryable();

            if (!string.IsNullOrEmpty(parametersTongQuanDanhSach.IdSanPham))
            {
                query = query.Where(it => it.IdSanPham == parametersTongQuanDanhSach.IdSanPham);
            }

            if (!string.IsNullOrEmpty(parametersTongQuanDanhSach.IdHang))
            {
                query = query.Where(it => it.IdHang == parametersTongQuanDanhSach.IdHang);
            }

            if (!string.IsNullOrEmpty(parametersTongQuanDanhSach.IdChip))
            {
                query = query.Where(it => it.IdChip == parametersTongQuanDanhSach.IdChip);
            }

            if (!string.IsNullOrEmpty(parametersTongQuanDanhSach.IdManHinh))
            {
                query = query.Where(it => it.IdManHinh == parametersTongQuanDanhSach.IdManHinh);
            }

            if (!string.IsNullOrEmpty(parametersTongQuanDanhSach.IdCongSac))
            {
                query = query.Where(it => it.IdCongSac == parametersTongQuanDanhSach.IdCongSac);
            }

            if (!string.IsNullOrEmpty(parametersTongQuanDanhSach.IdPin))
            {
                query = query.Where(it => it.IdPin == parametersTongQuanDanhSach.IdPin);
            }
            if (!string.IsNullOrEmpty(parametersTongQuanDanhSach.IdTheNho))
            {
                query = query.Where(it => it.IdTheNho == parametersTongQuanDanhSach.IdTheNho);
            }

            var result = query
                .Include(sp => sp.SanPham)
                .Include(sp => sp.Hang)
                .Include(sp => sp.Chip)
                .Include(sp => sp.ManHinh)
                .Include(sp => sp.CongSac)
                .Include(sp => sp.TheNho)
                .Include(sp => sp.Pin);

            var viewModelResult = result
                .GroupBy(gr => new
                {
                    gr.IdHang,
                    gr.IdSanPham,
                    gr.IdChip,
                    gr.IdManHinh,
                    gr.IdCongSac,
                    gr.IdPin,
                    gr.IdTheNho,
                })
                .Select(gr => new SPDanhSachViewModel
                {
                    SumGuild = $"{gr.Key.IdSanPham}/{gr.Key.IdHang}/{gr.Key.IdChip}/{gr.Key.IdManHinh}/{gr.Key.IdCongSac}/{gr.Key.IdPin}/{gr.Key.IdTheNho}",
                    SanPham = gr.First().SanPham.TenSanPham,
                    Chip = gr.First().Chip.TenChip,
                    ManHinh = gr.First().ManHinh.LoaiManHinh,
                    CongSac = gr.First().CongSac.LoaiCongSac,
                    Hang = gr.First().Hang.TenHang,
                    Pin = gr.First().Pin.DungLuong,
                    TheNho = gr.First().TheNho.LoaiTheNho,
                    SoMau = gr.Select(it => it.IdMauSac).Distinct().Count(),
                    SoRam = gr.Select(it => it.IdRam).Distinct().Count(),
                    SoRom = gr.Select(it => it.IdRom).Distinct().Count(),
                    TongSoLuongTon = gr.Sum(it => it.SoLuongTon.GetValueOrDefault()),
                    TongSoLuongDaBan = gr.Sum(it => it.SoLuongDaBan.GetValueOrDefault())
                });

            if (!string.IsNullOrEmpty(parametersTongQuanDanhSach.SearchValue))
            {
                string searchValueLower = parametersTongQuanDanhSach.SearchValue.ToLower();
                viewModelResult = viewModelResult
                    .Where(x =>
                        x.SanPham!.ToLower().Contains(searchValueLower) ||
                        x.Hang!.ToLower().Contains(searchValueLower) ||
                        x.Chip!.ToLower().Contains(searchValueLower) ||
                        x.CongSac!.ToLower().Contains(searchValueLower) ||
                        x.Pin!.ToLower().Contains(searchValueLower) ||
                        x.TheNho!.ToLower().Contains(searchValueLower) ||
                        x.ManHinh!.ToLower().Contains(searchValueLower));
            }

            return await viewModelResult.ToListAsync();
        }

        public IQueryable<SanPhamChiTiet> GetQuerySanPhamChiTiet()
        {
            using (var context = new AppDbContext())
            {
                return _context.SanPhamChiTiets.AsNoTracking();
            }
        }
    }
}