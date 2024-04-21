using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.HangDTO;
using App_Data.ViewModels.PinDTO;
using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinController : ControllerBase
    {
        private readonly IAllRepo<Pin> repos;
        private readonly IMapper _mapper;
        AppDbContext Context = new AppDbContext();
        DbSet<Pin> Pins;

        public PinController(IMapper mapper)
        {
            Pins = Context.Pins;
            AllRepo<Pin> all = new AllRepo<Pin>(Context, Pins);
            repos = all;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Pin> GetAllPins()
        {
            return repos.GetAll();
        }

        [HttpGet("{id}")]
        public Pin GetPinById(string id)
        {
            return repos.GetAll().FirstOrDefault(c => c.IdPin == id);
        }

        [HttpPost]
        public bool AddPin(CreatePinDTO createPinDTO)
        {
            string ma;
            if (repos.GetAll().Count() == 0)
            {
                ma = "P1";
            }
            else
            {
                ma = "P" + (repos.GetAll().Count() + 1);
            }

            var pin = new Pin()
            {
                IdPin = Guid.NewGuid().ToString(),
                MaPin = ma,
                LoaiPin = createPinDTO.LoaiPin,
                DungLuong=createPinDTO.DungLuong,
                TrangThai=createPinDTO.trangThai
            };
            

            return repos.AddItem(pin);
        }

        [HttpPut("Sua-pin")]
        public bool UpdatePin(PinDTO pinDTO)
        {
            try
            {
                if (pinDTO != null && !string.IsNullOrEmpty(pinDTO.IdPin) && !string.IsNullOrEmpty(pinDTO.LoaiPin))
                {
                    var existingHang = Context.Pins.FirstOrDefault(x => x.IdPin == pinDTO.IdPin);
                    if (existingHang != null)
                    {
                        existingHang.LoaiPin = pinDTO.LoaiPin;
                        existingHang.TrangThai = pinDTO.trangThai;
                        existingHang.DungLuong = pinDTO.DungLuong;
                        Context.Pins.Update(existingHang);
                        Context.SaveChanges();

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

        [HttpDelete("XoaPin/{id}")]
        public bool Delete(string id)
        {
            var pin = repos.GetAll().FirstOrDefault(c => c.IdPin == id);
            return pin != null && repos.RemoveItem(pin);
        }
    }
}


