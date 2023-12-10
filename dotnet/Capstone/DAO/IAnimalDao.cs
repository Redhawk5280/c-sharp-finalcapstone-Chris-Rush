using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IAnimalDao
    {
        List<Animal> GetAnimals();

        Animal GetAnimalById(int id);

        Animal CreateAnimal(Animal animal);

        Animal UpdateAnimal(Animal animal);
    }
}
