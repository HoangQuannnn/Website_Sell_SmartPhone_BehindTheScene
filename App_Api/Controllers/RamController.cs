using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.HangDTO;
using App_Data.ViewModels.RamDTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        private readonly IAllRepo<Ram> allRepo;
        AppDbContext dbContext = new AppDbContext();
        private readonly IMapper _mapper;
        DbSet<Ram> Ram;
        public RamController(IMapper mapper)
        {
            Ram = dbContext.Rams;
            AllRepo<Ram> all = new AllRepo<Ram>(dbContext, Ram);
            allRepo = all;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Ram> GetAllRam()
        {
            return allRepo.GetAll();
        }

        [HttpGet("{id}")]
        public Ram GetRamById(string id)
        {
            return allRepo.GetAll().FirstOrDefault(c => c.IdRam == id);
        }
        [HttpPost]
        public bool AddRam(string ten, int trangthai, string dungluong)
        {
            string ma;
            if (allRepo.GetAll().Count() == null)
            {
                ma = "R1";
            }
            else
            {
                ma = "R" + (allRepo.GetAll().Count() + 1);
            }
            var Ram = new Ram()
            {
                IdRam = Guid.NewGuid().ToString(),
                MaRam = ma,
                TenRam = ten,
                TrangThai = trangthai,
                DungLuong = dungluong
            };
            return allRepo.AddItem(Ram);
        }

        [HttpPut("sua-Ram")]
        public bool SuaChatLieu(RamDTO RamDTO)
        {
            try
            {
                var tenRam = RamDTO.TenRam!.Trim().ToLower();
                var dungLuongRam = RamDTO.DungLuong!.Trim().ToLower();
                if (!dbContext.Rams.Where(x => x.TenRam!.Trim().ToLower() == tenRam && x.DungLuong!.Trim().ToLower() == dungLuongRam).Any())
                {
                    var Ram = _mapper.Map<Ram>(RamDTO);
                    dbContext.Attach(Ram);
                    dbContext.Entry(Ram).Property(sp => sp.TenRam).IsModified = true;
                    dbContext.Entry(Ram).Property(sp => sp.DungLuong).IsModified = true;
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

        [HttpDelete("XoaRam/{id}")]
        public bool Delete(string id)
        {
            var cl = allRepo.GetAll().FirstOrDefault(c => c.IdRam == id);
            return allRepo.RemoveItem(cl);
        }
    }
}

