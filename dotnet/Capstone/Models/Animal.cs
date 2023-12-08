using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; } = "";
        public string Species { get; set; } = "";
        public bool MedicalNeeds { get; set; } = false;
        public string Color { get; set; } = "";
        public bool IsAdopted { get; set; } = false;
        public string OwnerName { get; set; } = "";
        public string Sex { get; set; } = "";
        public int Weight { get; set; } = 0;
        public string AboutMe { get; set; } = "";
        public List<Image> Photos { get; set; } = new List<Image>();
        public bool IsGood { get; set; } = true;
    }
}
