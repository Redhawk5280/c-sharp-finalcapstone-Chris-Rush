using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("/volunteers")]
    public class VolunteerController : ControllerBase
    {
        IVolunteerDao volunteerDao;
        IUserDao userDao;
        IEmailService emailService;

        public VolunteerController(IVolunteerDao volunteerDao, IUserDao iUserDao, IEmailService iEmailService)
        {
            this.volunteerDao = volunteerDao;
            userDao = iUserDao;
            emailService = iEmailService;

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
        [HttpPut("applications")]
        public ActionResult<Application> UpdateApplication(Application application)
        {
            const string ErrorMessage = "There was an error";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                Application updatedApp = volunteerDao.UpdateApplication(application);
                if (updatedApp.IsApproved == true)
                {
                    userDao.CreateUser(updatedApp.AppEmail, "password", "user");
                    //email method
                    emailService.SendFirstLoginEmail(updatedApp.AppEmail, "password");
                }
                result = Ok(volunteerDao.GetApplicationById(updatedApp.AppId));
            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }

            return result;
        }
    }
}
