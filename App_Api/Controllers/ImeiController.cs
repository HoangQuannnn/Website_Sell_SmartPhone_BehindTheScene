using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.ViewModels.ImeiDTO;
using AutoMapper;
using ZXing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;
using System.Drawing;
using ZXing.QrCode;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImeiController : ControllerBase
    {
        private readonly IAllRepo<Imei> _imeiRespo;
        private readonly IMapper _mapper;
        public ImeiController(IAllRepo<Imei> imeiRespo, IMapper mapper)
        {
            _imeiRespo = imeiRespo;
            _mapper = mapper;
        }


        [HttpGet("GetImei/{id}")]
        public Imei? GetImei(string id)
        {
            return _imeiRespo.GetAll().FirstOrDefault(x => x.IdImei == id);
        }


        [HttpGet("GetAllImei")]
        public List<Imei> GetListImei()
        {
            return _imeiRespo.GetAll().Where(x => x.TrangThai == 0).ToList();
        }

        [HttpPost("CreateImei")]
        public bool Create(ImeiDTO imeiDTO)
        {
            imeiDTO.IdImei = Guid.NewGuid().ToString();
            var imei = _mapper.Map<Imei>(imeiDTO);
            imei.TrangThai = 0;
            imei.SoImei = GenerateRandomImei();
            imei.MaVach = GenerateBarcode(imei.SoImei);
            return _imeiRespo.AddItem(imei);
        }


        private string GenerateBarcode(string data)
        {
            var barcodeWriter = new BarcodeWriter<Bitmap>()
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 100,
                    Width = 300
                }
            };

            var barcodeBitmap = barcodeWriter.Write(data);

            // Chuyển đổi mã barcode thành chuỗi base64 để lưu trữ hoặc truyền qua API
            var barcodeBase64 = Convert.ToBase64String(BitmapToBytes(barcodeBitmap));

            return barcodeBase64;
        }

        private byte[] BitmapToBytes(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private string GenerateRandomImei()
        {
            // Sử dụng thư viện hoặc hàm để tạo một mã IMEI ngẫu nhiên
            // Ví dụ: Sử dụng chuỗi ngẫu nhiên có độ dài 14 ký tự
            // Lưu ý: Mã IMEI phải tuân thủ theo quy định và chuẩn hóa của GSM Association.
            // Đảm bảo mã IMEI được tạo ra hợp lệ và không trùng lặp.
            var random = new Random();
            const string chars = "0123456789";
            var imei = new string(Enumerable.Repeat(chars, 14)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return imei;
        }

        [HttpDelete("DeleteImei/{id}")]
        public bool Delete(string id)
        {
            try
            {
                var imei = GetImei(id);
                if (imei != null)
                {
                    return _imeiRespo.RemoveItem(imei);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
