using App_View.IServices;
using App_Data.Models;
using System.Net.Http.Json;
using App_Data.ViewModels.Anh;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using App_Data.ViewModels.SanPhamChiTiet.SanPhamDTO;
using App_Data.ViewModels.HangDTO;
using App_Data.ViewModels.XuatXu;
using App_Data.ViewModels.RamDTO;
using App_Data.ViewModels.CongSacDTO;
using App_Data.ViewModels.ChiTietCameraDTO;
using App_Data.ViewModels.RomDTO;
using App_Data.ViewModels.MauSac;
using App_Data.ViewModels.SanPhamChiTietViewModel;
using App_Data.ViewModels.SanPhamChiTietDTO;
using static App_View.Areas.Admin.Controllers.SanPhamChiTietController;
using App_Data.ViewModels.ChipDTO;
using App_Data.ViewModels.PinDTO;
using App_Data.ViewModels.TheNhoDTO;
using App_Data.ViewModels.TheSimDTO;
using App_Data.ViewModels.ManHinhDTO;
using App_Data.ViewModels.CameraTruocDTO;
using App_Data.ViewModels.CameraSauDTO;

namespace App_View.Services
{
    public class SanPhamChiTietservice : ISanPhamChiTietservice
    {
        private readonly HttpClient _httpClient;

        public SanPhamChiTietservice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseCreateDTO> AddAysnc(SanPhamChiTietDTO sanPhamChiTietDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Creat-SanPhamChiTiet", sanPhamChiTietDTO);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ResponseCreateDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }
        public async Task<HangDTO?> CreateTenHangAynsc(HangDTO hangDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-Hang", hangDTO);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<HangDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<RamDTO?> CreateTenRamAynsc(RamDTO ramDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-Ram", ramDTO);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<RamDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<RomDTO?> CreateTenRomAynsc(RomDTO romDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-Rom", romDTO);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<RomDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<List<Hang>> GetListModelHangAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<Hang>?>("/api/SanPhamChiTiet/Get-List-Hang"))!;
        }

        public async Task<List<Ram>> GetListModelRamAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<Ram>?>("/api/SanPhamChiTiet/Get-List-Ram"))!;
        }

