//using App_Data.DbContext;
//using App_Data.Models.ViewModels.MauSac;
//using App_Data.ViewModels.RamDTO;
//using App_Data.ViewModels.RomDTO;
//using App_Data.ViewModels.CongSacDTO;
//using App_Data.ViewModels.ChipDTO;
//using App_Data.ViewModels.ManHinhDTO;
//using App_Data.ViewModels.TheNhoDTO;
//using App_Data.ViewModels.CameraDTO;
//using App_Data.ViewModels.SanPhamChiTiet.SanPhamDTO;
//using App_Data.ViewModels.HangDTO;
//using App_Data.ViewModels.ThuocTinh;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using App_Data.ViewModels.PinDTO;
//using App_Data.ViewModels.TheSimDTO;
//using App_Data.Models;

//namespace App_View.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [Authorize(Roles = "Admin")]
//    public class ThuocTinhSanPhamController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly HttpClient _httpClient;
//        public ThuocTinhSanPhamController(HttpClient httpClient)
//        {
//            _context = new AppDbContext();
//            _httpClient = httpClient;
//        }

//        public IActionResult LoadPartialViewDanhSachTenSanPham()
//        {
//            var lstTenSP = _context
//                .SanPhams
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdSanPham,
//                    Ma = it.MaSanPham,
//                    Ten = it.TenSanPham,
//                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdSanPham == it.IdSanPham).Count(),
//                    TrangThai = it.Trangthai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhSanPhamPartialView", lstTenSP);
//        }
//        public IActionResult LoadPartialViewDanhSachHang()
//        {
//            var lstHang = _context
//                .Hangs
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdHang,
//                    Ma = it.MaHang,
//                    Ten = it.TenHang,
//                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdHang == it.IdHang).Count(),
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhHangPartialView", lstHang);
//        }
//        public IActionResult LoadPartialViewDanhSachTheNho()
//        {
//            var lstTheNho = _context
//                .TheNhos
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdTheNho,
//                    Ma = it.MaTheNho,
//                    LoaiTheNho = it.LoaiTheNho,
//                    DungLuong = it.DungLuong,
//                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdTheNho == it.IdTheNho).Count(),
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhTheNhoPartialView", lstTheNho);
//        }

//        public IActionResult LoadPartialViewDanhSachManHinh()
//        {
//            var lstManHinh = _context
//                .ManHinhs
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdManHinh,
//                    Ma = it.MaManHinh,
//                    KichThuoc = it.KichThuoc,
//                    LoaiManHinh = it.LoaiManHinh,
//                    TanSoQuet = it.TanSoQuet,
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động",
//                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdManHinh == it.IdManHinh).Count(),

//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhManHinhPartialView", lstManHinh);
//        }

//        public IActionResult LoadPartialViewDanhSachChip()
//        {
//            var lstChip = _context
//                .Chips
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdChip,
//                    Ma = it.MaChip,
//                    Ten = it.TenChip,
//                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdChip == it.IdChip).Count(),
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhChipPartialView", lstChip);
//        }
//        public IActionResult LoadPartialViewDanhSachCamera()
//        {
//            var lstCamera = _context
//                .Cameras
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdCamera,
//                    Ma = it.MaCamera,
//                    Ten = it.DoPhanGiai,
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhCameraPartialView", lstCamera);
//        }

//        public IActionResult LoadPartialViewDanhSachTheSim()
//        {
//            var lstTheSim = _context
//                .TheSims
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdTheSim,
//                    Ma = it.MaTheSim,
//                    Ten = it.Loaithesim,
//                    SoKhaySim = it.SoKhaySim,
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhTheSimPartialView", lstTheSim);
//        }

//        public IActionResult LoadPartialViewDanhSachCongSac()
//        {
//            var lstCongSac = _context
//                .CongSacs
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdCongSac,
//                    Ma = it.MaCongSac,
//                    LoaiCongSac = it.LoaiCongSac,
//                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdCongSac == it.IdCongSac).Count(),
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhCongSacPartialView", lstCongSac);
//        }

