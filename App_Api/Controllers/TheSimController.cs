using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.CameraDTO;
using App_Data.ViewModels.TheSimDTO;
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
        public bool CreateTheSim(TheSimDTO theSimDTO)
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
            TheSim thesim = new TheSim();
            thesim.IdTheSim = Guid.NewGuid().ToString();
            thesim.MaTheSim = MaTS;
            thesim.LoaiTheSim1 = theSimDTO.Loaithesim1;
            thesim.LoaiTheSim2 = theSimDTO.Loaithesim2;
            thesim.TrangThai = theSimDTO.TrangThai;
            return repos.AddItem(thesim);
        }

        [HttpPut]
        public bool Edit(TheSimDTO theSimDTO)
        {
            var thesim = repos.GetAll().First(p => p.IdTheSim == theSimDTO.IdTheSim);
            thesim.LoaiTheSim1 = theSimDTO.Loaithesim1;
            thesim.LoaiTheSim2 = theSimDTO.Loaithesim2;
            thesim.TrangThai = theSimDTO.TrangThai;
            return repos.EditItem(thesim);
        }

        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            var theSim = repos.GetAll().FirstOrDefault(c => c.IdTheSim == id);
            return theSim != null && repos.RemoveItem(theSim);
        }
    }
}
