using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.ChiTietCameraDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietCameraController : ControllerBase
    {
        private readonly IAllRepo<ChiTietCamera> repos;
        AppDbContext context = new AppDbContext();
        DbSet<ChiTietCamera> ChiTietCameras;
        private readonly IMapper _mapper;
        public ChiTietCameraController(IMapper mapper)
        {
            ChiTietCameras = context.ChiTietCameras;
            AllRepo<ChiTietCamera> all = new AllRepo<ChiTietCamera>(context, ChiTietCameras);
            repos = all;
            _mapper = mapper;
        }
        // GET: api/<ChiTietCameraController>
        [HttpGet]
        public async Task<IEnumerable<ChiTietCameraDTO>> GetAllChiTietCamera()
        {
            var allChiTietCamera = (await ChiTietCameras.Include(c => c.Camera).Include(c => c.SanPhamChiTiet).ThenInclude(c => c.SanPham).ToListAsync()).ToList();
            var allChiTietCameraDTO = _mapper.Map<List<ChiTietCameraDTO>>(allChiTietCamera);
            return allChiTietCameraDTO;
        }

        // GET api/<ChiTietCameraController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ChiTietCameraController>
        [HttpPost]
        public bool CreateChiTietCamera(string loaiCamera, string IDCam, string IDSpCt)
        {
            string MaTS;
            if (repos.GetAll().Count() == null)
            {
                MaTS = "CTC1";
            }
            else
            {
                MaTS = "CTC" + (repos.GetAll().Count() + 1);
            }
            ChiTietCamera b = new ChiTietCamera();
            b.IdChiTietCamera = Guid.NewGuid().ToString();
            b.IdCamera = IDCam;
            b.IdSanPhamChiTiet = IDSpCt;
            b.LoaiCamera = loaiCamera;
            return repos.AddItem(b);
        }

        // PUT api/<ChiTietCameraController>/5
        [HttpPut("{id}")]
        public bool EditChiTietCamera(string id, string loaiCamera, string IDCam, string IDSpCt)
        {
            var b = repos.GetAll().First(p => p.IdChiTietCamera == id);
            b.IdCamera = IDCam;
            b.IdSanPhamChiTiet = IDSpCt;
            b.LoaiCamera = loaiCamera;
            return repos.EditItem(b);
        }

        // DELETE api/<ChiTietCameraController>/5
        [HttpDelete("{id}")]
        public bool DeleteChiTietCamera(string id)
        {
            var chiTietCamera = repos.GetAll().First(p => p.IdChiTietCamera == id);
            return repos.RemoveItem(chiTietCamera);
        }
    }
}
