using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDao userDao;

        public UserController(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IList<User>> GetUsers()
        {
            const string ErrorMessage = "You are unauthorized";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                result = Ok(userDao.GetUsers());

            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }

            return result;
        }
    }
}
