namespace Capstone.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageString { get; set; } = string.Empty;
        public int? AnimalId { get; set; }
    }

    public class ImageToUpload
    {
        public string ImageString { get; set; } = "";
    }
}
