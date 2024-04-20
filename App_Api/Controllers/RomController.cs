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
                TenRom = createRomDTO.tenRom,
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
                // Kiểm tra xem DTO có dữ liệu hợp lệ không
                if (RomDTO != null && !string.IsNullOrEmpty(RomDTO.IdRom) && !string.IsNullOrEmpty(RomDTO.TenRom))
                {
                    // Tìm đối tượng Ram trong cơ sở dữ liệu dựa trên IdRam
                    var existingRam = dbContext.Roms.FirstOrDefault(x => x.IdRom == RomDTO.IdRom);
                    if (existingRam != null)
                    {
                        // Cập nhật thông tin của đối tượng Ram từ DTO
                        existingRam.TenRom = RomDTO.TenRom;
                        existingRam.TrangThai = RomDTO.trangThai;
                        existingRam.DungLuong = RomDTO.DungLuong;

                        // Cập nhật đối tượng trong cơ sở dữ liệu và lưu thay đổi
                        dbContext.Roms.Update(existingRam);
                        dbContext.SaveChanges();

                        return true;
                    }
                }

                return false; // Trả về false nếu không tìm thấy đối tượng Ram hoặc dữ liệu không hợp lệ
            }
            catch (Exception)
            {
                return false; // Trả về false nếu có lỗi xảy ra trong quá trình cập nhật
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

