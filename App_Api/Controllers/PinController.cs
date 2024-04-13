using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
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
        AppDbContext Context = new AppDbContext();
        DbSet<Pin> Pins;
        public PinController()
        {
            Pins = Context.Pins;
            AllRepo<Pin> all = new AllRepo<Pin>(Context, Pins);
            repos = all;
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
        public bool AddPin(string maPin, string loaiPin, string dungLuong, int trangThai)
        {
            var pin = new Pin
            {
                IdPin = Guid.NewGuid().ToString(),
                MaPin = maPin,
                LoaiPin = loaiPin,
                DungLuong = dungLuong,
                TrangThai = trangThai
            };

            return repos.AddItem(pin);
        }
        [HttpPut("SuaPin/{id}")]
        public async Task<IActionResult> EditPin(string id, string maPin, string loaiPin, string dungLuong, int trangThai)
        {
            var pin = repos.GetAll().FirstOrDefault(p => p.IdPin == id);
            if (pin == null)
            {
                return NotFound("Không tìm thấy Pin cần sửa.");
            }

            pin.MaPin = maPin;
            pin.LoaiPin = loaiPin;
            pin.DungLuong = dungLuong;
            pin.TrangThai = trangThai;

            if (repos.EditItem(pin))
            {
                return Ok("Đã cập nhật Pin thành công.");
            }
            else
            {
                return BadRequest("Không thể cập nhật Pin.");
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
