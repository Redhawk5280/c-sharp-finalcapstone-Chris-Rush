using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IAnimalDao
    {
        IList<Animal> GetAnimals();
        Animal GetAnimalsById(int id);
        Animal CreateAnimals(Animal animal);
    }
}
