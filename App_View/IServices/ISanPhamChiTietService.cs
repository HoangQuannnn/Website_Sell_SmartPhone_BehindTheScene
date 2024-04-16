﻿using App_Data.Models;
using App_Data.ViewModels.Anh;
using App_Data.ViewModels.ChiTietCameraDTO;
using App_Data.ViewModels.CongSacDTO;
using App_Data.ViewModels.HangDTO;

using App_Data.ViewModels.MauSac;
using App_Data.ViewModels.RamDTO;
using App_Data.ViewModels.RomDTO;
using App_Data.ViewModels.SanPhamChiTiet.SanPhamDTO;
using App_Data.ViewModels.SanPhamChiTietDTO;
using App_Data.ViewModels.SanPhamChiTietViewModel;
using App_Data.ViewModels.XuatXu;
using static App_View.Areas.Admin.Controllers.SanPhamChiTietController;

namespace App_View.IServices
{
 
    public interface ISanPhamChiTietservice
    {
        Task<ResponseCreateDTO> AddAysnc(SanPhamChiTietDTO sanPhamChiTietDTO);
        Task<bool> DeleteAysnc(string id);
        Task<bool> UpdateAynsc(SanPhamChiTietDTO sanPhamChiTietDTO);
        Task<SanPhamChiTiet?> GetByKeyAsync(string id);
        Task<SanPhamChiTietViewModel?> GetSanPhamChiTietViewModelByKeyAsync(string id);
        Task<List<SanPhamChiTiet>> GetListSanPhamChiTietAsync();
        Task<List<SanPhamChiTietDTO>> GetListSanPhamChiTietDTOAsync(ListGuildDTO listGuildDTO);
        Task<List<SanPhamDanhSachViewModel>> GetListSanPhamChiTietViewModelAsync();
        Task<List<SanPhamDanhSachViewModel>> GetAllListSanPhamChiTietViewModelAsync();
        Task<ResponseCheckAddOrUpdate> CheckSanPhamAddOrUpdate(SanPhamChiTietDTO sanPhamChiTietDTO);
        Task CreateAnhAysnc(string IdChiTietSp, List<IFormFile> lstIFormFile);
        Task DeleteAnhAysnc(ImageDTO responseImageDeleteVM);
        Task<SanPhamDTO?> CreateTenSanPhamAynsc(SanPhamDTO sanPhamDTO);
        Task<HangDTO?> CreateTenHangAynsc(HangDTO hangDTO);
        Task<XuatXuDTO?> CreateTenXuatXuAynsc(XuatXuDTO xuatXuDTO);
        Task<RamDTO?> CreateRamAynsc(RamDTO ramDTO);
        Task<CongSacDTO?> CreateCongSacAynsc(CongSacDTO CongsacDOT);
        Task<ChiTietCameraDTO?> CreateChitietCameraAynsc(ChiTietCameraDTO ChiTietCameraDTO);
        Task<MauSacDTO?> CreateTenMauSacAynsc(MauSacDTO mauSacDTO);
        Task<RomDTO?> CreateTenRomAynsc(RomDTO RomDTO);
        Task<List<ItemShopViewModel>?> GetListItemShopViewModelAynsc();
        Task<List<ItemShopViewModel>?> GetDanhSachBienTheItemShopViewModelAsync();
        Task<ItemDetailViewModel?> GetItemDetailViewModelAynsc(string id);
        Task<ItemDetailViewModel?> GetItemDetailViewModelWhenSelectColorAynsc(string id, string mauSac);
        Task<ItemDetailViewModel?> GetItemDetailViewModelWhenSelectSizeAynsc(string id, int size);
        Task<DanhSachGiayViewModel?> GetDanhSachGiayViewModelAynsc();
        Task<List<SanPhamDanhSachViewModel>> GetDanhSachGiayNgungKinhDoanhAynsc();
        Task<bool> NgungKinhDoanhSanPhamAynsc(ListGuildDTO lstGuid);
        Task<bool> KinhDoanhLaiSanPhamAynsc(ListGuildDTO lstGuid);
        Task<bool> KhoiPhucKinhDoanhAynsc(string id);
        Task<List<SanPhamChiTietExcelViewModel>> GetListSanPhamExcelAynsc();
        Task<SanPhamChiTietDTO> GetItemExcelAynsc(BienTheDTO bienTheDTO);
        Task UpDatSoLuongAynsc(SanPhamSoLuongDTO sanPhamSoLuongDTO);
        #region GetListModelVariants
        Task<List<Hang>> GetListModelChatLieuAsync();
        Task<List<Ram>> GetListModelKichCoAsync();
        Task<List<CongSac>> GetListModelKieuDeGiayAsync();
        Task<List<ChiTietCamera>> GetListModelLoaiGiayAsync();
        Task<List<MauSac>> GetListModelMauSacAsync();
        Task<List<SanPham>> GetListModelSanPhamAsync();
        Task<List<Rom>> GetListModelThuongHieuAsync();
        Task<List<Pin>> GetListModelXuatXuAsync();
        #endregion

    }
}