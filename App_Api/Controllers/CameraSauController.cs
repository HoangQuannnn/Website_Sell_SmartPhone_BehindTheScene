using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.CameraSauDTO;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraSauController : ControllerBase
    {
        private readonly IAllRepo<CameraSau> repos;

        AppDbContext context = new AppDbContext();
        DbSet<CameraSau> CameraSaus;

        
        public CameraSauController()
        {
            CameraSaus = context.CameraSaus;
            AllRepo<CameraSau> all = new AllRepo<CameraSau>(context, CameraSaus);
            repos = all;
            
        }
        // GET: api/<CameraSauController>
        [HttpGet]
        public IEnumerable<CameraSau> GetAllCameraSau()
        {
            
            return repos.GetAll();
        }

        //GET api/<CameraSauController>/5
        [HttpGet("{id}")]
        public CameraSau GetCameraSauById(string id)
        {
            return repos.GetAll().FirstOrDefault(c => c.IdCameraSau == id);
        }

        // POST api/<CameraSauController>
        [HttpPost("Create-CameraSau")]
        public bool CreateCameraSau(CameraSauDTO cameraSauDTO)
        {
            string MaTS;
            if (repos.GetAll().Count() == 0)
            {
                MaTS = "CS1";
            }
            else
            {
                MaTS = "CS" + (repos.GetAll().Count() + 1);
            }
            CameraSau cameraSau = new CameraSau();
            cameraSau.IdCameraSau = Guid.NewGuid().ToString();
            cameraSau.MaCameraSau = MaTS;
            cameraSau.DoPhanGiaiCamera1 = cameraSauDTO.DoPhanGiaiCamera1;
            cameraSau.DoPhanGiaiCamera2 = cameraSauDTO.DoPhanGiaiCamera2;
            cameraSau.DoPhanGiaiCamera3 = cameraSauDTO.DoPhanGiaiCamera3;
            cameraSau.DoPhanGiaiCamera4 = cameraSauDTO.DoPhanGiaiCamera4;
            cameraSau.DoPhanGiaiCamera5 = cameraSauDTO.DoPhanGiaiCamera5;
            cameraSau.TrangThai = cameraSauDTO.TrangThai;
            return repos.AddItem(cameraSau);
        }

        // PUT api/<CameraSauController>/5
        [HttpPut]
        public bool EditCameraSau(CameraSauDTO cameraSauDTO)
        {
            var cameraSau = repos.GetAll().First(p => p.IdCameraSau == cameraSauDTO.IdCameraSau);
            cameraSau.DoPhanGiaiCamera1 = cameraSauDTO.DoPhanGiaiCamera1;
            cameraSau.DoPhanGiaiCamera2 = cameraSauDTO.DoPhanGiaiCamera2;
            cameraSau.DoPhanGiaiCamera3 = cameraSauDTO.DoPhanGiaiCamera3;
            cameraSau.DoPhanGiaiCamera4 = cameraSauDTO.DoPhanGiaiCamera4;
            cameraSau.DoPhanGiaiCamera5 = cameraSauDTO.DoPhanGiaiCamera5;
            cameraSau.TrangThai = cameraSauDTO.TrangThai;
            return repos.EditItem(cameraSau);
        }

        // DELETE api/<CameraSauController>/5
        [HttpDelete("{id}")]
        public bool DeleteCameraSau(string id)
        {
            var cameraSau = repos.GetAll().FirstOrDefault(p => p.IdCameraSau == id);
            return cameraSau != null && repos.RemoveItem(cameraSau);
        }
    }
}