//        public IActionResult LoadPartialViewDanhSachMauSac()
//        {
//            var lstMauSac = _context
//                .MauSacs
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdMauSac,
//                    Ma = it.MaMauSac,
//                    Ten = it.TenMauSac,
//                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdMauSac == it.IdMauSac).Count(),
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .OrderBy(it => int.Parse(it.Ma!.Substring(2)))
//                .ToList();

//            return PartialView("_DanhSachThuocTinhMauSacPartialView", lstMauSac);
//        }
//        public IActionResult LoadPartialViewDanhSachRom()
//        {
//            var lstRom = _context
//                .Roms
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdRom,
//                    Ma = it.MaRom,
//                    DungLuongRomEnum = it.DungLuong,
//                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdRom == it.IdRom).Count(),
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhRomPartialView", lstRom);
//        }
//        public IActionResult LoadPartialViewDanhSachRam()
//        {
//            var lstRam = _context
//                .Rams
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdRam,
//                    Ma = it.MaRam,
//                    DungLuongRamEnum = it.DungLuong,
//                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdRam == it.IdRam).Count(),
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhRamPartialView", lstRam);
//        }

//        public IActionResult DanhSachThuocTinhSanPham()
//        {
//            return View();
//        }


//        #region ThaoTac
//        //Xoa San Pham

//        public async Task<IActionResult> DeleteSanPham(string idSanPham)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/SanPham/XoaSanPham={idSanPham}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        [HttpPost]
//        public async Task<IActionResult> EditSanPham([FromBody] SanPhamDTO sanPham)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/SanPham/SuaSanPham", sanPham);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        private async Task<bool> CheckSanPhamExists(string tenSanPham)
//        {
//            try
//            {
//                var existingSanPham = await _context.SanPhams.AnyAsync(r => r.TenSanPham == tenSanPham);
//                return existingSanPham;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateSanPham([FromBody] SanPhamDTO createSanPhamDTO)
//        {
//            try
//            {
//                var checkSanPham = new SanPham
//                {
//                    TenSanPham = createSanPhamDTO.TenSanPham
//                };
//                var ramExists = await CheckSanPhamExists(checkSanPham.TenSanPham);

//                if (ramExists)
//                {
//                    return BadRequest("Dung lượng RAM đã tồn tại.");
//                }

//                var response = await _httpClient.PostAsJsonAsync("/api/SanPham", createSanPhamDTO);

//                if (response.IsSuccessStatusCode)
//                {
//                    return Ok(await response.Content.ReadAsAsync<bool>());
//                }
//                return Ok(false);
//            }
//            catch (Exception ex)
//            {
//                return Ok(false);
//            }
//        }
//        public async Task<IActionResult> DeleteHang(string idHang)
//        {
//            var response = await _httpClient.DeleteAsync($"api/Hang/XoaHang/{idHang}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        private async Task<bool> CheckHangExists(string tenHang)
//        {
//            try
//            {
//                var existingHang = await _context.Hangs.AnyAsync(r => r.TenHang == tenHang);
//                return existingHang;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateHang([FromBody] CreateHangDTO createHangDTO)
//        {
//            try
//            {
//                var checkHang = new Hang
//                {
//                    TenHang = createHangDTO.tenHang
//                };
//                var ramExists = await CheckHangExists(checkHang.TenHang);

//                if (ramExists)
//                {
//                    return BadRequest("Dung lượng RAM đã tồn tại.");
//                }

//                var response = await _httpClient.PostAsJsonAsync("/api/Hang", createHangDTO);

//                if (response.IsSuccessStatusCode)
//                {
//                    return Ok(await response.Content.ReadAsAsync<bool>());
//                }
//                return Ok(false);
//            }
//            catch (Exception ex)
//            {
//                return Ok(false);
//            }
//        }
//        [HttpPost]
//        public async Task<IActionResult> EditHang([FromBody] HangDTO hang)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/Hang/sua-hang", hang);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        public async Task<IActionResult> DeleteRam(string idRam)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/Ram/XoaRam/{idRam}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        public async Task<IActionResult> CreateRam([FromBody] CreateRamDTO createRamDTO)
//        {
//            try
//            {
//                var checkRam = new Ram
//                {
//                    DungLuong = createRamDTO.dungLuongRam
//                };
//                var ramExists = await CheckRamExists(checkRam.DungLuong);

