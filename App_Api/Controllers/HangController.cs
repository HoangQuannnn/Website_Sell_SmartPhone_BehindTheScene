using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.HangDTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangController : ControllerBase
    {
        private readonly IAllRepo<Hang> allRepo;
        AppDbContext dbContext = new AppDbContext();
        private readonly IMapper _mapper;
        DbSet<Hang> Hang;
        public HangController(IMapper mapper)
        {
            Hang = dbContext.Hangs;
            AllRepo<Hang> all = new AllRepo<Hang>(dbContext, Hang);
            allRepo = all;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Hang> GetAllHang()
        {
            return allRepo.GetAll();
        }

        [HttpGet("{id}")]
        public Hang GetHangById(string id)
        {
            return allRepo.GetAll().FirstOrDefault(c => c.IdHang == id);
        }
        [HttpPost]
        public bool AddHang(CreateHangDTO createHangDTO)
        {
            string ma;
            if (allRepo.GetAll().Count() == null)
            {
                ma = "H1";
            }
            else
            {
                ma = "H" + (allRepo.GetAll().Count() + 1);
            }
            var Hang = new Hang()
            {
                IdHang = Guid.NewGuid().ToString(),
                MaHang = ma,
                TenHang = createHangDTO.tenHang,
                TrangThai = createHangDTO.trangThai
            };
            return allRepo.AddItem(Hang);
        }

        [HttpPut("sua-hang")]
        public bool UpdateHang(HangDTO hangDTO)
        {
            try
            {
                if (hangDTO != null && !string.IsNullOrEmpty(hangDTO.IdHang) && !string.IsNullOrEmpty(hangDTO.TenHang))
                {
                    var existingHang = dbContext.Hangs.FirstOrDefault(x => x.IdHang == hangDTO.IdHang);
                    if (existingHang != null)
                    {
                        existingHang.TenHang = hangDTO.TenHang;
                        existingHang.TrangThai = hangDTO.trangThai;
                        dbContext.Hangs.Update(existingHang);
                        dbContext.SaveChanges();

                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpDelete("XoaHang/{id}")]
        public bool Delete(string id)
        {
            var cl = allRepo.GetAll().FirstOrDefault(c => c.IdHang == id);
            return allRepo.RemoveItem(cl);
        }
    }
}
