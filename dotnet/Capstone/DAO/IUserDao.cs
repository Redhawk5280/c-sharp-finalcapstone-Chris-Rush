﻿using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDao
    {
        IList<User> GetUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        User CreateUser(string email, string password, string role);
        User DeactivateUser(string email);
    }
}
