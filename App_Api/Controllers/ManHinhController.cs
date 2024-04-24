using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.ManHinhDTO;
using App_Data.ViewModels.TheSimDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManHinhController : ControllerBase
    {
        private readonly IAllRepo<ManHinh> _mhRepos;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        public ManHinhController(IAllRepo<ManHinh> manHinhrepos, IMapper mapper)
        {
            _mhRepos = manHinhrepos;
            _mapper = mapper;
            _dbContext = new AppDbContext();
        }

        // GET: api/<ManHinhController>
        [HttpGet]
        public List<ManHinh> GetAll()
        {
            return _mhRepos.GetAll().ToList();
        }

        // GET api/<ManHinhController>/5
        [HttpGet("{id}")]
        public ManHinh? GetManHinh(string id)
        {
            return _mhRepos.GetAll().FirstOrDefault(x => x.IdManHinh == id);
        }

        // POST api/<ManHinhController>
        [HttpPost]
        public bool Create(ManHinhDTO manHinhDTO)
        {
            string MaTS;
            if (_mhRepos.GetAll().Count() == 0)
            {
                MaTS = "MH1";
            }
            else
            {
                MaTS = "MH" + (_mhRepos.GetAll().Count() + 1);
            }
            ManHinh manhinh = new ManHinh();
            manhinh.IdManHinh = Guid.NewGuid().ToString();
            manhinh.MaManHinh = MaTS;
            manhinh.LoaiManHinh = manHinhDTO.LoaiManHinh;
            manhinh.KichThuoc = manHinhDTO.KichThuoc;
            manhinh.TanSoQuet = manHinhDTO.TanSoQuet;
            manhinh.TrangThai = manHinhDTO.TrangThai;
            return _mhRepos.AddItem(manhinh);
        }

        // PUT api/<ManHinhController>/5
        [HttpPut]
        public bool Edit(ManHinhDTO manHinhDTO)
        {
            var manhinh = _mhRepos.GetAll().First(p => p.IdManHinh == manHinhDTO.IdManHinh);
            manhinh.LoaiManHinh = manHinhDTO.LoaiManHinh;
            manhinh.KichThuoc = manHinhDTO.KichThuoc;
            manhinh.TanSoQuet = manHinhDTO.TanSoQuet;
            manhinh.TrangThai = manHinhDTO.TrangThai;
            return _mhRepos.EditItem(manhinh);
        }

        // DELETE api/<ManHinhController>/5
        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            var manHinh = GetManHinh(id);
            if (manHinh != null)
            {
                manHinh!.TrangThai = 1;
                return _mhRepos.RemoveItem(manHinh);
            }
            return false;
        }
    }
}
