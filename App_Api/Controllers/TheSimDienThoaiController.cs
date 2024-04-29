//using App_Data.DbContext;
//using App_Data.IRepositories;
//using App_Data.Models;
//using App_Data.Repositories;
//using App_Data.ViewModels.ChiTietCameraDTO;
//using App_Data.ViewModels.TheSimDienThoaiDTO;
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace App_Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TheSimDienThoaiController : ControllerBase
//    {
//        private readonly IAllRepo<TheSimDienThoai> repos;
//        AppDbContext context = new AppDbContext();
//        DbSet<TheSimDienThoai> TheSimDienThoais;
//        private readonly IMapper _mapper;

//        public TheSimDienThoaiController(IMapper mapper)
//        {
//            TheSimDienThoais = context.TheSimDienThoais;
//            AllRepo<TheSimDienThoai> all = new AllRepo<TheSimDienThoai>(context,TheSimDienThoais);
//            repos = all;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<TheSimDienThoaiDTO>> GetAllTheSimDienThoai()
//        {
//            var allthesimdienthoai = (await TheSimDienThoais.Include(c => c.Thesim).Include(c => c.SanPhamChiTiet).ThenInclude(c => c.SanPham).ToListAsync()).ToList();
//            var allthesimdienthoaiDTO = _mapper.Map<List<TheSimDienThoaiDTO>>(allthesimdienthoai);
//            return allthesimdienthoaiDTO;
//        }

//        [HttpGet("{id}")]
//        public TheSimDienThoai GetTheSimDienThoaiById(string id)
//        {
//            return repos.GetAll().FirstOrDefault(c => c.IdTheSimDienThoai == id);
//        }

//        [HttpPost]
//        public bool AddTheSimDienThoai(string idTheSimdt, string idSanPhamChiTiet)
//        {
//            string MaTSdt;
//            if (repos.GetAll().Count() == null)
//            {
//                MaTSdt = "Mtsdt1";
//            }
//            else
//            {
//                MaTSdt = "Mtsdt" + (repos.GetAll().Count() + 1);
//            }
//            var theSimDienThoai = new TheSimDienThoai
//            {
//                IdTheSimDienThoai = Guid.NewGuid().ToString(),
//                IdTheSim = idTheSimdt,
//                IdSanPhamChiTiet = idSanPhamChiTiet
//            };

//            return repos.AddItem(theSimDienThoai);
//        }
//        [HttpPut("{id}")]

//        public bool EditTheSimDienThoai(string idTheSimdt, string idSanPhamChiTiet)
//        {
//            var b = repos.GetAll().First(p=>p.IdTheSimDienThoai==idTheSimdt);
//            b.IdTheSimDienThoai = idTheSimdt;
//            b.IdSanPhamChiTiet = idSanPhamChiTiet;
//            return repos.EditItem(b);

//        }




//            [HttpDelete("XoaTheSimDienThoai/{id}")]
//        public bool Delete(string id)
//        {
//            var theSimDienThoai = repos.GetAll().FirstOrDefault(c => c.IdTheSimDienThoai == id);
//            return theSimDienThoai != null && repos.RemoveItem(theSimDienThoai);
//        }
//    }
//}
