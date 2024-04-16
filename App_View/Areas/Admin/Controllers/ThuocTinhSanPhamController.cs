using App_Data.DbContext;
using App_Data.Models;
using App_Data.Models.ViewModels.MauSac;
using App_Data.ViewModels.RamDTO;
using App_Data.ViewModels.RomDTO;
using App_Data.ViewModels.CongSacDTO;
using App_Data.ViewModels.ChipDTO;
using App_Data.ViewModels.ManHinhDTO;
using App_Data.ViewModels.TheNhoDTO;
using App_Data.ViewModels.PinDTO;

//using App_Data.ViewModels.KieuDeGiayDTO;
//using App_Data.ViewModels.LoaiGiayDTO;
using App_Data.ViewModels.SanPhamChiTiet.SanPhamDTO;
using App_Data.ViewModels.HangDTO;
using App_Data.ViewModels.ThuocTinh;
using App_Data.ViewModels.XuatXu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_View.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ThuocTinhSanPhamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;
        public ThuocTinhSanPhamController(HttpClient httpClient)
        {
            _context = new AppDbContext();
            _httpClient = httpClient;
        }

        public IActionResult LoadPartialViewDanhSachTenSanPham()
        {
            var lstTenSP = _context
                .SanPhams
                .AsNoTracking()
                .Select(it => new ThuocTinhViewModel()
                {
                    Id = it.IdSanPham,
                    Ma = it.MaSanPham,
                    Ten = it.TenSanPham,
                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdSanPham == it.IdSanPham).Count(),
                    TrangThai = it.Trangthai == 0 ? "Hoạt động" : "Không hoạt động"
                })
                .AsEnumerable()
                .OrderBy(it => int.Parse(it.Ma!.Substring(2)))
                .ToList();

            return PartialView("_DanhSachThuocTinhSanPhamPartialView",lstTenSP);
        }

        public IActionResult LoadPartialViewDanhSachHang()
        {
            var lstHang = _context
                .Hangs
                .AsNoTracking()
                .Select(it => new ThuocTinhViewModel()
                {
                    Id = it.IdHang,
                    Ma = it.MaHang,
                    Ten = it.TenHang,
                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdHang == it.IdHang).Count(),
                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                })
                .AsEnumerable()
                .OrderBy(it => int.Parse(it.Ma!.Substring(2)))
                .ToList();

            return PartialView("_DanhSachThuocTinhHangPartialView", lstHang);
        }
        public IActionResult LoadPartialViewDanhSachPin()
        {
            var lstPin = _context
                .Pins
                .AsNoTracking()
                .Select(it => new ThuocTinhViewModel()
                {
                    Id = it.IdPin,
                    Ma = it.MaPin,
                    Ten = it.IdPin,
                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdPin == it.IdPin).Count(),
                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                })
                .AsEnumerable()
                .OrderBy(it => int.Parse(it.Ma!.Substring(2)))
                .ToList();

            return PartialView("_DanhSachThuocTinhPinPartialView", lstPin);
        }
        public IActionResult LoadPartialViewDanhSachTheNho()
        {
            var lstTheNho = _context
                .TheNhos
                .AsNoTracking()
                .Select(it => new ThuocTinhViewModel()
                {
                    Id = it.IdTheNho,
                    Ma = it.MaTheNho,
                    Ten = it.DungLuong,
                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdTheNho == it.IdTheNho).Count(),
                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                })
                .AsEnumerable()
                .OrderBy(it => int.Parse(it.Ma!.Substring(2)))
                .ToList();

            return PartialView("_DanhSachThuocTinhTheNhoPartialView", lstTheNho);
        }

        public IActionResult LoadPartialViewDanhSachManHinh()
        {
            var lstManHinh = _context
                .ManHinhs
                .AsNoTracking()
                .Select(it => new ThuocTinhViewModel()
                {
                    Id = it.IdManHinh,
                    Ma = it.MaManHinh,
                    Ten = it.LoaiManHinh+ " " + it.KichThuoc.ToString(),
                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdManHinh == it.IdManHinh).Count(),
                    
                })
                .AsEnumerable()
                .OrderBy(it => int.Parse(it.Ma!.Substring(3)))
                .ToList();

            return PartialView("_DanhSachThuocTinhManHinhPartialView", lstManHinh);
        }

        public IActionResult LoadPartialViewDanhSachChip()
        {
            var lstChip = _context
                .Chips
                .AsNoTracking()
                .Select(it => new ThuocTinhViewModel()
                {
                    Id = it.IdChip,
                    Ma = it.MaChip,
                    Ten = it.TenChip,
                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdChip == it.IdChip).Count(),
                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                })
                .AsEnumerable()
                .OrderBy(it => int.Parse(it.Ma!.Substring(2)))
                .ToList();

            return PartialView("_DanhSachThuocTinhChipPartialView", lstChip);
        }

        public IActionResult LoadPartialViewDanhSachCongSac()
        {
            var lstCongSac = _context
                .CongSacs
                .AsNoTracking()
                .Select(it => new ThuocTinhViewModel()
                {
                    Id = it.IdCongSac,
                    Ma = it.MaCongSac,
                    Ten = it.LoaiCongSac,
                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdCongSac == it.IdCongSac).Count(),
                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                })
                .AsEnumerable()
                .OrderBy(it => int.Parse(it.Ma!.Substring(2)))
                .ToList();

            return PartialView("_DanhSachThuocTinhCongSacPartialView", lstCongSac);
        }

        public IActionResult LoadPartialViewDanhSachMauSac()
        {
            var lstMauSac = _context
                .MauSacs
                .AsNoTracking()
                .Select(it => new ThuocTinhViewModel()
                {
                    Id = it.IdMauSac,
                    Ma = it.MaMauSac,
                    Ten = it.TenMauSac,
                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdMauSac == it.IdMauSac).Count(),
                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                })
                .AsEnumerable()
                .OrderBy(it => int.Parse(it.Ma!.Substring(2)))
                .ToList();

            return PartialView("_DanhSachThuocTinhMauSacPartialView", lstMauSac);
        }

        public IActionResult LoadPartialViewDanhSachRom()
        {
            var lstRom = _context
                .Roms
                .AsNoTracking()
                .Select(it => new ThuocTinhViewModel()
                {
                    Id = it.IdRom,
                    Ma = it.MaRom,
                    Ten = it.DungLuong.ToString(),
                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdRom == it.IdRom).Count(),
                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                })
                .AsEnumerable()
                .OrderBy(it => int.Parse(it.Ma!.Substring(2)))
                .ToList();

            return PartialView("_DanhSachThuocTinhRomPartialView", lstRom);
        }
        public IActionResult LoadPartialViewDanhSachRam()
        {
            var lstRam = _context
                .Rams
                .AsNoTracking()
                .Select(it => new ThuocTinhViewModel()
                {
                    Id = it.IdRam,
                    Ma = it.MaRam,
                    Ten = it.DungLuong.ToString(),
                    SoBienTheDangDung = _context.SanPhamChiTiets.Where(sp => sp.IdRam == it.IdRam).Count(),
                    TrangThai = it.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                })
                .AsEnumerable()
                .OrderBy(it => int.Parse(it.Ma!.Substring(2)))
                .ToList();

            return PartialView("_DanhSachThuocTinhRamPartialView", lstRam);
        }

        public IActionResult DanhSachThuocTinhSanPham()
        {
            return View();
        }


        #region ThaoTac
        //Xoa San Pham
        public async Task<IActionResult> DeleteSanPham(string idSanPham)
        {
            var response = await _httpClient.DeleteAsync($"/api/SanPham/XoaSanPham={idSanPham}");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> EditSanPham([FromBody]SanPhamDTO sanPham)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/SanPham/SuaSanPham",sanPham);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        public async Task<IActionResult> DeleteHang(string idHang)
        {
            var response = await _httpClient.DeleteAsync($"/api/Hang/{idHang}");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> EditHang([FromBody] HangDTO hang)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/hang/sua-hang", hang);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        public async Task<IActionResult> DeleteRam(string idRam)
        {
            var response = await _httpClient.DeleteAsync($"/api/Ram/Delete?idRam={idRam}");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> EditRam([FromBody] RamDTO ram)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/ram/sua-ram", ram);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        public async Task<IActionResult> DeleteRom(string idRom)
        {
            var response = await _httpClient.DeleteAsync($"/api/Rom/XoaRom={idRom}");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> EditRom([FromBody] RomDTO romDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/rom/sua-rom", romDTO);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        public async Task<IActionResult> DeleteCongSac(string idCongSac)
        {
            var response = await _httpClient.DeleteAsync($"/api/CongSac/DeleteCongSac/{idCongSac}");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> EditCongSac([FromBody] CongSacDTO congSacDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/congSac/sua-cong-sac", congSacDTO);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        public async Task<IActionResult> DeleteChip(string idChip)
        {
            var response = await _httpClient.DeleteAsync($"/api/Chip/XoaChip/{idChip}");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> EditChip([FromBody] ChipDTO chipDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/chip/sua-chat-lieu", chipDTO);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        public async Task<IActionResult> DeleteMauSac(string idMauSac)
        {
            var response = await _httpClient.DeleteAsync($"/api/MauSac/DeleteMauSac/{idMauSac}");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> EditMauSac([FromBody] MauSacDTO mauSacDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/mausac/sua-mau-sac", mauSacDTO);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        public async Task<IActionResult> DeleteManHinh(string idManHinh)
        {
            var response = await _httpClient.DeleteAsync($"/api/ManHinh/{idManHinh}");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> EditManHinh([FromBody] ManHinhDTO ManHinhDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/manHinh/sua-man-hinh", ManHinhDTO);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        public async Task<IActionResult> DeleteTheNho(string idTheNho)
        {
            var response = await _httpClient.DeleteAsync($"/api/TheNho/{idTheNho}");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> EditTheNho([FromBody] TheNhoDTO TheNhoDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/theNho/sua-the-nho", TheNhoDTO);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        public async Task<IActionResult> DeletePin(string idPin)
        {
            var response = await _httpClient.DeleteAsync($"/api/Pin/{idPin}");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> EditPin([FromBody] PinDTO pinDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/pin/sua-pin", pinDTO);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsAsync<bool>());
            }
            return Ok(false);
        }
        #endregion
    }
}
