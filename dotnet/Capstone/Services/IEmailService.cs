using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.Services
{
    public interface IEmailService
    {
        void SendFirstLoginEmail(string toAddress, string password);
        string GetUserName();
        string GetPassword();
        string ToAddress();
    }
}
