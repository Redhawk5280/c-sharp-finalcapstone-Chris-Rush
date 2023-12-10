using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security.Models;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public class ImageSqlDao : IImageDao
    {
        private readonly string connectionString;

        public ImageSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Image UploadImage(Image image)
        {
            string sql = "INSERT INTO images (image_string, animal_id) " +
                         "OUTPUT INSERTED.image_id " +
                         "VALUES (@image_string, @animal_id)";

            Image createdImage;
            int imageId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@image_string", image.ImageString);
                    cmd.Parameters.AddWithValue("@animal_id", image.AnimalId);

                    imageId = Convert.ToInt32(cmd.ExecuteScalar());

                }

                createdImage = GetImageById(imageId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return createdImage;
        }

        public List<Image> UploadImages(List<Image> images)
        {
            string sql = "INSERT INTO images (image_string, animal_id) " +
                         "OUTPUT INSERTED.image_id " +
                         "VALUES (@image_string, @animal_id)";
            List<Image> createdImages = new List<Image>();
            int imageId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    foreach (Image image in images)
                    {
                        cmd.Parameters.AddWithValue("@image_string", image.ImageString);
                        cmd.Parameters.AddWithValue("@animal_id", image.AnimalId);
                        imageId = Convert.ToInt32(cmd.ExecuteScalar());
                        createdImages.Add(GetImageById(imageId));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            return createdImages;
        }

        public int DeleteImages(int animalId)
        {
            string sql = "DELETE FROM images WHERE animal_id = @animal_id";
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@animal_id", animalId);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            return rowsAffected;
        }

        public Image GetImageById(int imageId)
        {
            Image image = null;

            string sql = "SELECT image_id, image_string, animal_id FROM images WHERE image_id = @image_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@image_id", imageId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        image = MapRowToImage(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return image;
        }

        public List<Image> GetImagesByAnimalId(int id)
        {
            List<Image> images = new List<Image>();

            string sql = "SELECT image_id, image_string, animal_id FROM images WHERE animal_id = @animal_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@animal_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        images.Add(MapRowToImage(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return images;
        }

        public List<Animal> PopulatePicturesToListings(List<Animal> listings)
        {

            string sql = "SELECT image_id, image_string, animal_id FROM images WHERE animal_id = @animal_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    for (int i = 0; i < listings.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@animal_id", listings[i].Id);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            listings[i].Photos.Add(MapRowToImage(reader));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            return listings;
        }

        public Animal PopulatePicturesToListing(Animal animal)
        {
            string sql = "SELECT image_id, image_string, animal_id FROM images WHERE animal_id = @animal_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@animal_id", animal.Id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        animal.Photos.Add(MapRowToImage(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return animal;
        }

        private Image MapRowToImage(SqlDataReader reader)
        {
            return new Image()
            {
                ImageId = Convert.ToInt32(reader["image_id"]),
                ImageString = Convert.ToString(reader["image_string"]),
                AnimalId = Convert.ToInt32(reader["animal_id"]),
            };
        }

    }
}
