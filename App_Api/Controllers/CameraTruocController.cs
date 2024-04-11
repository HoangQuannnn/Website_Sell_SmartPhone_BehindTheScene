using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraTruocController : ControllerBase
    {
        private readonly IAllRepo<CameraTruoc> repos;
        AppDbContext context = new AppDbContext();
        DbSet<CameraTruoc> CameraTruocs;
        private readonly IMapper _mapper;
        public CameraTruocController(IMapper mapper)
        {
            CameraTruocs = context.CameraTruocs;
            AllRepo<CameraTruoc> all = new AllRepo<CameraTruoc>(context, CameraTruocs);
            repos = all;
            _mapper = mapper;
        }
        // GET: api/<CameraTruocController>
        [HttpGet]
        public async Task<IEnumerable<CameraTruoc>> GetAllCameraTruoc()
        {
            var allCameraTruoc = (await CameraTruocs.Include(c => c.SanPhamChiTiet).ThenInclude(c => c.SanPham).ToListAsync()).ToList();
            var allCameraTruoc1 = _mapper.Map<List<CameraTruoc>>(allCameraTruoc);
            return allCameraTruoc1;
        }

        // GET api/<CameraTruocController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CameraTruocController>
        [HttpPost]
        public bool CreateCameraTruoc(string loaiCamera, string ma, string doPhanGiai, int trangThai)
        {
            string MaTS;
            if (repos.GetAll().Count() == null)
            {
                MaTS = "CT1";
            }
            else
            {
                MaTS = "CT" + (repos.GetAll().Count() + 1);
            }
            CameraTruoc b = new CameraTruoc();
            b.IdCameraTruoc = Guid.NewGuid().ToString();
            b.MaCameraTruoc = ma;
            b.DoPhanGiai = doPhanGiai;
            b.LoaiCamera = loaiCamera;
            b.TrangThai = trangThai;
            return repos.AddItem(b);
        }

        // PUT api/<CameraTruocController>/5
        [HttpPut("{id}")]
        public bool EditCameraTruoc(string id, string loaiCamera, string ma, string doPhanGiai, int trangThai)
        {
            var b = repos.GetAll().First(p => p.IdCameraTruoc == id);
            b.MaCameraTruoc = ma;
            b.DoPhanGiai = doPhanGiai;
            b.LoaiCamera = loaiCamera;
            b.TrangThai = trangThai;
            return repos.EditItem(b);
        }

        // DELETE api/<CameraTruocController>/5
        [HttpDelete("{id}")]
        public bool DeleteCameraTruoc(string id)
        {
            var cameraTruoc = repos.GetAll().First(p => p.IdCameraTruoc == id);
            return repos.RemoveItem(cameraTruoc);
        }
    }
}
