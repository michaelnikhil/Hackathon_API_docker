using Microsoft.AspNetCore.Mvc;
using media_api.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using media_api.Model;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;

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
        [Route("catalog")]
        public async Task<ActionResult<IEnumerable<Image>>> Get()
        {
            var images = await _imageRepository.Get();
            return Ok(images);
        }

        [HttpGet("label/{label}")]
        public async Task<ActionResult<Image>> Get(string label)
        {
            Expression<Func<Image, bool>> filter = x => x.Label == label ;
            var image = await _imageRepository.Get(filter);
            return Ok(image);
        }
    }
}