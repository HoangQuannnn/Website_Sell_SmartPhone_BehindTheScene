using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.ManHinhDTO;
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
        public bool Post(ManHinhDTO manHinhDTO)
        {
            manHinhDTO.IdManHinh = Guid.NewGuid().ToString();
            var manhinh = _mapper.Map<ManHinh>(manHinhDTO);
            manhinh.TrangThai = 0;
            manhinh.MaManHinh = !_mhRepos.GetAll().Any() ? "MH1" : "MH" + (_mhRepos.GetAll().Count() + 1);
            return _mhRepos.AddItem(manhinh);
        }

        // PUT api/<ManHinhController>/5
        [HttpPut("{id}")]
        public bool Put(ManHinhDTO manHinhDTO)
        {
            try
            {
                var loaiManHinh = manHinhDTO.LoaiManHinh!.Trim().ToLower();
                if (!_dbContext.ManHinhs.Where(x => x.LoaiManHinh!.Trim().ToLower() == loaiManHinh).Any())
                {
                    var manHinh = _mapper.Map<ManHinhDTO>(manHinhDTO);
                    _dbContext.Attach(manHinh);
                    _dbContext.Entry(manHinh).Property(sp => sp.IdManHinh).IsModified = true;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
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
