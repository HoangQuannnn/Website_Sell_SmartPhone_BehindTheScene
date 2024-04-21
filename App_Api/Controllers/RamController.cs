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
        public bool AddRam([FromBody] CreateRamDTO createRamDTO)
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
                TenRam = createRamDTO.tenRam,
                DungLuong = createRamDTO.dungLuongRam,
                TrangThai = createRamDTO.trangThai
            };
            return allRepo.AddItem(Ram);
        }

        [HttpPut("sua-Ram")]
        public bool SuaRam([FromBody] RamDTO ramDTO)
        {
            try
            {
                if (ramDTO != null && !string.IsNullOrEmpty(ramDTO.IdRam) && !string.IsNullOrEmpty(ramDTO.TenRam))
                {
                    var existingRam = dbContext.Rams.FirstOrDefault(x => x.IdRam == ramDTO.IdRam);
                    if (existingRam != null)
                    {
                        existingRam.TenRam = ramDTO.TenRam;
                        existingRam.TrangThai = ramDTO.trangThai;
                        existingRam.DungLuong = ramDTO.DungLuong;
                        dbContext.Rams.Update(existingRam);
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

        [HttpDelete("XoaRam/{id}")]
        public bool Delete(string id)
        {
            var cl = allRepo.GetAll().FirstOrDefault(c => c.IdRam == id);
            return allRepo.RemoveItem(cl);
        }
    }
}

