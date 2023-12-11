using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IImageDao
    {
        Image UploadImage(Image image);
        List<Image> UploadImages(List<Image> images, int animalId);
        int DeleteImages(int id);
        List<Image> GetImagesByAnimalId(int id);
        List<Animal> PopulatePicturesToListings(List<Animal> listings);
        Animal PopulatePicturesToListing(Animal animal);
    }
}
