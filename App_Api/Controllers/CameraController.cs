//using App_Data.DbContext;
//using App_Data.IRepositories;
//using App_Data.Models;
//using App_Data.Repositories;
//using App_Data.ViewModels.CameraDTO;
//using App_Data.ViewModels.ChipDTO;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;


//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace App_Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CameraController : ControllerBase
//    {
//        private readonly IAllRepo<Camera> repos;
//        AppDbContext context = new AppDbContext();
//        DbSet<Camera> Cameras;
//        public CameraController()
//        {
//            Cameras = context.Cameras;
//            AllRepo<Camera> all = new AllRepo<Camera>(context, Cameras);
//            repos = all;
//        }
//        // GET: api/<CameraController>
//        [HttpGet]
//        public IEnumerable<Camera> GetAllCamera()
//        {
//            return repos.GetAll();
//        }

//        // GET api/<CameraController>/5
//        //[HttpGet("{id}")]
//        //public string Get(int id)
//        //{
//        //    return "value";
//        //}

//        // POST api/<CameraController>
//        [HttpPost("Create-Camera")]
//        public bool CreateCamera(CameraDTO cameraDTO)
//        {
//            string MaTS;
//            if (repos.GetAll().Count() == 0)
//            {
//                MaTS = "CAM1";
//            }
//            else
//            {
//                MaTS = "CAM" + (repos.GetAll().Count() + 1);
//            }
//            Camera camera1 = new Camera();
//            camera1.IdCamera = Guid.NewGuid().ToString();
//            camera1.MaCamera = MaTS;
//            camera1.DoPhanGiai = cameraDTO.DoPhanGiai;
//            camera1.TrangThai = cameraDTO.TrangThai;
//            return repos.AddItem(camera1);
//        }


//        // PUT api/<CameraController>/5
//        [HttpPut]
//        public bool EditCameraAsync(CameraDTO cameraDTO)
//        {
//            var camera1 = repos.GetAll().First(p => p.IdCamera == cameraDTO.IdCamera);
//            camera1.TrangThai = cameraDTO.TrangThai;
//            camera1.DoPhanGiai = cameraDTO.DoPhanGiai;
//            return repos.EditItem(camera1);
//        }

//        // DELETE api/<CameraController>/5
//        [HttpDelete("{id}")]
//        public bool DeleteCamera(string id)
//        {
//            var camera = repos.GetAll().First(p => p.IdCamera == id);
//            return repos.RemoveItem(camera);
//        }
//    }
//}
