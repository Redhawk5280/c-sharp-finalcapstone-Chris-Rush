using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IVolunteerDao
    {
        public Application AddApplication(Application application);

        public List<Application> GetAllApplications();

        public Application GetApplicationById(int id);

        public Application UpdateApplication(Application application);
    }
}
