using App_Data.IRepositories;
using App_Data.Models;
using App_Data.ViewModels.ImeiChuaBan;
using App_Data.ViewModels.ImeiDaBanDTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImeiDaBanController : ControllerBase
    {
        private readonly IAllRepo<ImeiDaBan> _imeiDaBanRespo;
        private readonly IMapper _mapper;
        public ImeiDaBanController(IAllRepo<ImeiDaBan> imeiDaBanRespo, IMapper mapper)
        {
            _imeiDaBanRespo = imeiDaBanRespo;
            _mapper = mapper;
        }


        [HttpGet("GetImeiDaBan/{id}")]
        public ImeiDaBan? GetImeiDaBan(string id)
        {
            return _imeiDaBanRespo.GetAll().FirstOrDefault(x => x.IdImeiDaBan == id);
        }


        [HttpGet("GetAllImeiDaBan")]
        public List<ImeiDaBan> GetListImei()
        {
            return _imeiDaBanRespo.GetAll().Where(x => x.TrangThai == 0).ToList();
        }



        [HttpPost("CreateImeiDaBan")]
        public bool Create(ImeiDaBanDTO imeiDaBanDTO)
        {
            imeiDaBanDTO.IdImeiDaBan = Guid.NewGuid().ToString();
            var imeiDaBan = _mapper.Map<ImeiDaBan>(imeiDaBanDTO);
            imeiDaBan.TrangThai = 0;
            return _imeiDaBanRespo.AddItem(imeiDaBan);
        }

        [HttpDelete("DeleteImeiDaBan/{id}")]
        public bool Delete(string id)
        {
            try
            {
                var imei = GetImeiDaBan(id);
                if (imei != null)
                {
                    return _imeiDaBanRespo.RemoveItem(imei);
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
