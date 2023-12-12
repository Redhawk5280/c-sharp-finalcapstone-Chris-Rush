using Capstone.Exceptions;
using System;
using System.Net;
using System.Net.Mail;

namespace Capstone.Services
{
    public class EmailSmtpService : IEmailService
    {
        public string fromEmail = "";
        public string fromEmailPassword = "";
        public EmailSmtpService(string importedEmail, string importedPassword) 
        {
        //string toEmail = ""PawPrintsPetRescueCle@gmail.com
                //string password = PetRescue
            fromEmail = importedEmail;
            fromEmailPassword = importedPassword;
        }

        public void SendFirstLoginEmail(string toAddress, string password)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromEmailPassword)
            };
            string subject = "New Account Login";
            string body = "Hello! \n\n Congratulations on being accepted as a volunteer with the Paw Prints Pet Rescue! " +
                "\nBelow is a link to our login page; please use the following login credentials to access your account and " +
                $"update your password.\n\nUsername: {toAddress}\nPassword: {password}\n\n<a href=\"https://localhost:44315/volunteers/applications\">Login Here</a>" +
                "\n\nWelcome aboard!\n\n-Paw Prints Pet Rescue Team";
            try
            {
                Console.WriteLine("Before Email Sent");
                email.Send(fromEmail, toAddress, subject, body);
                Console.WriteLine("After Email Sent");
            }
            catch (SmtpException e)
            {
                throw new Exception("An error has occured sending email", e);
            }
        }

    }
}
