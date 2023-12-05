using System.Collections.Generic;

namespace Capstone.Models
{
    public class Application
    {
        public int AppId { get; set; }

        public string AppName { get; set; }

        public string AppEmail { get; set; }

        public bool WeekdayAvailable { get; set; } = false;

        public bool WeekendAvailable { get; set; } = false;

        public string Interest { get; set; }
    }
}