//                if (ramExists)
//                {
//                    return BadRequest("Dung lượng RAM đã tồn tại.");
//                }

//                var response = await _httpClient.PostAsJsonAsync("/api/Ram", createRamDTO);

//                if (response.IsSuccessStatusCode)
//                {
//                    return Ok(await response.Content.ReadAsAsync<bool>());
//                }
//                return Ok(false);
//            }
//            catch (Exception ex)
//            {
//                return Ok(false);
//            }
//        }

//        private async Task<bool> CheckRamExists(string dungLuongRam)
//        {
//            try
//            {
//                var existingRam = await _context.Rams.AnyAsync(r => r.DungLuong == dungLuongRam);
//                return existingRam;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> EditRam([FromBody] RamDTO ramDTO)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/Ram/sua-Ram", ramDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        private async Task<bool> CheckRomExists(string dungLuongRom)
//        {
//            try
//            {
//                var existingRom = await _context.Roms.AnyAsync(r => r.DungLuong == dungLuongRom);
//                return existingRom;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateRom([FromBody] CreateRomDTO createRomDTO)
//        {
//            try
//            {
//                var checkRom = new Rom
//                {
//                    DungLuong = createRomDTO.dungLuongRom
//                };
//                var ramExists = await CheckRomExists(checkRom.DungLuong);

//                if (ramExists)
//                {
//                    return BadRequest("Dung lượng RAM đã tồn tại.");
//                }

//                var response = await _httpClient.PostAsJsonAsync("api/Rom", createRomDTO);

//                if (response.IsSuccessStatusCode)
//                {
//                    return Ok(await response.Content.ReadAsAsync<bool>());
//                }
//                return Ok(false);
//            }
//            catch (Exception ex)
//            {
//                return Ok(false);
//            }
//        }
//        public async Task<IActionResult> DeleteRom(string idRom)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/Rom/XoaRom/{idRom}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        [HttpPost]
//        public async Task<IActionResult> EditRom([FromBody] RomDTO romDTO)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/Rom/sua-Rom", romDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        public async Task<IActionResult> DeleteCongSac(string idCongSac)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/CongSac/{idCongSac}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        private async Task<bool> CheckCongSacExists(string loaiCongSac)
//        {
//            try
//            {
//                var existingCongSac = await _context.CongSacs.AnyAsync(r => r.LoaiCongSac == loaiCongSac);
//                return existingCongSac;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public async Task<IActionResult> CreateCongSac([FromBody] CongSacDTO congSacDTO)
//        {
//            var checkCongSac = new CongSac
//            {
//                LoaiCongSac = congSacDTO.LoaiCongSac
//            };
//            var ramExists = await CheckCongSacExists(checkCongSac.LoaiCongSac);

//            if (ramExists)
//            {
//                return BadRequest("Dung lượng RAM đã tồn tại.");
//            }
//            var response = await _httpClient.PostAsJsonAsync($"/api/CongSac", congSacDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        [HttpPost]
//        public async Task<IActionResult> EditCongSac([FromBody] CongSacDTO congSacDTO)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/congSac", congSacDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        public async Task<IActionResult> DeleteChip(string idChip)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/Chip/{idChip}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        private async Task<bool> CheckChipExists(string tenChip)
//        {
//            try
//            {
//                var existingChip = await _context.Chips.AnyAsync(r => r.TenChip == tenChip);
//                return existingChip;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public async Task<IActionResult> CreateChip([FromBody] ChipDTO chipDTO)
//        {
//            var checkChip = new Chip
//            {
//                TenChip = chipDTO.TenChip
//            };
//            var ramExists = await CheckChipExists(checkChip.TenChip);

//            if (ramExists)
//            {
//                return BadRequest("Dung lượng RAM đã tồn tại.");
//            }

