using App_Data.IRepositories;
using App_Data.Models;
using App_Data.ViewModels.MauSac;
using App_Data.ViewModels.SanPhamChiTiet.SanPhamDTO;
using App_Data.ViewModels.SanPhamChiTietDTO;
using App_Data.ViewModels.SanPhamChiTietViewModel;
using App_Data.ViewModels.XuatXu;
using AutoMapper;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing.Imaging;
using System.Drawing;
using System.Reflection;
using App_Data.ViewModels.FilterViewModel;
using System.Management.Automation;
using App_Data.ViewModels.FilterDTO;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.InkML;
using static App_Data.Repositories.TrangThai;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using App_Data.ViewModels.HangDTO;
using App_Data.ViewModels.RamDTO;
using App_Data.ViewModels.RomDTO;
using App_Data.ViewModels.PinDTO;
using System.Runtime.Intrinsics.Arm;
using App_Data.ViewModels.ChipDTO;
using System.Collections.Immutable;
using App_Data.ViewModels.TheNhoDTO;
using App_Data.ViewModels.CongSacDTO;
using App_Data.ViewModels.ManHinhDTO;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamChiTietController : ControllerBase
    {
        private readonly IAllRepo<Hang> _hangs;
        private readonly IAllRepo<Ram> _ram;
        private readonly IAllRepo<Rom> _rom;
        private readonly IAllRepo<Pin> _pinRes;
        private readonly IAllRepo<Chip> _chipRes;
        private readonly IAllRepo<TheNho> _theNhoRes;
        private readonly IAllRepo<CongSac> _congSacRes;
        private readonly IAllRepo<TheSim> _theSimRes;
        private readonly IAllRepo<CameraTruoc> _cameraTruocRes;
        private readonly IAllRepo<CameraSau> _cameraSauRes;
        private readonly IAllRepo<ManHinh> _manHinhRes;
        private readonly IAllRepo<SanPham> _sanPhamRes;
        private readonly IAllRepo<MauSac> _mauSacRes;
        private readonly ISanPhamChiTietRespo _sanPhamChiTietRes;
        private readonly IAllRepo<Anh> _AnhRes;
        private readonly IMapper _mapper;
        private readonly AnhController _anhController;

        public SanPhamChiTietController(IAllRepo<Hang> hangRes, IAllRepo<Ram> ramRes, IAllRepo<Rom> romRes, IAllRepo<Pin> pinRes, IAllRepo<Chip> chipRes, IAllRepo<TheNho> theNhoRes, IAllRepo<CongSac> congSacRes, IAllRepo<TheSim> theSimRes, IAllRepo<CameraTruoc> cameraTruocRes, IAllRepo<CameraSau> cameraSauRes, IAllRepo<ManHinh> manHinhRes, IAllRepo<SanPham> sanPhamRes, IAllRepo<MauSac> mauSacRes, ISanPhamChiTietRespo sanPhamChiTietRes, IMapper mapper, IAllRepo<Anh> anhRes, AnhController anhController)
        {
            _hangs = hangRes;
            _ram = ramRes;
            _rom = romRes;
            _pinRes = pinRes;
            _chipRes = chipRes;
            _theNhoRes = theNhoRes;
            _congSacRes = congSacRes;
            _theSimRes = theSimRes;
            _cameraTruocRes = cameraTruocRes;
            _cameraSauRes = cameraSauRes;
            _manHinhRes = manHinhRes;
            _sanPhamRes = sanPhamRes;
            _mauSacRes = mauSacRes;
            _sanPhamChiTietRes = sanPhamChiTietRes;
            _mapper = mapper;
            _AnhRes = anhRes;
            _anhController = anhController;
        }

        [HttpPost("check-add-or-update")]
        public async Task<ResponseCheckAddOrUpdate> CheckProductForAddOrUpdate(SanPhamChiTietDTO sanPhamChiTietDTO)
        {
            var productDetails = (await _sanPhamChiTietRes.GetListAsync())
                .FirstOrDefault(x =>
                x.IdMauSac == sanPhamChiTietDTO.IdMauSac &&
                x.IdSanPham == sanPhamChiTietDTO.IdSanPham &&
                x.IdPin == sanPhamChiTietDTO.IdPin &&
                x.IdChip == sanPhamChiTietDTO.IdChip &&
                x.IdTheNho == sanPhamChiTietDTO.IdTheNho && 
                x.IdCongSac == sanPhamChiTietDTO.IdCongSac && 
                x.IdManHinh == sanPhamChiTietDTO.IdManHinh &&
                x.IdHang == sanPhamChiTietDTO.IdHang &&
                x.IdRam == sanPhamChiTietDTO.IdRam &&
                x.IdRom == sanPhamChiTietDTO.IdRom
                );

            if (productDetails != null)
            {
                var productDetaiDTOMap = _mapper.Map<SanPhamChiTietDTO>(productDetails);
                productDetaiDTOMap.DanhSachAnh = _AnhRes.GetAll()
                                .Where(img => img.TrangThai == 0 && img.IdSanPhamChiTiet == productDetaiDTOMap.IdChiTietSp)
                                .Select(x => x.Url)
                                .ToList()!;
                return new ResponseCheckAddOrUpdate() { Success = true, Data = productDetaiDTOMap };

            }
            return new ResponseCheckAddOrUpdate() { Success = false, Data = null };
        }

        [HttpGet("Get-List-SanPhamChiTietViewModel")]
        public async Task<List<SanPhamDanhSachViewModel>> GetListSanPham()
        {
            return (await _sanPhamChiTietRes.GetListViewModelAsync()).ToList();
        }
        [HttpGet("GetAll-List-SanPhamChiTietViewModel")]
        public async Task<List<SanPhamDanhSachViewModel>> GetAllListSanPham()
        {
            return (await _sanPhamChiTietRes.GetAllListViewModelAsync()).ToList();
        }

        [HttpGet("Get-List-SanPhamChiTiet")]
        public async Task<List<SanPhamChiTiet>> GetListSanPhamChiTiet()
        {
            return (await _sanPhamChiTietRes.GetListAsync()).ToList();
        }

        [HttpPost("Get-List-SanPhamChiTietDTO")]
        public async Task<List<SanPhamChiTietDTO>> GetListSanPhamChiTietDTO(List<string> lstGuid)
        {
            return await _sanPhamChiTietRes.GetListSanPhamChiTietDTOAsync(lstGuid);
        }

        [HttpGet("Get-DanhSachDienThoaiViewModel")]
        public async Task<DanhSachDienThoaiViewModel> GetDanhSachDienThoai()
        {
            return await _sanPhamChiTietRes.GetDanhSachDienThoaiViewModelAsync(); ;
        }

        [HttpGet("khoi-phuc-kinh-doanh/{id}")]
        public async Task<bool> KhoiPhucKinhDoanh(string id)
        {
            return await _sanPhamChiTietRes.KhoiPhucKinhDoanhAynsc(id);
        }

        [HttpGet("Get-List-SanPhamNgungKinhDoanhViewModel")]
        public async Task<List<SanPhamDanhSachViewModel>> GetDanhSachGiayNgungKinhDoanh()
        {
            return (await _sanPhamChiTietRes.GetListSanPhamNgungKinhDoanhViewModelAsync()).ToList();
        }

        [HttpPut("UpdateSoLuong")]
        public async Task UpDateSoLuong(SanPhamSoLuongDTO sanPhamSoLuongDTO)
        {
            await _sanPhamChiTietRes.UpdateSoLuongSanPhamChiTietAynsc(sanPhamSoLuongDTO.IdChiTietSanPham, sanPhamSoLuongDTO.SoLuong);
        }

        [HttpGet("Get-List-ItemShopViewModel")]
        public async Task<List<ItemShopViewModel>?> GetDanhSachItemShowViewModel()
        {
            return await _sanPhamChiTietRes.GetDanhSachItemShopViewModelAsync();
        }

        [HttpGet("Get-List-ItemBienTheShopViewModel")]
        public async Task<List<ItemShopViewModel>?> GetDanhSachItemBienTheShowViewModel()
        {
            return await _sanPhamChiTietRes.GetDanhSachBienTheItemShopViewModelAsync();
        }

        [HttpGet("Get-List-ItemBienTheShopViewModelSale")]
        public async Task<List<ItemShopViewModel>?> GetDanhSachItemBienTheShowViewModelSale()
        {
            return await _sanPhamChiTietRes.GetDanhSachBienTheItemShopViewModelSaleAsync();
        }

        [HttpGet("Get-SanPhamChiTiet/{id}")]
        public async Task<SanPhamChiTiet?> GetSanPham(string id)
        {
            return await _sanPhamChiTietRes.GetByKeyAsync(id);
        }

        [HttpGet("Get-SanPhamChiTietViewModel/{id}")]
        public async Task<SanPhamChiTietViewModel?> GetSanPhamViewModel(string id)
        {
            return await _sanPhamChiTietRes.GetSanPhamChiTietViewModelAynsc(id);
        }

        [HttpGet("Get-ItemDetailViewModel/{id}")]
        public async Task<ItemDetailViewModel?> GetItemDetailViewModel(string id)
        {
            return await _sanPhamChiTietRes.GetItemDetailViewModelAynsc(id);
        }

        [HttpGet("Get-ItemDetailViewModel/{id}/{mauSac}")]
        public async Task<ItemDetailViewModel?> GetItemDetailViewModelWhenSelectColor(string id, string mauSac)
        {
            return await _sanPhamChiTietRes.GetItemDetailViewModelWhenSelectColorAynsc(id, mauSac);
        }

        [HttpGet("Get-ItemDetailViewModel/idsanpham/{id}/ram/{ram}")]
        public async Task<ItemDetailViewModel?> GetItemDetailViewModelWhenSelectSize(string id, string ram)
        {
            return await _sanPhamChiTietRes.GetItemDetailViewModelWhenSelectRamAynsc(id, ram);
        }

        [HttpPost("Creat-SanPhamChiTiet")]
        public async Task<ResponseCreateDTO> CreateSanPhamChiTiet(SanPhamChiTietDTO sanPhamChiTietDTO)
        {
            try
            {
                var sanPhamChiTietCheck = (await _sanPhamChiTietRes.GetListAsync())
                .FirstOrDefault(x =>
                x.IdHang == sanPhamChiTietDTO.IdHang &&
                x.IdMauSac == sanPhamChiTietDTO.IdMauSac &&
                x.IdRam == sanPhamChiTietDTO.IdRam &&
                x.IdRom == sanPhamChiTietDTO.IdRom &&
                x.IdSanPham == sanPhamChiTietDTO.IdSanPham &&
                x.IdPin == sanPhamChiTietDTO.IdPin &&
                x.IdChip == sanPhamChiTietDTO.IdChip &&
                x.IdTheNho == sanPhamChiTietDTO.IdTheNho &&
                x.IdCongSac == sanPhamChiTietDTO.IdCongSac &&
                x.IdManHinh == sanPhamChiTietDTO.IdManHinh
                );
                if (sanPhamChiTietCheck == null)
                {
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string rootPath = Directory.GetParent(currentDirectory)!.FullName;
                    string uploadDirectory = Path.Combine(rootPath, "App_View", "wwwroot", "images", "QRCode");

                    var sanPhamChiTiet = _mapper.Map<SanPhamChiTiet>(sanPhamChiTietDTO);
                    sanPhamChiTiet.IdChiTietSp = Guid.NewGuid().ToString();
                    var mauSac = _mauSacRes.GetAll().FirstOrDefault(ms => ms.IdMauSac == sanPhamChiTietDTO.IdMauSac)!.TenMauSac!.Substring(0, 2);
                    sanPhamChiTiet.Ma = "SP-" + ((int)1000 + (await _sanPhamChiTietRes.GetListAsync()).Count()).ToString() + "-" + mauSac + "-" + _ram + "/" + _rom;
                    sanPhamChiTiet.TrangThai = 0;
                    sanPhamChiTiet.SoLuongDaBan = 0;
                    sanPhamChiTiet.NgayTao = DateTime.Now;

                    if (!string.IsNullOrEmpty(uploadDirectory) && !string.IsNullOrEmpty(sanPhamChiTiet.Ma))
                    {
                        string qrCodeImagePath = Path.Combine(uploadDirectory, sanPhamChiTiet.Ma + ".png");

                        if (!Directory.Exists(uploadDirectory))
                        {
                            Directory.CreateDirectory(uploadDirectory);
                        }

                        if (!System.IO.File.Exists(qrCodeImagePath))
                        {
                            QRCodeGenerator qrGenerator = new QRCodeGenerator();
                            QRCodeData qrCodeData = qrGenerator.CreateQrCode(sanPhamChiTiet.Ma, QRCodeGenerator.ECCLevel.Q);
                            QRCode qrCode = new QRCode(qrCodeData);

                            Bitmap qrCodeImage = qrCode.GetGraphic(20, System.Drawing.Color.DarkBlue, System.Drawing.Color.White, true);

                            using (var stream = new FileStream(qrCodeImagePath, FileMode.Create))
                            {
                                qrCodeImage.Save(stream, ImageFormat.Png);
                            }
                        }
                    }

                    return new ResponseCreateDTO()
                    {
                        Success = await _sanPhamChiTietRes.AddAsync(sanPhamChiTiet),
                        IdChiTietSp = sanPhamChiTiet.IdChiTietSp
                    };
                }
                return new ResponseCreateDTO()
                {
                    Success = false,
                    DescriptionErr = "Sản phẩm đã tồn tại"
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new ResponseCreateDTO()
                {
                    Success = false,
                    DescriptionErr = ex.Message
                };
            }
        }

        [HttpPost("Creat-SanPhamChiTietCopy")]
        public async Task<bool> CreateSanPhamChiTietCoppy([FromForm] SanPhamChiTietCopyDTO sanPhamChiTietCopyDTO)
        {
            try
            {
                if ((await _sanPhamChiTietRes.ProductIsNull(sanPhamChiTietCopyDTO)))
                {
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string rootPath = Directory.GetParent(currentDirectory)!.FullName;
                    string uploadDirectory = Path.Combine(rootPath, "App_View", "wwwroot", "images", "QRCode");

                    var sanPhamChiTiet = _mapper.Map<SanPhamChiTiet>(sanPhamChiTietCopyDTO.SanPhamChiTietData);
                    sanPhamChiTiet.IdChiTietSp = Guid.NewGuid().ToString();
                    var mauSac = _mauSacRes.GetAll().FirstOrDefault(ms => ms.IdMauSac == sanPhamChiTiet.IdMauSac)!.TenMauSac!.Substring(0, 2);
                    sanPhamChiTiet.Ma = "SP-" + ((int)1000 + (await _sanPhamChiTietRes.GetListAsync()).Count()).ToString() + "-" + mauSac + "-" + _ram + "/" + _rom;
                    sanPhamChiTiet.TrangThai = 0;
                    sanPhamChiTiet.SoLuongDaBan = 0;
                    sanPhamChiTiet.NgayTao = DateTime.Now;

                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(sanPhamChiTiet.Ma, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);

                    Bitmap qrCodeImage = qrCode.GetGraphic(20, System.Drawing.Color.DarkBlue, System.Drawing.Color.White, true);

                    string qrCodeImagePath = Path.Combine(uploadDirectory, sanPhamChiTiet.Ma + ".png");

                    using (var stream = new FileStream(qrCodeImagePath, FileMode.Create))
                    {
                        qrCodeImage.Save(stream, ImageFormat.Png);
                    }

                    await _sanPhamChiTietRes.AddAsync(sanPhamChiTiet);

                    if (sanPhamChiTietCopyDTO.SanPhamChiTietData!.DanhSachAnh != null)
                    {
                        if (sanPhamChiTietCopyDTO.ListTenAnhRemove == null) sanPhamChiTietCopyDTO.ListTenAnhRemove = new List<string>();
                        var listAnhCopy = sanPhamChiTietCopyDTO.SanPhamChiTietData!.DanhSachAnh!.Except(sanPhamChiTietCopyDTO.ListTenAnhRemove!).ToList();
                        listAnhCopy.ForEach(tenAnh =>
                        {
                            _AnhRes.AddItem(new Anh
                            {
                                IdAnh = Guid.NewGuid().ToString(),
                                IdSanPhamChiTiet = sanPhamChiTiet.IdChiTietSp,
                                TrangThai = 0,
                                NgayTao = DateTime.Now,
                                Url = tenAnh
                            });
                        });
                    }

                    if (sanPhamChiTietCopyDTO.ListAnhCreate != null && sanPhamChiTietCopyDTO.ListAnhCreate!.Any())
                    {
                        await _anhController.CreateImage(sanPhamChiTiet.IdChiTietSp, sanPhamChiTietCopyDTO.ListAnhCreate!);
                    }
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        [HttpPut("Ngung_Kinh_Doanh_List_SanPham")]
        public async Task<bool> NgungKinhDoanhSanPham(List<string> lstGuild)
        {
            return await _sanPhamChiTietRes.NgungKinhDoanhSanPhamAynsc(lstGuild);
        }

        [HttpPut("Update-Kinh_Doanh_List_SanPham")]
        public async Task<bool> KinhDoanhLaiSanPham(List<string> lstGuild)
        {
            return await _sanPhamChiTietRes.KinhDoanhLaiSanPhamAynsc(lstGuild);
        }

        [HttpDelete("Delete-SanPhamChiTiet/{id}")]
        public async Task<bool> DeleteSanPham(string id)
        {
            var sanPhamChiTiet = await GetSanPham(id);
            if (sanPhamChiTiet != null)
            {
                sanPhamChiTiet.TrangThai = 1;
                return await _sanPhamChiTietRes.UpdateAsync(sanPhamChiTiet);
            }
            return false;
        }

        [HttpPut("Update-SanPhamChiTiet")]
        public async Task<bool> Update(SanPhamChiTietDTO sanPhamChiTietDTO)
        {
            var spChiTiet = await GetSanPham(sanPhamChiTietDTO.IdChiTietSp!);

            if (spChiTiet != null)
            {
                var sanPhamChiTietCheck = (await _sanPhamChiTietRes.GetListAsync())
                .FirstOrDefault(x =>
                x.IdHang == sanPhamChiTietDTO.IdHang &&
                x.IdMauSac == sanPhamChiTietDTO.IdMauSac &&
                x.IdRam == sanPhamChiTietDTO.IdRam &&
                x.IdRom == sanPhamChiTietDTO.IdRom &&
                x.IdSanPham == sanPhamChiTietDTO.IdSanPham &&
                x.IdPin == sanPhamChiTietDTO.IdPin &&
                x.IdChip == sanPhamChiTietDTO.IdChip &&
                x.IdTheNho == sanPhamChiTietDTO.IdTheNho &&
                x.IdCongSac == sanPhamChiTietDTO.IdCongSac &&
                x.IdManHinh == sanPhamChiTietDTO.IdManHinh
                );
                if (
                (sanPhamChiTietDTO.IdHang == spChiTiet.IdHang &&
                  sanPhamChiTietDTO.IdMauSac == spChiTiet.IdMauSac &&
                  sanPhamChiTietDTO.IdRam == spChiTiet.IdRam &&
                  sanPhamChiTietDTO.IdRom == spChiTiet.IdRom &&
                  sanPhamChiTietDTO.IdSanPham == spChiTiet.IdSanPham &&
                  sanPhamChiTietDTO.IdPin == spChiTiet.IdPin &&
                  sanPhamChiTietDTO.IdChip == spChiTiet.IdChip &&
                  sanPhamChiTietDTO.IdTheNho == spChiTiet.IdTheNho &&
                  sanPhamChiTietDTO.IdCongSac == spChiTiet.IdCongSac &&
                  sanPhamChiTietDTO.IdManHinh == spChiTiet.IdManHinh) || sanPhamChiTietCheck == null
                )
                {
                    _mapper.Map(sanPhamChiTietDTO, spChiTiet);
                    return await _sanPhamChiTietRes.UpdateAsync(spChiTiet);
                }
            }
            return false;
        }

        [HttpGet("get_list_SanPhamExcel")]
        public async Task<List<SanPhamChiTietExcelViewModel>> GetLstSanPhamExcel()
        {
            return await _sanPhamChiTietRes.GetListSanPhamExcelAynsc();
        }

        [HttpPost("get-ItemExcel")]
        public async Task<SanPhamChiTietDTO?> GetItemExcel(BienTheDTO bienTheDTO)
        {
            return await _sanPhamChiTietRes.GetItemExcelAynsc(bienTheDTO);
        }

        //GetItemfilterVm
        [HttpGet("get-ItemFilterVM")]
        public async Task<FiltersVM> GetItemFilterVM()
        {
            return await _sanPhamChiTietRes.GetFiltersVMAynsc();
        }

        #region AddVariants
        //SanPham
        [HttpPost("Create-SanPham")]
        public SanPhamDTO? CreateSanPham(SanPhamDTO sanPhamDTO)
        {
            var nameproduct = sanPhamDTO.TenSanPham!.Trim();

            if (!_sanPhamRes.GetAll().Where(sp => sp.Trangthai == 0).Select(i => i.TenSanPham).Contains(nameproduct, StringComparer.OrdinalIgnoreCase))
            {
                var sanPham = _mapper.Map<SanPham>(sanPhamDTO);
                sanPham.IdSanPham = Guid.NewGuid().ToString();
                sanPham.MaSanPham = !_sanPhamRes.GetAll().Any() ? "SP1" : "SP" + (_sanPhamRes.GetAll().Count() + 1);
                sanPham.Trangthai = 0;
                _sanPhamRes.AddItem(sanPham);
                sanPhamDTO.IdSanPham = sanPham.IdSanPham;
                return sanPhamDTO;
            }
            return null;
        }
        [HttpPost("Create-Hang")]
        public HangDTO? CreateHang(HangDTO hangDTO)
        {
            var nameHang = hangDTO.TenHang!.Trim();

            if (!_hangs.GetAll().Where(sp => sp.TrangThai == 0).Select(i => i.TenHang).Contains(nameHang, StringComparer.OrdinalIgnoreCase))
            {
                var hang = _mapper.Map<Hang>(hangDTO);
                hang.IdHang = Guid.NewGuid().ToString();
                hang.MaHang = !_hangs.GetAll().Any() ? "H1" : "H" + (_hangs.GetAll().Count() + 1);
                hang.TrangThai = 0;
                _hangs.AddItem(hang);
                hangDTO.IdHang = hang.IdHang;
                return hangDTO;
            }
            return null;
        }
        //Ram
        [HttpPost("Create-Ram")]
        public RamDTO? CreateRam(RamDTO ramDTO)
        {
            var nameRam = ramDTO.TenRam!.Trim();

            if (!_ram.GetAll().Where(sp => sp.TrangThai == 0).Select(i => i.TenRam).Contains(nameRam, StringComparer.OrdinalIgnoreCase))
            {
                var ram = _mapper.Map<Ram>(ramDTO);
                ram.IdRam = Guid.NewGuid().ToString();
                ram.MaRam = !_ram.GetAll().Any() ? "R1" : "R" + (_ram.GetAll().Count() + 1);
                ram.TrangThai = 0;
                _ram.AddItem(ram);
                ramDTO.IdRam = ram.IdRam;
                return ramDTO;
            }
            return null;
        }
        //Rom
        [HttpPost("Create-Rom")]
        public RomDTO? CreateRom(RomDTO romDTO)
        {
            var nameRom = romDTO.TenRom!.Trim();

            if (!_rom.GetAll().Where(sp => sp.TrangThai == 0).Select(i => i.TenRom).Contains(nameRom, StringComparer.OrdinalIgnoreCase))
            {
                var rom = _mapper.Map<Rom>(romDTO);
                rom.IdRom = Guid.NewGuid().ToString();
                rom.MaRom = !_rom.GetAll().Any() ? "RO1" : "RO" + (_rom.GetAll().Count() + 1);
                rom.TrangThai = 0;
                _rom.AddItem(rom);
                romDTO.IdRom = rom.IdRom;
                return romDTO;
            }
            return null;
        }
        //Pin
        [HttpPost("Create-Pin")]
        public PinDTO? CreatePin(PinDTO pinDTO)
        {
            var nameLoaiPin = pinDTO.LoaiPin!.Trim();
            if (!_pinRes.GetAll().Where(sp => sp.TrangThai == 0).Select(i => i.LoaiPin).Contains(nameLoaiPin, StringComparer.OrdinalIgnoreCase))
            {
                var loaiPin = _mapper.Map<Pin>(pinDTO);
                loaiPin.IdPin = Guid.NewGuid().ToString();
                loaiPin.MaPin = !_pinRes.GetAll().Any() ? "PIN1" : "PIN" + (_pinRes.GetAll().Count() + 1);
                loaiPin.TrangThai = 0;
                _pinRes.AddItem(loaiPin);
                pinDTO.IdPin = loaiPin.IdPin;
                return pinDTO;
            }
            return null;
        }

        //Chip
        [HttpPost("Create-Chip")]
        public ChipDTO? CreateChip(ChipDTO chipDTO)
        {
            var nameChip = chipDTO.TenChip!.Trim();
            if (!_chipRes.GetAll().Where(sp => sp.TrangThai == 0).Select(i => i.TenChip).Contains(nameChip, StringComparer.OrdinalIgnoreCase))
            {
                var loaiChip = _mapper.Map<Chip>(nameChip);
                loaiChip.IdChip = Guid.NewGuid().ToString();
                loaiChip.MaChip = !_chipRes.GetAll().Any() ? "CHIP1" : "CHIP" + _chipRes.GetAll().Count() + 1;
                loaiChip.TrangThai = 0;
                _chipRes.AddItem(loaiChip);
                chipDTO.IdChip = loaiChip.IdChip;
                return chipDTO;
            }
            return null;
        }

        //TheNho
        [HttpPost("Create-TheNho")]
        public TheNhoDTO? CreateChip(TheNhoDTO theNhoDTO)
        {
            var nameChip = theNhoDTO.LoaiTheNho!.Trim();
            if (!_theNhoRes.GetAll().Where(sp => sp.TrangThai == 0).Select(i => i.LoaiTheNho).Contains(nameChip, StringComparer.OrdinalIgnoreCase))
            {
                var loaiTheNho = _mapper.Map<TheNho>(nameChip);
                loaiTheNho.IdTheNho = Guid.NewGuid().ToString();
                loaiTheNho.MaTheNho = !_theNhoRes.GetAll().Any() ? "TN1" : "TN" + _chipRes.GetAll().Count() + 1;
                loaiTheNho.TrangThai = 0;
                _theNhoRes.AddItem(loaiTheNho);
                theNhoDTO.IdTheNho = loaiTheNho.IdTheNho;
                return theNhoDTO;
            }
            return null;
        }

        //CongSac
        [HttpPost("Create-CongSac")]
        public CongSacDTO? CreateCongSac(CongSacDTO congSacDTO)
        {
            var nameCongSac = congSacDTO.LoaiCongSac!.Trim();
            if (!_congSacRes.GetAll().Where(sp => sp.TrangThai == 0).Select(i => i.LoaiCongSac).Contains(nameCongSac, StringComparer.OrdinalIgnoreCase))
            {
                var loaiCongSac = _mapper.Map<CongSac>(nameCongSac);
                loaiCongSac.IdCongSac = Guid.NewGuid().ToString();
                loaiCongSac.MaCongSac = !_congSacRes.GetAll().Any() ? "CS1" : "CS" + _chipRes.GetAll().Count() + 1;
                loaiCongSac.TrangThai = 0;
                _congSacRes.AddItem(loaiCongSac);
                congSacDTO.IdCongSac = loaiCongSac.IdCongSac;
                return congSacDTO;
            }
            return null;
        }

        //ManHinh
        [HttpPost("Create-ManHinh")]
        public ManHinhDTO? CreateManHinh(ManHinhDTO manHinhDTO)
        {
            var nameManHinh = manHinhDTO.LoaiManHinh!.Trim();
            if (!_manHinhRes.GetAll().Where(sp => sp.TrangThai == 0).Select(i => i.LoaiManHinh).Contains(nameManHinh, StringComparer.OrdinalIgnoreCase))
            {
                var loaiManHinh = _mapper.Map<ManHinh>(nameManHinh);
                loaiManHinh.IdManHinh = Guid.NewGuid().ToString();
                loaiManHinh.MaManHinh = !_congSacRes.GetAll().Any() ? "MH1" : "MH" + _chipRes.GetAll().Count() + 1;
                loaiManHinh.TrangThai = 0;
                _manHinhRes.AddItem(loaiManHinh);
                manHinhDTO.IdManHinh = loaiManHinh.IdManHinh;
                return manHinhDTO;
            }
            return null;
        }


        //MauSac
        [HttpPost("Create-MauSac")]
        public MauSacDTO? CreateMauSac(MauSacDTO mauSac)
        {
            var nameMauSac = mauSac.TenMauSac.Trim();
            if (!_mauSacRes.GetAll().Where(sp => sp.TrangThai == 0).Select(i => i.TenMauSac).Contains(nameMauSac, StringComparer.OrdinalIgnoreCase))
            {
                var loaiGiay = _mapper.Map<MauSac>(mauSac);
                loaiGiay.IdMauSac = Guid.NewGuid().ToString();
                loaiGiay.MaMauSac = !_mauSacRes.GetAll().Any() ? "MS1" : "MS" + (_mauSacRes.GetAll().Count() + 1);
                loaiGiay.TrangThai = 0;
                _mauSacRes.AddItem(loaiGiay);
                mauSac.IdMauSac = loaiGiay.IdMauSac;
                return mauSac;
            }
            return null;
        }

       
        #endregion

        #region GetListVariants
        [HttpGet("Get-List-Ram")]
        public List<Ram>? GetListRam()
        {
            return _ram.GetAll().ToList();
        }
        
        [HttpGet("Get-List-Rom")]
        public List<Rom>? GetListRom()
        {
            return _rom.GetAll().ToList();
        }

        [HttpGet("Get-List-Pin")]
        public List<Pin>? GetListModelPin()
        {
            return _pinRes.GetAll().ToList();
        } 
        
        [HttpGet("Get-List-Chip")]
        public List<Chip>? GetListModelChip()
        {
            return _chipRes.GetAll().ToList();
        }  
        
        [HttpGet("Get-List-TheNho")]
        public List<TheNho>? GetListModelTheNho()
        {
            return _theNhoRes.GetAll().ToList();
        }
        
        [HttpGet("Get-List-CongSac")]
        public List<CongSac>? GetListModelCongSac()
        {
            return _congSacRes.GetAll().ToList();
        }
         
        [HttpGet("Get-List-ManHinh")]
        public List<ManHinh>? GetListModelManHinh()
        {
            return _manHinhRes.GetAll().ToList();
        }

        [HttpGet("Get-List-MauSac")]
        public List<MauSac>? GetListModelMauSac()
        {
            return _mauSacRes.GetAll().ToList();
        }

        [HttpGet("Get-List-SanPham")]
        public List<SanPham>? GetListModelSanPham()
        {
            return _sanPhamRes.GetAll().ToList();
        }

        [HttpGet("Get-List-Hang")]
        public List<Hang>? GetListModelHang()
        {
            return _hangs.GetAll().ToList();
        }
        #endregion

        [HttpPut("Update-List-SanPhamTable")]
        public async Task<bool> UpdateListSanPhamTableDTO(List<SanPhamTableDTO> lstSanPhamTableDTO)
        {
            try
            {
                await _sanPhamChiTietRes.UpdateLstSanPhamTableAynsc(lstSanPhamTableDTO);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("Get-List-RelatedProduct")]
        public List<RelatedProductViewModel> GetRelatedProducts(string sumGuild)
        {
            return _sanPhamChiTietRes.GetRelatedProducts(sumGuild);
        }

        [HttpPost("LayDanhSachTongQuan")]
        public async Task<IActionResult> LayDanhSachDienTu([FromBody] ParametersTongQuanDanhSach parameters)
        {
            try
            {
                var viewModelResult = await _sanPhamChiTietRes.GetFilteredDaTaDSTongQuanAynsc(parameters);

                var paginatedResult = viewModelResult
                    .Skip(parameters.Start)
                    .Take(parameters.Length)
                    .ToList();

                return new ObjectResult(new
                {
                    draw = parameters.Draw,
                    recordsTotal = viewModelResult.Count,
                    recordsFiltered = viewModelResult.Count,
                    data = paginatedResult
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("get-danh-sach-san-pham-dang-kinh-doanh")]
        public async Task<IActionResult> GetListTableDanhSachSanPhamDangKinhDoanh([FromBody] FilterAdminDTO filterAdminDTO)
        {
            var query = _sanPhamChiTietRes.GetQuerySanPhamChiTiet()
                .Where(sp => sp.TrangThai == (int)TrangThaiCoBan.HoatDong)
                .OrderByDescending(sp => sp.NgayTao)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filterAdminDTO.searchValue))
            {
                query = query
                 .Include(it => it.SanPham)
                 .Where(x =>
                     EF.Functions.Like(x.SanPham.TenSanPham!, $"%{filterAdminDTO.searchValue}%"));

            }

            if (!string.IsNullOrEmpty(filterAdminDTO.SanPham))
            {
                query = query
                    .Where(x => x.IdSanPham == filterAdminDTO.SanPham.ToString());
            }

            if (!string.IsNullOrEmpty(filterAdminDTO.MauSac))
            {
                query = query
                    .Where(x => x.IdMauSac == filterAdminDTO.MauSac.ToString());
            }

            if (!string.IsNullOrEmpty(filterAdminDTO.Hang))
            {
                query = query
                    .Where(x => x.IdHang == filterAdminDTO.Hang.ToString());
            }

            if (!string.IsNullOrEmpty(filterAdminDTO.Ram))
            {
                query = query
                     .Where(x => x.IdRam == filterAdminDTO.Ram.ToString());
            } 
            
            if (!string.IsNullOrEmpty(filterAdminDTO.Rom))
            {
                query = query
                     .Where(x => x.IdRom == filterAdminDTO.Rom.ToString());
            }

            if (!string.IsNullOrEmpty(filterAdminDTO.Sort))
            {
                if (filterAdminDTO.Sort == "ascending_quantity")
                {
                    query = query
                        .OrderBy(x => x.SoLuongTon!);
                }

                if (filterAdminDTO.Sort == "descending_quantity")
                {
                    query = query
                        .OrderByDescending(x => x.SoLuongTon!);
                }

                if (filterAdminDTO.Sort == "ascending_price")
                {
                    query = query
                        .OrderBy(x => x.GiaBan!);
                }

                if (filterAdminDTO.Sort == "descending_price")
                {
                    query = query
                        .OrderByDescending(x => x.GiaBan!);
                }
            }

            var totalRecords = await query.CountAsync();
            query = query
                .Skip(filterAdminDTO.start)
                .Take(filterAdminDTO.length);

            return new ObjectResult(new
            {
                draw = filterAdminDTO.draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = await query.Select(sp => _sanPhamChiTietRes.CreateSanPhamDanhSachViewModel(sp)).ToListAsync()
            });
        }

        [HttpGet("get-danh-sach-san-pham-shop-khoi-tao")]
        public FilterDataVM GetDanhSachSanPhamShop(string? brand, string? search)
        {
            try
            {
                var data = _sanPhamChiTietRes.GetQuerySanPhamChiTiet()
                    .Where(sp => sp.TrangThai == (int)TrangThaiCoBan.HoatDong)
                    .Include(x => x.Anh)
                    .Include(x => x.SanPham)
                    .Include(x => x.Hang)
                    .AsEnumerable()
                    .GroupBy(gr => new
                    {
                        gr.IdPin,
                        gr.IdChip,
                        gr.IdTheNho,
                        gr.IdCongSac,
                        gr.IdManHinh,
                        gr.IdSanPham,
                        gr.IdHang,
                    })
                    .Select(gr => gr.FirstOrDefault());
                var sumItem = data.Count();

                var brandLower = brand?.ToLower();
                var searchLower = search?.ToLower();

                if (!string.IsNullOrEmpty(brandLower))
                {
                    data = data.Where(sp =>
                        sp!.Hang!.TenHang!.Contains(brandLower, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(searchLower))
                {
                    data = data.Where(sp =>
                        sp!.SanPham.TenSanPham!.Contains(searchLower, StringComparison.OrdinalIgnoreCase));
                }

                var pageSize = 12;

                return new FilterDataVM
                {
                    Items = _mapper.Map<List<ItemShopViewModel>>(data.Take(12)),
                    PagingInfo = new PagingInfo
                    {
                        SoItemTrenMotTrang = pageSize,
                        TongSoItem = data.Count(),
                        TrangHienTai = 1
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return new FilterDataVM()
                {
                    Items = new List<ItemShopViewModel>(),
                    PagingInfo = new PagingInfo()
                    {
                        SoItemTrenMotTrang = 12,
                        TongSoItem = 0,
                        TrangHienTai = 1
                    }
                };
            }
        }

        [HttpPost("get-danh-sach-san-pham-shop")]
        public FilterDataVM GetDanhSachSanPhamShop(FilterData filterData)
        {
            try
            {
                var dataGet = _sanPhamChiTietRes.GetQuerySanPhamChiTiet()
               .AsNoTracking()
               .Include(x => x.Anh)
                   .Include(x => x.SanPham)
                   .Include(x => x.Hang)
                   .Where(sp => sp.TrangThai == (int)TrangThaiCoBan.HoatDong)
                   .AsEnumerable()
                  .GroupBy(gr => new
                  {
                      gr.IdPin,
                      gr.IdChip,
                      gr.IdTheNho,
                      gr.IdCongSac,
                      gr.IdManHinh,
                      gr.IdSanPham,
                      gr.IdHang,
                  })
                   .Select(gr => gr.FirstOrDefault());

                var data = _mapper.Map<IEnumerable<ItemShopViewModel>>(dataGet);

                if (!string.IsNullOrEmpty(filterData.Brand))
                {
                    var brandLower = filterData.Brand.ToLower();
                    data = data!.Where(sp => sp.Hang!.ToLower() == brandLower);
                }

                if (!string.IsNullOrEmpty(filterData.Sort))
                {
                    if (filterData.Sort == "price_asc")
                    {
                        data = data!.OrderBy(it => it.GiaMin);
                    }
                    else
                    {
                        data = data!.OrderByDescending(it => it.GiaMin);
                    }
                }

                if (filterData.LstMauSac!.Any())
                {
                    data = data!
                        .Where(sp => sp.LstMauSac!.Any(it => filterData.LstMauSac!.Contains(it.Text, StringComparer.OrdinalIgnoreCase)));
                }

                if (filterData.LstRating!.Any())
                {
                    data = data!
                        .Where(sp =>
                            filterData.LstRating!.Any(item =>
                                sp.SoSao >= item && sp.SoSao <= item + 1
                            )
                        );
                }

                if (filterData.GiaMin != 0 && filterData.GiaMax != 0)
                {
                    data = data!.Where(sp => sp.GiaMin >= filterData.GiaMin && sp.GiaMin <= filterData.GiaMax);
                }

                return new FilterDataVM()
                {
                    Items = data!.Skip((filterData.TrangHienTai - 1) * 12).Take(12).ToList(),
                    PagingInfo = new PagingInfo()
                    {
                        SoItemTrenMotTrang = 12,
                        TongSoItem = data!.Count(),
                        TrangHienTai = filterData.TrangHienTai
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return new FilterDataVM()
                {
                    Items = new List<ItemShopViewModel>(),
                    PagingInfo = new PagingInfo()
                    {
                        SoItemTrenMotTrang = 12,
                        TongSoItem = 0,
                        TrangHienTai = 1
                    }
                };
            }
        }
    }
}