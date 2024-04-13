using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheSimController : ControllerBase
    {
        private readonly IAllRepo<TheSim> repos;

        AppDbContext context = new AppDbContext();
        DbSet<TheSim> Thesims;

        public TheSimController()
        {
            Thesims = context.TheSims;
            AllRepo<TheSim> all = new AllRepo<TheSim>(context, Thesims);
            repos = all;

        }

        [HttpGet]
        public IEnumerable<TheSim> GetAllTheSim()
        {
            return repos.GetAll();
        }

        [HttpGet("{id}")]
        public TheSim GetTheSimById(string id)
        {
            return repos.GetAll().FirstOrDefault(c => c.IdTheSim == id);
        }

        [HttpPost("Create-TheSim")]
        public async Task<IActionResult> CreateTheSim(string ma, int Loaithesim, int SoKhaySim , int TrangThai)
        {
            try
            {
                string MaTS;
                if (repos.GetAll().Count() == 0)
                {
                    MaTS = "TS1";
                }
                else
                {
                    MaTS = "TS" + (repos.GetAll().Count() + 1);
                }
                
                TheSim theSim1 = new TheSim();
                theSim1.IdTheSim = Guid.NewGuid().ToString();
                theSim1.Loaithesim = Loaithesim;
                theSim1.SoKhaySim = SoKhaySim;
                theSim1.TrangThai = TrangThai;
                repos.AddItem(theSim1 );
                return Ok();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("sua-TheSim")]
        public async Task<IActionResult> EditTheSim(string ma, int Loaithesim, int SoKhaySim, int TrangThai)
        {
           var thesim1 = repos.GetAll().First(p=>p.IdTheSim == ma);
            thesim1.IdTheSim = ma;
            thesim1.Loaithesim = Loaithesim;
            thesim1.SoKhaySim=SoKhaySim;
            thesim1.TrangThai= TrangThai;
            repos.EditItem(thesim1 );
            return Ok();
            
        }

        [HttpDelete("XoaTheSim/{id}")]
        public bool Delete(string id)
        {
            var theSim = repos.GetAll().FirstOrDefault(c => c.IdTheSim == id);
            return theSim != null && repos.RemoveItem(theSim);
        }
    }
}
