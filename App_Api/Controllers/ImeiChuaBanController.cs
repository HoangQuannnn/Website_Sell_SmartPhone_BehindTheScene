using App_Data.IRepositories;
using App_Data.Models;
using App_Data.ViewModels.ImeiDTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using ZXing;
using App_Data.ViewModels.ImeiChuaBan;
using Microsoft.EntityFrameworkCore;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImeiChuaBanController : ControllerBase
    {
        private readonly IAllRepo<ImeiChuaBan> _imeiChuaBanRespo;
        private readonly IMapper _mapper;
        public ImeiChuaBanController(IAllRepo<ImeiChuaBan> imeiChuaBanRespo, IMapper mapper)
        {
            _imeiChuaBanRespo = imeiChuaBanRespo;
            _mapper = mapper;
        }


        [HttpGet("GetImeiChuaBan/{id}")]
        public ImeiChuaBan? GetImeiChuaBan(string id)
        {
            return _imeiChuaBanRespo.GetAll().FirstOrDefault(x => x.IdImeiChuaBan == id);
        }


        [HttpGet("GetAllImeiChuaBan")]
        public List<ImeiChuaBan> GetListImei()
        {
            return _imeiChuaBanRespo.GetAll().Where(x => x.TrangThai == 0).ToList();
        }



        [HttpPost("CreateImeiChuaBan")]
        public bool Create(ImeiChuaBanDTO imeiChuaBanDTO)
        {
            imeiChuaBanDTO.IdImeiChuaBan = Guid.NewGuid().ToString();
            var imeiChuaBan = _mapper.Map<ImeiChuaBan>(imeiChuaBanDTO);
            imeiChuaBan.TrangThai = 0;
            return _imeiChuaBanRespo.AddItem(imeiChuaBan);
        }

        [HttpDelete("DeleteImeiChuaBan/{id}")]
        public bool Delete(string id)
        {
            try
            {
                var imei = GetImeiChuaBan(id);
                if (imei != null)
                {
                    return _imeiChuaBanRespo.RemoveItem(imei);
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
