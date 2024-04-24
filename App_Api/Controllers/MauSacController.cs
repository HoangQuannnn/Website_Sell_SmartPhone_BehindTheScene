using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.MauSac;
using App_Data.ViewModels.SanPhamChiTiet.SanPhamDTO;
using App_Data.ViewModels.TheSimDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MauSacController : ControllerBase
    {
        private readonly IAllRepo<MauSac> _mauSacRespo;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appContext;

        public MauSacController(IAllRepo<MauSac> mauSacRespo, IMapper mapper)
        {
            _mauSacRespo = mauSacRespo;
            _mapper = mapper;
            _appContext = new AppDbContext();
        }


        [HttpGet("GetMauSac/{id}")]
        public MauSac? GetMauSac(string id)
        {
            return _mauSacRespo.GetAll().FirstOrDefault(x => x.IdMauSac == id);
        }


        [HttpGet("GetAllMauSac")]
        public List<MauSac> GetListMauSac()
        {
            return _mauSacRespo.GetAll().Where(x => x.TrangThai == 0).ToList();
        }

        [HttpPost("CreateMauSac")]
        public bool Create(MauSacDTO mauSacDTO)
        {
            string ma;
            if (_mauSacRespo.GetAll().Count() == null)
            {
                ma = "MS1";
            }
            else
            {
                ma = "MS" + (_mauSacRespo.GetAll().Count() + 1);
            }
            var MauSac = new MauSac()
            {
                IdMauSac = Guid.NewGuid().ToString(),
                MaMauSac = ma,
                TenMauSac = mauSacDTO.TenMauSac,
                TrangThai = mauSacDTO.TrangThai
            };
            return _mauSacRespo.AddItem(MauSac);
        }

        [HttpDelete("DeleteMauSac/{id}")]
        public bool Delete(string id)
        {
            var mausac = _mauSacRespo.GetAll().FirstOrDefault(c => c.IdMauSac == id);
            return mausac != null && _mauSacRespo.RemoveItem(mausac);
        }

        [HttpPut("sua-mau-sac")]
        public bool Update(MauSacDTO mauSacDTO)
        {
            var mausac = _mauSacRespo.GetAll().First(p => p.IdMauSac == mauSacDTO.IdMauSac);
            mausac.TenMauSac = mauSacDTO.TenMauSac;
            mausac.TrangThai = mauSacDTO.TrangThai;
            return _mauSacRespo.EditItem(mausac);
        }

    }
}
