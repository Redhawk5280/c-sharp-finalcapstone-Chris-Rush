using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        IAnimalDao animalDao;

        public AnimalController(IAnimalDao animalDao)
        {
            this.animalDao = animalDao;
        }

        [HttpGet]
        public ActionResult<IList<Animal>> GetAnimals()
        {
            const string ErrorMessage = "There was an error";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                result = Ok(animalDao.GetAnimals());

            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }

            return result;
        }
    }
}
