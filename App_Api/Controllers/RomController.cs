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
        BazaizaiContext dbContext = new BazaizaiContext();
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
        public bool AddRom(string ten, int trangthai, string dungluong)
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
                TenRom = ten,
                TrangThai = trangthai,
                DungLuong = dungluong
            };
            return allRepo.AddItem(Rom);
        }

        [HttpPut("sua-Rom")]
        public bool SuaChatLieu(RomDTO RomDTO)
        {
            try
            {
                var tenRom = RomDTO.TenRom!.Trim().ToLower();
                var dungLuongRom = RomDTO.DungLuong!.Trim().ToLower();
                if (!dbContext.Roms.Where(x => x.TenRom!.Trim().ToLower() == tenRom && x.DungLuong!.Trim().ToLower() == dungLuongRom).Any())
                {
                    var Rom = _mapper.Map<Rom>(RomDTO);
                    dbContext.Attach(Rom);
                    dbContext.Entry(Rom).Property(sp => sp.TenRom).IsModified = true;
                    dbContext.Entry(Rom).Property(sp => sp.DungLuong).IsModified = true;
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

        [HttpDelete("XoaRom/{id}")]
        public bool Delete(string id)
        {
            var cl = allRepo.GetAll().FirstOrDefault(c => c.IdRom == id);
            return allRepo.RemoveItem(cl);
        }
    }
}

