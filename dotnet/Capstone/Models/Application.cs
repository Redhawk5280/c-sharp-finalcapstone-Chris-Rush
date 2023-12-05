using System.Collections.Generic;

namespace Capstone.Models
{
    public class Application
    {
        public int AppId { get; set; }

        public string AppName { get; set; }

        public string AppEmail { get; set; }

        public bool WeekdayAvailable { get; set; }

        public bool WeekendAvailable { get; set; }

        public string Interest { get; set; }
    }
}
