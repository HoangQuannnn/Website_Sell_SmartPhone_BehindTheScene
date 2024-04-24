using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.PinDTO;
using App_Data.ViewModels.TheNhoDTO;
using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheNhoController : ControllerBase
    {
        private readonly IAllRepo<TheNho> _theNhoRepos;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public TheNhoController(IAllRepo<TheNho> theNhoRepos, IMapper mapper)
        {
            _theNhoRepos = theNhoRepos;
            _mapper = mapper;
            _dbContext = new AppDbContext();
        }

        // GET: api/<TheNhoController>
        [HttpGet]
        public List<TheNho> GetAll()
        {
            return _theNhoRepos.GetAll().ToList();
        }

        // GET api/<TheNhoController>/5
        [HttpGet("{id}")]
        public TheNho? GetTheNho(string id)
        {
            return _theNhoRepos.GetAll().FirstOrDefault(x => x.IdTheNho == id);
        }

        // POST api/<TheNhoController>
        [HttpPost]
        public bool Post(TheNhoDTO theNhoDTO)
        {
            theNhoDTO.IdTheNho= Guid.NewGuid().ToString();
            var theNho = _mapper.Map<TheNho>(theNhoDTO);
            theNho.TrangThai = 0;
            theNho.MaTheNho = !_theNhoRepos.GetAll().Any() ? "TN1" : "TN" + (_theNhoRepos.GetAll().Count() + 1);
            return _theNhoRepos.AddItem(theNho);
        }

        // PUT api/<TheNhoController>/5
        [HttpPut]
        public bool Put(TheNhoDTO theNhoDTO)
        {
            try
            {
                if (theNhoDTO != null && !string.IsNullOrEmpty(theNhoDTO.IdTheNho) && !string.IsNullOrEmpty(theNhoDTO.LoaiTheNho))
                {
                    var existingHang = _dbContext.TheNhos.FirstOrDefault(x => x.IdTheNho == theNhoDTO.IdTheNho);
                    if (existingHang != null)
                    {
                        existingHang.LoaiTheNho = theNhoDTO.LoaiTheNho;
                        existingHang.TrangThai = theNhoDTO.TrangThai;
                        existingHang.DungLuong = theNhoDTO.DungLuong;
                        _dbContext.TheNhos.Update(existingHang);
                        _dbContext.SaveChanges();

                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE api/<TheNhoController>/5
        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            var theNho = GetTheNho(id);
            if (theNho != null)
            {
                theNho!.TrangThai = 1;
                return _theNhoRepos.RemoveItem(theNho);
            }
            return false;
        }
    }
}
