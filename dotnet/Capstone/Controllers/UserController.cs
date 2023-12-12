using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

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
        public ActionResult<IList<UserInfo>> GetUsers()
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

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public ActionResult GetUserById(int id) 
        {
            const string ErrorMessage = "You are unauthorized";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                result = Ok(userDao.GetUserById(id));
            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }

            return result;
        }

        [Authorize(Roles = "admin")]
        [HttpPut("deactivate/{email}")]
        public ActionResult<User> DeactivateUser(string email)
        {
            const string ErrorMessage = "You are unauthorized";
            ActionResult result = BadRequest(new { message = ErrorMessage });

            try
            {
                result = Ok(userDao.DeactivateUser(email));
            }
            catch (DaoException)
            {
                result = StatusCode(500, ErrorMessage);
            }

            return result;
        }

        [HttpPut("{email}")]
        public ActionResult<User> UpdateUser(LoginUser user)
        {
            const string ErrorMessage = "I am a Teapot.";
            ActionResult result = BadRequest(new { message = ErrorMessage });
            try
            {
                result = Ok(userDao.UpdateUserPassword(user));
            }
            catch (DaoException)
            {
                result = StatusCode(418, ErrorMessage);
            }
            return result;
        }
        [HttpPut("{email}/promote")]
        public ActionResult<User> PromoteUser(string email)
        {
            const string ErrorMessage = "I am a promoted Teapot.";
            ActionResult result = BadRequest(new { message = ErrorMessage });
            try
            {
                User userToPromote = userDao.GetUserByEmail(email);
                result = Ok(userDao.PromoteUser(userToPromote));
            }
            catch (DaoException)
            {
                result = StatusCode(418, ErrorMessage);
            }
            return result;
        }


    }
}
