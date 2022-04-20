using BLL;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class PhotoController : ControllerBase
    {
        private readonly IPhotoLogic _logic;
        public PhotoController(IPhotoLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("GetAllPhotos")]
        public IActionResult GetAllPhotos()
        {
            return Ok(_logic.GetAllPhotos());
        }
    
        [HttpPost("AddPhotos")]
        public IActionResult Addphotos([FromBody] List<PhotoDto> z)
        {

            return Ok(_logic.AddPhotosrlist(z));
        }
    }
}
