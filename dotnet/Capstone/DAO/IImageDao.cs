using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IImageDao
    {
        Image UploadImage(Image image);
        List<Image> GetImagesByAnimalId(int id);
        List<Animal> AddPicturesToListings(List<Animal> listings);
        Animal AddPicturesToAnimal(Animal animal);
    }
}
