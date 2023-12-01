using Capstone.Exceptions;
using Capstone.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class AnimalSqlDao : IAnimalDao
    {
        private readonly string connectionString;

        public AnimalSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Animal CreateAnimals(Animal animal)
        {
            throw new System.NotImplementedException();
        }

        public IList<Animal> GetAnimals()
        {
            IList<Animal> animals = new List<Animal>();

            string sql = 
                "SELECT name, age, breed, species, medical_needs, color, is_adopted, owner_name, sex, weight, about_me, is_good FROM animal";

            string pictureSql = 
                "SELECT photo_path FROM animal_photo " +
                "WHERE animal_id = @animal_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Animal animal = MapRowToAnimal(reader);
                        animals.Add(animal);
                    }

                    reader.Close();

                    foreach(Animal animal in animals)
                    {
                        SqlCommand pathCmd = new SqlCommand(pictureSql, conn);
                        SqlDataReader pathReader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string path = MapRowToPath(reader);
                            animal.PhotoPaths.Add(path);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return animals;
        }

        public Animal GetAnimalsById(int id)
        {
            throw new System.NotImplementedException();
        }

        private Animal MapRowToAnimal(SqlDataReader reader)
        {
            Animal animal = new Animal();
            animal.Name = Convert.ToString(reader["animal_name"]);
            animal.PhotoPaths = (List<string>)reader["photo_paths"];
            return animal;
        }

        private string MapRowToPath(SqlDataReader reader)
        {
            return Convert.ToString(reader["photo_path"]);
        }
    }
}
