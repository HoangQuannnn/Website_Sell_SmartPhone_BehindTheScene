using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.SanPhamChiTiet.SanPhamDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly IAllRepo<SanPham> allRepo;
        AppDbContext dbContext = new AppDbContext();
        DbSet<SanPham> SanPham;
        private readonly IMapper _mapper;
        public SanPhamController(IMapper mapper)
        {
            SanPham = dbContext.SanPhams;
            AllRepo<SanPham> all = new AllRepo<SanPham>(dbContext, SanPham);
            allRepo = all;
            _mapper = mapper;
        }
        // GET: api/<SanPhamController>
        [HttpGet]
        public IEnumerable<SanPham> ShowAllKieuGiay()
        {
            return allRepo.GetAll();
        }

        // GET api/<SanPhamController>/5
        [HttpGet("TimSanPham={id}")]
        public SanPham GetSanPhamByID(string id)
        {
            return allRepo.GetAll().FirstOrDefault(c => c.IdSanPham == id);
        }

        // POST api/<SanPhamController>
        [HttpPost]
        public bool AddSanPham(SanPhamDTO sanPhamDTO)
        {
            string ma;
            if (allRepo.GetAll().Count() == null)
            {
                ma = "SP1";
            }
            else
            {
                ma = "SP" + (allRepo.GetAll().Count() + 1);
            }
            var SanPham = new SanPham()
            {
                IdSanPham = Guid.NewGuid().ToString(),
                MaSanPham = ma,
                TenSanPham = sanPhamDTO.TenSanPham,
                Trangthai = sanPhamDTO.TrangThai
            };
            return allRepo.AddItem(SanPham);
        }

        [HttpPut("SuaSanPham")]
        public bool SuaSanPham(SanPhamDTO sanPhamDTO)
        {
            var sanpham = allRepo.GetAll().First(p => p.IdSanPham == sanPhamDTO.IdSanPham);
            sanpham.TenSanPham = sanPhamDTO.TenSanPham;
            sanpham.Trangthai = sanPhamDTO.TrangThai;
            return allRepo.EditItem(sanpham);
        }

        // DELETE api/<SanPhamController>/5
        [HttpDelete("XoaSanPham={id}")]
        public bool XoaSanPham(string id)
        {
            var SanPham = allRepo.GetAll().FirstOrDefault(c => c.IdSanPham == id);
            return allRepo.RemoveItem(SanPham);
        }
    }
}
