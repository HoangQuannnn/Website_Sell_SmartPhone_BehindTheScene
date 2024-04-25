using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.RamDTO;
using App_Data.ViewModels.RomDTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RomController : ControllerBase
    {
        private readonly IAllRepo<Rom> allRepo;
        AppDbContext dbContext = new AppDbContext();
        private readonly IMapper _mapper;
        DbSet<Rom> Rom;
        public RomController(IMapper mapper)
        {
            Rom = dbContext.Roms;
            AllRepo<Rom> all = new AllRepo<Rom>(dbContext, Rom);
            allRepo = all;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Rom> GetAllRom()
        {
            return allRepo.GetAll();
        }

        [HttpGet("{id}")]
        public Rom GetRomById(string id)
        {
            return allRepo.GetAll().FirstOrDefault(c => c.IdRom == id);
        }
        [HttpPost]
        public bool AddRom(CreateRomDTO createRomDTO)
        {
            string ma;
            if (allRepo.GetAll().Count() == null)
            {
                ma = "RO1";
            }
            else
            {
                ma = "RO" + (allRepo.GetAll().Count() + 1);
            }
            var Rom = new Rom()
            {
                IdRom = Guid.NewGuid().ToString(),
                MaRom = ma,
                TrangThai = createRomDTO.trangThai,
                DungLuong = createRomDTO.dungLuongRom
            };
            return allRepo.AddItem(Rom);
        }

        [HttpPut("sua-Rom")]
        public bool SuaRom(RomDTO RomDTO)
        {
            try
            {
                if (RomDTO != null && !string.IsNullOrEmpty(RomDTO.IdRom) && !string.IsNullOrEmpty(RomDTO.DungLuong))
                {
                    var existingRam = dbContext.Roms.FirstOrDefault(x => x.IdRom == RomDTO.IdRom);
                    if (existingRam != null)
                    {
                        existingRam.TrangThai = RomDTO.trangThai;
                        existingRam.DungLuong = RomDTO.DungLuong;
                        dbContext.Roms.Update(existingRam);
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

        [HttpDelete("XoaRom/{id}")]
        public bool Delete(string id)
        {
            var cl = allRepo.GetAll().FirstOrDefault(c => c.IdRom == id);
            return allRepo.RemoveItem(cl);
        }
    }
}

