using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("/volunteers")]
    public class VolunteerController : ControllerBase
    {
        IVolunteerDao volunteerDao;

        public VolunteerController(IVolunteerDao volunteerDao)
        {
            this.volunteerDao = volunteerDao;
        }

        [HttpGet("applications")]
        public ActionResult<List<Application>> GetApplications()
        {
            const string ErrorMessage = "There was an error";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                result = Ok(volunteerDao.GetAllApplications());
            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }

            return result;
        }
        [HttpGet("applications/{id}")]
        public ActionResult<Application> GetApplicationById(int id) 
        {
            const string ErrorMessage = "There was an error";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                result = Ok(volunteerDao.GetApplicationById(id));
            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }

            return result;
        }
        [HttpPost("applications")]
        public ActionResult<Application> AddApplication(Application application)
        {
            const string ErrorMessage = "There was an error";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                Application addedApp = volunteerDao.AddApplication(application);
                result = Created($"/volunteers/applications/{addedApp.AppId}",addedApp);
            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }

            return result;
        }
    }
}