//            var response = await _httpClient.PostAsJsonAsync($"/api/Chip", chipDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        [HttpPost]
//        public async Task<IActionResult> EditChip([FromBody] ChipDTO chipDTO)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/Chip", chipDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        private async Task<bool> CheckTheSimExists(string loaiTheSim)
//        {
//            try
//            {
//                var existingTheSim = await _context.TheSims.AnyAsync(r => r.Loaithesim == loaiTheSim);
//                return existingTheSim;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public async Task<IActionResult> CreateTheSim([FromBody] TheSimDTO theSimDTO)
//        {
//            var checkTheSim = new TheSim
//            {
//                Loaithesim = theSimDTO.Loaithesim
//            };
//            var ramExists = await CheckTheSimExists(checkTheSim.Loaithesim);

//            if (ramExists)
//            {
//                return BadRequest("Dung lượng RAM đã tồn tại.");
//            }

//            var response = await _httpClient.PostAsJsonAsync($"/api/TheSim/Create-TheSim", theSimDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        public async Task<IActionResult> DeleteTheSim(string idTheSim)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/TheSim/{idTheSim}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        [HttpPost]
//        public async Task<IActionResult> EditTheSim([FromBody] TheSimDTO chipDTO)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/TheSim", chipDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        private async Task<bool> CheckMauSacExists(string tenmausac)
//        {
//            try
//            {
//                var existingMauSac = await _context.MauSacs.AnyAsync(r => r.TenMauSac == tenmausac);
//                return existingMauSac;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public async Task<IActionResult> CreateMauSac([FromBody] MauSacDTO mauSacDTO)
//        {
//            var checkMauSac = new MauSac
//            {
//                TenMauSac = mauSacDTO.TenMauSac
//            };
//            var ramExists = await CheckMauSacExists(checkMauSac.TenMauSac);

//            if (ramExists)
//            {
//                return BadRequest("Dung lượng RAM đã tồn tại.");
//            }


//            var response = await _httpClient.PostAsJsonAsync($"/api/MauSac/CreateMauSac", mauSacDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        public async Task<IActionResult> DeleteMauSac(string idMauSac)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/MauSac/DeleteMauSac/{idMauSac}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        [HttpPost]
//        public async Task<IActionResult> EditMauSac([FromBody] MauSacDTO mauSacDTO)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/mausac/sua-mau-sac", mauSacDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        public async Task<IActionResult> DeleteManHinh(string idManHinh)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/ManHinh/{idManHinh}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        private async Task<bool> CheckManHinhExists(string loaiManHinh)
//        {
//            try
//            {
//                var existingManHinh = await _context.ManHinhs.AnyAsync(r => r.LoaiManHinh == loaiManHinh);
//                return existingManHinh;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public async Task<IActionResult> CreateManHinh([FromBody] ManHinhDTO manHinhDTO)
//        {
//            try
//            {
//                var checkManHinh = new ManHinh
//                {
//                    LoaiManHinh = manHinhDTO.LoaiManHinh
//                };
//                var ramExists = await CheckManHinhExists(checkManHinh.LoaiManHinh);

//                if (ramExists)
//                {
//                    return BadRequest("Dung lượng RAM đã tồn tại.");
//                }

//                var response = await _httpClient.PostAsJsonAsync($"/api/ManHinh", manHinhDTO);
//                if (response.IsSuccessStatusCode)
//                {
//                    return Ok(await response.Content.ReadAsAsync<bool>());
//                }
//                return Ok(false);
//            }
//            catch (Exception ex)
//            {
//                return Ok(false);
//            }
//        }
//        [HttpPost]
//        public async Task<IActionResult> EditManHinh([FromBody] ManHinhDTO ManHinhDTO)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/manHinh/", ManHinhDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        public async Task<IActionResult> DeleteTheNho(string idTheNho)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/TheNho/{idTheNho}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        private async Task<bool> CheckTheNhoExists(string loaiTheNho)
//        {
//            try
//            {
//                var existingTheNho = await _context.TheNhos.AnyAsync(r => r.LoaiTheNho == loaiTheNho);
//                return existingTheNho;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public async Task<IActionResult> CreateTheNho([FromBody] TheNhoDTO theNhoDTO)
//        {
//            try
//            {
//                var checkTheNho = new TheNho
//                {
//                    LoaiTheNho = theNhoDTO.LoaiTheNho
//                };
//                var ramExists = await CheckTheNhoExists(checkTheNho.LoaiTheNho);

