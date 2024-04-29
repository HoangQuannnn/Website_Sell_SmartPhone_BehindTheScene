using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.CameraTruocDTO;

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


        public CameraTruocController()
        {
            CameraTruocs = context.CameraTruocs;
            AllRepo<CameraTruoc> all = new AllRepo<CameraTruoc>(context, CameraTruocs);
            repos = all;

        }
        // GET: api/<CameraTruocController>
        [HttpGet]
        public IEnumerable<CameraTruoc> GetAllCameraTruoc()
        {

            return repos.GetAll();
        }

        //GET api/<CameraTruocController>/5
        [HttpGet("{id}")]
        public CameraTruoc GetCameraTruocById(string id)
        {
            return repos.GetAll().FirstOrDefault(c => c.IdCameraTruoc == id);
        }

        // POST api/<CameraTruocController>
        [HttpPost("Create-CameraTruoc")]
        public bool CreateCameraTruoc(CameraTruocDTO cameraTruocDTO)
        {
            string MaTS;
            if (repos.GetAll().Count() == 0)
            {
                MaTS = "CT1";
            }
            else
            {
                MaTS = "CT" + (repos.GetAll().Count() + 1);
            }
            CameraTruoc cameraTruoc = new CameraTruoc();
            cameraTruoc.IdCameraTruoc = Guid.NewGuid().ToString();
            cameraTruoc.MaCameraTruoc = MaTS;
            cameraTruoc.DoPhanGiaiCamera1 = cameraTruocDTO.DoPhanGiaiCamera1;
            cameraTruoc.DoPhanGiaiCamera2 = cameraTruocDTO.DoPhanGiaiCamera2;
            
            cameraTruoc.TrangThai = cameraTruocDTO.TrangThai;
            return repos.AddItem(cameraTruoc);
        }

        // PUT api/<CameraTruocController>/5
        [HttpPut]
        public bool EditCameraTruoc(CameraTruocDTO cameraTruocDTO)
        {
            var cameraTruoc = repos.GetAll().First(p => p.IdCameraTruoc == cameraTruocDTO.IdCameraTruoc);
            cameraTruoc.DoPhanGiaiCamera1 = cameraTruocDTO.DoPhanGiaiCamera1;
            cameraTruoc.DoPhanGiaiCamera2 = cameraTruocDTO.DoPhanGiaiCamera2;
            
            cameraTruoc.TrangThai = cameraTruocDTO.TrangThai;
            return repos.EditItem(cameraTruoc);
        }

        // DELETE api/<CameraTruocController>/5
        [HttpDelete("{id}")]
        public bool DeleteCameraTruoc(string id)
        {
            var cameraTruoc = repos.GetAll().FirstOrDefault(p => p.IdCameraTruoc == id);
            return cameraTruoc != null && repos.RemoveItem(cameraTruoc);
        }
    }
}
