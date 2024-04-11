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
        public bool AddHang(string ten, int trangthai)
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
                TenHang = ten,
                TrangThai = trangthai
            };
            return allRepo.AddItem(Hang);
        }

        [HttpPut("sua-hang")]
        public bool SuaChatLieu(HangDTO hangDTO)
        {
            try
            {
                var nameHang = hangDTO.TenHang!.Trim().ToLower();
                if (!dbContext.Hangs.Where(x => x.TenHang!.Trim().ToLower() == nameHang).Any())
                {
                    var Hang = _mapper.Map<Hang>(hangDTO);
                    dbContext.Attach(Hang);
                    dbContext.Entry(Hang).Property(sp => sp.TenHang).IsModified = true;
                    dbContext.SaveChanges();
                    return true;
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
