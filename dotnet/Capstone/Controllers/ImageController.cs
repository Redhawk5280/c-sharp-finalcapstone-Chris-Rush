using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Capstone.Models;
using Capstone.DAO;
using Capstone.Exceptions;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private IImageDao imageDao;

        public ImageController(IImageDao imageDao)
        {
            this.imageDao = imageDao;
        }

        [HttpPost]
        public ActionResult UploadImage([FromBody] Image image)
        {
            try
            {
                image.AnimalId = int.Parse(HttpContext.User.FindFirst("sub").Value);
                Image createdImage = imageDao.UploadImage(image);
                if (createdImage != null)
                {
                    return Ok(createdImage);
                }
            }
            catch (DaoException)
            {
                return StatusCode(500, "There was an error");
            }

            return StatusCode(500, "There was an error");
        }

        [HttpGet("{username}")]
        public ActionResult<List<Image>> GetImagesByAnimalId(int id)
        {
            List<Image> images = null;
            try
            {
                images = imageDao.GetImagesByAnimalId(id);
                if (images != null)
                {
                    return Ok(images);
                }
            }
            catch (DaoException)
            {
                return StatusCode(500, "There was an error");
            }

            return StatusCode(500, "There was an error");
        }
    }
}
