using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.ChipDTO;
using App_Data.ViewModels.CongSacDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongSacController : ControllerBase
    {
        private readonly IAllRepo<CongSac> _congSacRepos;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbcontext;

        public CongSacController(IAllRepo<CongSac> congSacRepos, IMapper mapper)
        {
            _congSacRepos = congSacRepos;
            _mapper = mapper;
            _dbcontext = new AppDbContext();
        }

        // GET: api/<CongSacController>
        [HttpGet]
        public List<CongSac> GetAll()
        {
            return _congSacRepos.GetAll().ToList();
        }

        // GET api/<CongSacController>/5
        [HttpGet("{id}")]
        public CongSac? GetCongSac(string id)
        {
            return _congSacRepos.GetAll().FirstOrDefault(x => x.IdCongSac == id);
        }

        // POST api/<CongSacController>
        [HttpPost]
        public bool Post(CongSacDTO congSacDTO)
        {
            congSacDTO.IdCongSac = Guid.NewGuid().ToString();
            var congSac = _mapper.Map<CongSac>(congSacDTO);
            congSac.TrangThai = 0;
            congSac.MaCongSac = !_congSacRepos.GetAll().Any() ? "CS1" : "CS" + (_congSacRepos.GetAll().Count() + 1);
            return _congSacRepos.AddItem(congSac);
        }

        // PUT api/<CongSacController>/5
        [HttpPut]
        public bool Put(CongSacDTO congSacDTO)
        {
            var chip = _congSacRepos.GetAll().First(p => p.IdCongSac == congSacDTO.IdCongSac);
            chip.TrangThai = congSacDTO.TrangThai;
            chip.LoaiCongSac = congSacDTO.LoaiCongSac;
            return _congSacRepos.EditItem(chip);
        }

        // DELETE api/<CongSacController>/5
        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            var congSac = GetCongSac(id);
            if (congSac != null)
            {
                congSac!.TrangThai = 1;
                return _congSacRepos.RemoveItem(congSac);
            }
            return false;
        }
    }
}
