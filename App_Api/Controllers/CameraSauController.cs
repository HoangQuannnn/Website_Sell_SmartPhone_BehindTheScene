//using App_Data.DbContext;
//using App_Data.IRepositories;
//using App_Data.Models;
//using App_Data.Repositories;
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace App_Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CameraSauController : ControllerBase
//    {
//        private readonly IAllRepo<CameraSau> repos;
//        AppDbContext context = new AppDbContext();
//        DbSet<CameraSau> CameraSaus;
//        private readonly IMapper _mapper;
//        public CameraSauController(IMapper mapper)
//        {
//            CameraSaus = context.CameraSaus;
//            AllRepo<CameraSau> all = new AllRepo<CameraSau>(context, CameraSaus);
//            repos = all;
//            _mapper = mapper;
//        }
//        // GET: api/<CameraSauController>
//        [HttpGet]
//        public async Task<IEnumerable<CameraSau>> GetAllCameraSau()
//        {
//            var allCameraSau = (await CameraSaus.Include(c => c.SanPhamChiTiet).ThenInclude(c => c.SanPham).ToListAsync()).ToList();
//            var allCameraSau1 = _mapper.Map<List<CameraSau>>(allCameraSau);
//            return allCameraSau1;
//        }

//        // GET api/<CameraSauController>/5
//        //[HttpGet("{id}")]
//        //public string Get(int id)
//        //{
//        //    return "value";
//        //}

//        // POST api/<CameraSauController>
//        [HttpPost]
//        public bool CreateCameraSau(string loaiCamera, string ma, string doPhanGiai, int trangThai)
//        {
//            string MaTS;
//            if (repos.GetAll().Count() == null)
//            {
//                MaTS = "CS1";
//            }
//            else
//            {
//                MaTS = "CS" + (repos.GetAll().Count() + 1);
//            }
//            CameraSau b = new CameraSau();
//            b.IdCameraSau = Guid.NewGuid().ToString();
//            b.MaCameraSau = ma;
//            b.DoPhanGiai = doPhanGiai;
//            b.LoaiCamera = loaiCamera;
//            b.TrangThai = trangThai;
//            return repos.AddItem(b);
//        }

//        // PUT api/<CameraSauController>/5
//        [HttpPut("{id}")]
//        public bool EditCameraSau(string id, string loaiCamera, string ma, string doPhanGiai, int trangThai)
//        {
//            var b = repos.GetAll().First(p => p.IdCameraSau == id);
//            b.MaCameraSau = ma;
//            b.DoPhanGiai = doPhanGiai;
//            b.LoaiCamera = loaiCamera;
//            b.TrangThai = trangThai;
//            return repos.EditItem(b);
//        }

//        // DELETE api/<CameraSauController>/5
//        [HttpDelete("{id}")]
//        public bool DeleteCameraSau(string id)
//        {
//            var cameraSau = repos.GetAll().First(p => p.IdCameraSau == id);
//            return repos.RemoveItem(cameraSau);
//        }
//    }
//}