        public async Task<List<Rom>> GetListModelRomAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<Rom>?>("/api/SanPhamChiTiet/Get-List-Rom"))!;
        }
        public async Task<ResponseCheckAddOrUpdate> CheckSanPhamAddOrUpdate(SanPhamChiTietDTO sanPhamChiTietDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/check-add-or-update", sanPhamChiTietDTO);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ResponseCheckAddOrUpdate>();
                }
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Not IsSuccessStatusCode");
            }


        }

        public async Task CreateAnhAysnc(string IdChiTietSp, List<IFormFile> lstIFormFile)
        {
            try
            {
                using var content = new MultipartFormDataContent();
                content.Add(new StringContent(IdChiTietSp.ToString()), "idProductDetail");

                foreach (var file in lstIFormFile)
                {
                    var streamContent = new StreamContent(file.OpenReadStream());
                    content.Add(streamContent, "lstIFormFile", file.FileName);
                }

                var response = await _httpClient.PostAsync("/api/Anh/create-list-image", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Delete successful. Response: " + responseContent);
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Delete failed. Response: " + responseContent);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace); ;
            }
        }

        public async Task<RamDTO?> CreateTenChatLieuAynsc(RamDTO ram)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-Ram", ram);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<RamDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<RomDTO?> CreateTenKichCoAynsc(RomDTO Rom)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-Rom", Rom);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<RomDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<ChiTietCameraDTO?> CreateTenKieuDeGiayAynsc(ChiTietCameraDTO ChiTietCamera)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-ChiTietCamera", ChiTietCamera);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ChiTietCameraDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<CongSacDTO?> CreateTenLoaiGiayAynsc(CongSacDTO CongSac)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-CongSac", CongSac);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<CongSacDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }
        //mausac
        public async Task<MauSacDTO?> CreateTenMauSacAynsc(MauSacDTO mauSac)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-MauSac", mauSac);
            try
            { 
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<MauSacDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<SanPhamDTO?> CreateTenSanPhamAynsc(SanPhamDTO sanPham)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-SanPham", sanPham);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<SanPhamDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<HangDTO?> CreateTenThuongHieuAynsc(HangDTO hang)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-Hang", hang);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<HangDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<XuatXuDTO?> CreateTenXuatXuAynsc(XuatXuDTO xuatXu)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-XuatXu", xuatXu);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<XuatXuDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task DeleteAnhAysnc(ImageDTO responseImageDeleteVM)
        {
            try
            {
                var deleteUrl = "/api/Anh/delete-list-image";
                var content = new StringContent(JsonConvert.SerializeObject(responseImageDeleteVM), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Delete, deleteUrl);
                request.Content = content;

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    Console.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public async Task<bool> DeleteAysnc(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/SanPhamChiTiet/Delete-SanPhamChiTiet/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<bool>();
                }
                throw new Exception("Not IsSuccessStatusCode");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<SanPhamChiTiet?> GetByKeyAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<SanPhamChiTiet?>($"/api/SanPhamChiTiet/Get-SanPhamChiTiet/{id}");
        }

        public async Task<List<SanPhamDanhSachViewModel>> GetDanhSachDienThoaiNgungKinhDoanhAynsc()
        {
            return (await _httpClient.GetFromJsonAsync<List<SanPhamDanhSachViewModel>>("/api/SanPhamChiTiet/Get-List-SanPhamNgungKinhDoanhViewModel"))!;
        }

        public Task<DanhSachDienThoaiViewModel?> GetDanhSachDienThoaiViewModelAynsc()
        {
            return _httpClient.GetFromJsonAsync<DanhSachDienThoaiViewModel?>("/api/SanPhamChiTiet/Get-DanhSachDienThoaiViewModel");
        }

        public async Task<ItemDetailViewModel?> GetItemDetailViewModelAynsc(string id)
        {
            return await _httpClient.GetFromJsonAsync<ItemDetailViewModel?>($"/api/SanPhamChiTiet/Get-ItemDetailViewModel/{id}");
        }

        public Task<ItemDetailViewModel?> GetItemDetailViewModelWhenSelectColorAynsc(string id, string mauSac)
        {
            return _httpClient.GetFromJsonAsync<ItemDetailViewModel?>($"/api/SanPhamChiTiet/Get-ItemDetailViewModel/{id}/{mauSac}");
        }

        public Task<ItemDetailViewModel?> GetItemDetailViewModelWhenSelectSizeAynsc(string id, int size)
        {
            return _httpClient.GetFromJsonAsync<ItemDetailViewModel?>($"/api/SanPhamChiTiet/Get-ItemDetailViewModel/idsanpham/{id}/size/{size}");
        }

        public async Task<List<ItemShopViewModel>?> GetListItemShopViewModelAynsc()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ItemShopViewModel>?>("/api/SanPhamChiTiet/Get-List-ItemShopViewModel");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<ItemShopViewModel>();
            }
        }

        public async Task<List<SanPhamChiTiet>> GetListSanPhamChiTietAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<SanPhamChiTiet>>("/api/SanPhamChiTiet/Get-List-SanPhamChiTiet"))!;
        }

        public async Task<List<SanPhamChiTietDTO>> GetListSanPhamChiTietDTOAsync(ListGuildDTO listGuildDTO)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(listGuildDTO.listGuild), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/SanPhamChiTiet/Get-List-SanPhamChiTietDTO", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<SanPhamChiTietDTO>>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<List<SanPhamDanhSachViewModel>> GetListSanPhamChiTietViewModelAsync()
        {
            try
            {
                return (await _httpClient.GetFromJsonAsync<List<SanPhamDanhSachViewModel>>("/api/SanPhamChiTiet/Get-List-SanPhamChiTietViewModel"))!;
            }
            catch (Exception)
            {
                return new List<SanPhamDanhSachViewModel>();
            }
        }
        public async Task<List<SanPhamDanhSachViewModel>> GetAllListSanPhamChiTietViewModelAsync()
        {
            try
            {
                return (await _httpClient.GetFromJsonAsync<List<SanPhamDanhSachViewModel>>("/api/SanPhamChiTiet/GetAll-List-SanPhamChiTietViewModel"))!;
            }
            catch (Exception)
            {
                return new List<SanPhamDanhSachViewModel>();
            }
        }
        public async Task<SanPhamChiTietViewModel?> GetSanPhamChiTietViewModelByKeyAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<SanPhamChiTietViewModel?>($"/api/SanPhamChiTiet/Get-SanPhamChiTietViewModel/{id}");
        }

        public Task<bool> KhoiPhucKinhDoanhAynsc(string id)
        {
            return _httpClient.GetFromJsonAsync<bool>($"/api/SanPhamChiTiet/khoi-phuc-kinh-doanh/{id}");
        }

        public async Task<bool> KinhDoanhLaiSanPhamAynsc(ListGuildDTO lstGuid)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(lstGuid.listGuild), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync("/api/SanPhamChiTiet/Update-Kinh_Doanh_List_SanPham", content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<bool>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<bool> NgungKinhDoanhSanPhamAynsc(ListGuildDTO lstGuid)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(lstGuid.listGuild), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync("/api/SanPhamChiTiet/Ngung_Kinh_Doanh_List_SanPham", content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<bool>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<bool> UpdateAynsc(SanPhamChiTietDTO sanPhamChiTietDTO)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("/api/SanPhamChiTiet/Update-SanPhamChiTiet", sanPhamChiTietDTO);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<bool>();
                }
                throw new Exception("Not IsSuccessStatusCode");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        public async Task<List<SanPhamChiTietExcelViewModel>> GetListSanPhamExcelAynsc()
        {
            return (await _httpClient.GetFromJsonAsync<List<SanPhamChiTietExcelViewModel>>("/api/SanPhamChiTiet/get_list_SanPhamExcel"))!;
        }

        public async Task<SanPhamChiTietDTO> GetItemExcelAynsc(BienTheDTO bienTheDTO)
        {
            try
            {
                var response = (await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/get-ItemExcel", bienTheDTO))!;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<SanPhamChiTietDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }

        }

        public async Task UpDatSoLuongAynsc(SanPhamSoLuongDTO sanPhamSoLuongDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/SanPhamChiTiet/UpdateSoLuong", sanPhamSoLuongDTO);
            Console.WriteLine("___________________________________________________________________________________________________________________________________");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            Console.WriteLine("___________________________________________________________________________________________________________________________________");

        }

        public async Task<List<ItemShopViewModel>?> GetDanhSachBienTheItemShopViewModelAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ItemShopViewModel>?>("/api/SanPhamChiTiet/Get-List-ItemBienTheShopViewModel");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<ItemShopViewModel>();
            }
        }

        public async Task<List<MauSac>> GetListModelMauSacAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<MauSac>?>("/api/SanPhamChiTiet/Get-List-MauSac"))!;
        }

        public async Task<List<SanPham>> GetListModelSanPhamAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<SanPham>?>("/api/SanPhamChiTiet/Get-List-SanPham"))!;
        }

        public Task<RamDTO?> CreateRamAynsc(RamDTO ramDTO)
        {
            throw new NotImplementedException();
        }

        public Task<CongSacDTO?> CreateCongSacAynsc(CongSacDTO CongsacDOT)
        {
            throw new NotImplementedException();
        }

        public Task<ChiTietCameraDTO?> CreateChitietCameraAynsc(ChiTietCameraDTO ChiTietCameraDTO)
        {
            throw new NotImplementedException();
        }

        public Task<RamDTO?> CreateRomAynsc(RomDTO romDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ChipDTO?> CreateTenChipAynsc(ChipDTO chipDTO)
        {
            throw new NotImplementedException();
        }

        public Task<PinDTO?> CreateLoaiPinAynsc(PinDTO pinDTO)
        {
            throw new NotImplementedException();
        }

        public Task<TheNhoDTO?> CreateTheNhoAynsc(TheNhoDTO theNhoDTO)
        {
            throw new NotImplementedException();
        }

        public Task<TheSimDTO?> CreateTheSimAynsc(TheSimDTO theSimDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ManHinhDTO?> CreateManHinhAynsc(ManHinhDTO manHinhDTO)
        {
            throw new NotImplementedException();
        }

        public Task<CameraTruocDTO?> CreateCameraTruocAynsc(CameraTruocDTO cameraTruocDTO)
        {
            throw new NotImplementedException();
        }

        public Task<CameraSauDTO?> CreateCameraSauAynsc(CameraSauDTO cameraSauDTO)
        {
            throw new NotImplementedException();
        }
        public async Task<List<CongSac>> GetListModelCongSacAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<CongSac>?>("/api/SanPhamChiTiet/Get-List-CongSac"))!;
        }

        public Task<List<ChiTietCamera>> GetListModelChiTietCameraAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Chip>> GetListModelChipAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<Chip>?>("/api/SanPhamChiTiet/Get-List-Chip"))!;
        }

        public async Task<List<Pin>> GetListModelPinAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<Pin>?>("/api/SanPhamChiTiet/Get-List-Pin"))!;
        }

        public async Task<List<TheNho>> GetListModelTheNhoAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<TheNho>?>("/api/SanPhamChiTiet/Get-List-TheNho"))!;
        }

        public Task<List<TheSim>> GetListModelTheSimAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CameraTruoc>> GetListModelCameraTruocAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CameraSau>> GetListModelCameraSauAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ManHinh>> GetListModelManHinhAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<ManHinh>?>("/api/SanPhamChiTiet/Get-List-ManHinh"))!;
        }

        public Task<DanhSachDienThoaiViewModel?> DanhSachDienThoaiViewModel()
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietCamera>> GetListChiTietCamerasModelAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PinDTO?> CreateTenPinAynsc(PinDTO pinDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SanPhamChiTiet/Create-Hang", pinDTO);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PinDTO>();
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Not IsSuccessStatusCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Not IsSuccessStatusCode");
            }
        }

        
    }
}
