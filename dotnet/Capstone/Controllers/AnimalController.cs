using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("/animals")]
    public class AnimalController : ControllerBase
    {
        IAnimalDao animalDao;
        IImageDao imageDao;

        public AnimalController(IAnimalDao animalDao, IImageDao imageDao)
        {
            this.animalDao = animalDao;
            this.imageDao = imageDao;
        }

        [HttpGet]
        public ActionResult<List<Animal>> GetAnimals()
        {
            const string ErrorMessage = "There was an error";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                List<Animal> animalList = animalDao.GetAnimals();
                result = Ok(imageDao.PopulatePicturesToListings(animalList));
            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }

            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetAnimalById(int id)
        {
            const string ErrorMessage = "There was an error";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                Animal animal = animalDao.GetAnimalById(id);
                result = Ok(imageDao.PopulatePicturesToListing(animal));
            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }

            return result;
        }
        [HttpPost]
        public ActionResult<Animal> AddAnimal(Animal animal)
        {
            const string ErrorMessage = "There was an error creating animal posting";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                Animal newAnimal = animalDao.CreateAnimal(animal);
                if (newAnimal != null)
                {
                    List<Image> images = animal.Photos;
                    foreach (Image image in images)
                    {
                        image.AnimalId = newAnimal.Id;
                        image.ImageString = image.ImageString;

                    }
                        imageDao.UploadImages(animal.Photos) ;
                }
                result = Created($"/animals/{newAnimal.Id}", newAnimal);

            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }
            return result;
        }
    }
}
