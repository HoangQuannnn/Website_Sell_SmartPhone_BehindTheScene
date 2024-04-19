using App_Data.Models;
using App_Data.ViewModels.Anh;
using App_Data.ViewModels.CameraSauDTO;
using App_Data.ViewModels.CameraTruocDTO;
using App_Data.ViewModels.ChipDTO;
using App_Data.ViewModels.ChiTietCameraDTO;
using App_Data.ViewModels.CongSacDTO;
using App_Data.ViewModels.HangDTO;
using App_Data.ViewModels.ManHinhDTO;
using App_Data.ViewModels.MauSac;
using App_Data.ViewModels.PinDTO;
using App_Data.ViewModels.RamDTO;
using App_Data.ViewModels.RomDTO;
using App_Data.ViewModels.SanPhamChiTiet.SanPhamDTO;
using App_Data.ViewModels.SanPhamChiTietDTO;
using App_Data.ViewModels.SanPhamChiTietViewModel;
using App_Data.ViewModels.TheNhoDTO;
using App_Data.ViewModels.TheSimDTO;
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
        Task<RamDTO?> CreateRamAynsc(RamDTO ramDTO);
        Task<RamDTO?> CreateRomAynsc(RomDTO romDTO);
        Task<ChipDTO?> CreateTenChipAynsc(ChipDTO chipDTO);
        Task<PinDTO?> CreateLoaiPinAynsc(PinDTO pinDTO);
        Task<CongSacDTO?> CreateCongSacAynsc(CongSacDTO congSacDTO);
        Task<TheNhoDTO?> CreateTheNhoAynsc(TheNhoDTO theNhoDTO);
        Task<TheSimDTO?> CreateTheSimAynsc(TheSimDTO theSimDTO);
        Task<ManHinhDTO?> CreateManHinhAynsc(ManHinhDTO manHinhDTO);
        Task<CameraTruocDTO?> CreateCameraTruocAynsc(CameraTruocDTO cameraTruocDTO);
        Task<CameraSauDTO?> CreateCameraSauAynsc(CameraSauDTO cameraSauDTO);
        Task<ChiTietCameraDTO?> CreateChitietCameraAynsc(ChiTietCameraDTO ChiTietCameraDTO);
        Task<MauSacDTO?> CreateTenMauSacAynsc(MauSacDTO mauSacDTO);
        Task<List<ItemShopViewModel>?> GetListItemShopViewModelAynsc();
        Task<List<ItemShopViewModel>?> GetDanhSachBienTheItemShopViewModelAsync();
        Task<ItemDetailViewModel?> GetItemDetailViewModelAynsc(string id);
        Task<ItemDetailViewModel?> GetItemDetailViewModelWhenSelectColorAynsc(string id, string mauSac);
        Task<ItemDetailViewModel?> GetItemDetailViewModelWhenSelectSizeAynsc(string id, int size);
        Task<DanhSachDienThoaiViewModel?> DanhSachDienThoaiViewModel();
        Task<List<SanPhamDanhSachViewModel>> GetDanhSachGiayNgungKinhDoanhAynsc();
        Task<bool> NgungKinhDoanhSanPhamAynsc(ListGuildDTO lstGuid);
        Task<bool> KinhDoanhLaiSanPhamAynsc(ListGuildDTO lstGuid);
        //Task<DanhSachDienThoaiViewModel?> GetDanhSachGiayViewModelAynsc();
        Task<bool> KhoiPhucKinhDoanhAynsc(string id);
        Task<List<SanPhamChiTietExcelViewModel>> GetListSanPhamExcelAynsc();
        Task<SanPhamChiTietDTO> GetItemExcelAynsc(BienTheDTO bienTheDTO);
        Task UpDatSoLuongAynsc(SanPhamSoLuongDTO sanPhamSoLuongDTO);
        #region GetListModelVariants
        Task<List<Hang>> GetListModelHangAsync();
        Task<List<Ram>> GetListModelRamAsync();
        Task<List<Rom>> GetListModelRomAsync();
        Task<List<CongSac>> GetListModelCongSacAsync();
        Task<List<ChiTietCamera>> GetListChiTietCamerasModelAsync();
        Task<List<MauSac>> GetListModelMauSacAsync();
        Task<List<SanPham>> GetListModelSanPhamAsync();
        Task<List<Chip>> GetListModelChipAsync();
        Task<List<Pin>> GetListModelPinAsync();
        Task<List<TheNho>> GetListModelTheNhoAsync();
        Task<List<TheSim>> GetListModelTheSimAsync();
        Task<List<CameraTruoc>> GetListModelCameraTruocAsync();
        Task<List<CameraSau>> GetListModelCameraSauAsync();
        Task<List<ManHinh>> GetListModelManHinhAsync();
        #endregion

    }
}