//                if (ramExists)
//                {
//                    return BadRequest("Dung lượng RAM đã tồn tại.");
//                }

//                var response = await _httpClient.PostAsJsonAsync($"/api/TheNho", theNhoDTO);
//                if (response.IsSuccessStatusCode)
//                {
//                    return Ok(await response.Content.ReadAsAsync<bool>());
//                }
//                return Ok(false);
//            }
//            catch (Exception ex)
//            {
//                return Ok(false);
//            }

            
//        }
//        [HttpPost]
//        public async Task<IActionResult> EditTheNho([FromBody] TheNhoDTO TheNhoDTO)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/theNho", TheNhoDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }

//        public async Task<IActionResult> DeleteCamera(string idCamera)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/Camera/{idCamera}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        private async Task<bool> CheckCameraExists(string dophangiai)
//        {
//            try
//            {
//                var existingCamera = await _context.Cameras.AnyAsync(r => r.DoPhanGiai == dophangiai);
//                return existingCamera;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public async Task<IActionResult> CreateCamera([FromBody] CameraDTO CameraDTO)
//        {

//            try
//            {
//                var checkCamera = new Camera
//                {
//                    DoPhanGiai = CameraDTO.DoPhanGiai
//                };
//                var ramExists = await CheckCameraExists(checkCamera.DoPhanGiai);

//                if (ramExists)
//                {
//                    return BadRequest("Dung lượng RAM đã tồn tại.");
//                }


//                var response = await _httpClient.PostAsJsonAsync($"/api/Camera/Create-Camera", CameraDTO);
//                if (response.IsSuccessStatusCode)
//                {
//                    return Ok(await response.Content.ReadAsAsync<bool>());
//                }
//                return Ok(false);
//            }
//            catch (Exception ex)
//            {
//                return Ok(false);
//            }

//        }

//        [HttpPost]
//        public async Task<IActionResult> EditCamera([FromBody] CameraDTO CameraDTO)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/Camera", CameraDTO);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        //Pin
//        public IActionResult LoadPartialViewDanhSachPin()
//        {
//            var lstPin = _context
//                .Pins
//                .AsNoTracking()
//                .Select(it => new ThuocTinhViewModel()
//                {
//                    Id = it.IdPin,
//                    Ma = it.MaPin,
//                    DungLuong = it.DungLuong,
//                    LoaiPin = it.LoaiPin,
//                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdPin == it.IdPin).Count(),
//                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
//                })
//                .AsEnumerable()
//                .ToList();

//            return PartialView("_DanhSachThuocTinhPinPartialView", lstPin);
//        }
//        public async Task<IActionResult> DeletePin(string idPin)
//        {
//            var response = await _httpClient.DeleteAsync($"/api/Pin/XoaPin/{idPin}");
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        private async Task<bool> CheckPinExists(string loaiPin)
//        {
//            try
//            {
//                var existingPin = await _context.Pins.AnyAsync(r => r.LoaiPin == loaiPin);
//                return existingPin;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreatePin([FromBody] CreatePinDTO createPinDTO)
//        {
//            try
//            {
//                var checkPin = new Pin
//                {
//                    LoaiPin = createPinDTO.LoaiPin
//                };
//                var ramExists = await CheckPinExists(checkPin.LoaiPin);

//                if (ramExists)
//                {
//                    return BadRequest("Dung lượng RAM đã tồn tại.");
//                }

//                var response = await _httpClient.PostAsJsonAsync("/api/Pin", createPinDTO);

//                if (response.IsSuccessStatusCode)
//                {
//                    return Ok(await response.Content.ReadAsAsync<bool>());
//                }
//                return Ok(false);
//            }
//            catch (Exception ex)
//            {
//                return Ok(false);
//            }
//        }
//        [HttpPost]
//        public async Task<IActionResult> EditPin([FromBody] PinDTO pin)
//        {
//            var response = await _httpClient.PutAsJsonAsync("/api/Pin/Sua-pin", pin);
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(await response.Content.ReadAsAsync<bool>());
//            }
//            return Ok(false);
//        }
//        #endregion
//    }
//}
