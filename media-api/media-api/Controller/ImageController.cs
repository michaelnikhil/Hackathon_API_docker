using Microsoft.AspNetCore.Mvc;
using media_api.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using media_api.Model;

namespace media_api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
 
        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        
        [HttpGet]
        public  ActionResult GetResult()
        {
            //var images = await _imageRepository.Get();
            return Ok("test");
        }

        [HttpGet]
        [Route("catalog")]
        public async Task<ActionResult<IEnumerable<Image>>> Get()
        {
            string test = "test";
            //var images = await _imageRepository.Get();
            var images = _imageRepository.GetImage(); 
            return Ok();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Image>> Get(string id)
        //{
        //    var image = await _imageRepository.Get(id);
        //    return Ok(image);
        //}
    }
}