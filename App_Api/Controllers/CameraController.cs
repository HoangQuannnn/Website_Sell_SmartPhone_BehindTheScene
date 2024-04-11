using App_Data.DbContext;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly IAllRepo<Camera> repos;
        AppDbContext context = new AppDbContext();
        DbSet<Camera> Cameras;
        public CameraController()
        {
            Cameras = context.Cameras;
            AllRepo<Camera> all = new AllRepo<Camera>(context, Cameras);
            repos = all;
        }
        // GET: api/<CameraController>
        [HttpGet]
        public IEnumerable<Camera> GetAllCamera()
        {
            return repos.GetAll();
        }

        // GET api/<CameraController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CameraController>
        [HttpPost("Create-Camera")]
        public async Task<IActionResult> CreateCameraAsync(string ma, string doPhanGiai, int trangThai)
        {
            try
            {
                string MaTS;
                if (repos.GetAll().Count() == 0)
                {
                    MaTS = "C1";
                }
                else
                {
                    MaTS = "C" + (repos.GetAll().Count() + 1);
                }
                Camera camera1 = new Camera();
                camera1.IdCamera = Guid.NewGuid().ToString();
                camera1.MaCamera = ma;
                camera1.DoPhanGiai = doPhanGiai;
                camera1.TrangThai = trangThai;
                repos.AddItem(camera1);
                return Ok();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CameraController>/5
        [HttpPut("Edit")]
        public async Task<IActionResult> EditCameraAsync(string id, string ma, string doPhanGiai, int trangThai)
        {
            var camera1 = repos.GetAll().First(p => p.IdCamera == id);
            camera1.MaCamera = ma;
            camera1.TrangThai = trangThai;
            camera1.DoPhanGiai = doPhanGiai;
            repos.EditItem(camera1);
            return Ok();
        }

        // DELETE api/<CameraController>/5
        [HttpDelete("{id}")]
        public bool DeleteCamera(string id)
        {
            var camera = repos.GetAll().First(p => p.IdCamera == id);
            return repos.RemoveItem(camera);
        }
    }
}
