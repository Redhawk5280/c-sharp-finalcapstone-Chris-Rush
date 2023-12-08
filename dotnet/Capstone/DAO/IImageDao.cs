using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IImageDao
    {
        Image UploadImage(Image image);
        Image UploadImages(List<Image> images);
        List<Image> GetImagesByAnimalId(int id);
        List<Animal> PopulatePicturesToListings(List<Animal> listings);
        Animal PopulatePicturesToListing(Animal animal);
    }
}
