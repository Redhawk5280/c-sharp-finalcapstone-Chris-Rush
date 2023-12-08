using Capstone.Exceptions;
using Capstone.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Capstone.DAO
{
    public class AnimalSqlDao : IAnimalDao
    {
        private readonly string connectionString;

        public AnimalSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Animal CreateAnimal(Animal animal)
        {
            Animal newAnimal = null;

            string sql = "INSERT INTO Animal (name, age, breed, species, medical_needs, color, sex, weight, is_adopted, owner_name, about_me, is_good) " +
                         "OUTPUT INSERTED.animal_id " +
                         "VALUES (@name, @age, @breed, @species, @medical_needs, @color, @sex, @weight, @is_adopted, @owner_name, @about_me, @is_good)";

            int newAnimalId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", animal.Name);
                    cmd.Parameters.AddWithValue("@age", animal.Age);
                    cmd.Parameters.AddWithValue("@breed", animal.Breed);
                    cmd.Parameters.AddWithValue("@species", animal.Species);
                    cmd.Parameters.AddWithValue("@medical_needs", animal.MedicalNeeds);
                    cmd.Parameters.AddWithValue("@color", animal.Color);
                    cmd.Parameters.AddWithValue("@sex", animal.Sex);
                    cmd.Parameters.AddWithValue("@weight", animal.Weight);
                    cmd.Parameters.AddWithValue("@is_adopted", animal.IsAdopted);
                    cmd.Parameters.AddWithValue("@owner_name", animal.OwnerName);
                    cmd.Parameters.AddWithValue("@about_me", animal.AboutMe);
                    cmd.Parameters.AddWithValue("@is_good", animal.IsGood);

                    newAnimalId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                newAnimal = GetAnimalById(newAnimalId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newAnimal;
        }

        public List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();

            string sql = 
                "SELECT animal_id, name, age, breed, species, medical_needs, color, is_adopted, owner_name, sex, weight, about_me, is_good FROM animal";

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
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return animals;
        }

        public Animal GetAnimalById(int id)
        {
            Animal animal = null;

            string sql =
                "SELECT animal_id, name, age, breed, species, medical_needs, color, is_adopted, owner_name, sex, weight, about_me, is_good " +
                "FROM animal " +
                "WHERE animal_id = @animal_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@animal_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        animal = MapRowToAnimal(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return animal;
        }

        private Animal MapRowToAnimal(SqlDataReader reader)
        {
            Animal animal = new Animal();
            animal.Id = Convert.ToInt32(reader["animal_id"]);
            animal.Name = Convert.ToString(reader["name"]);
            animal.MedicalNeeds = Convert.ToBoolean(reader["medical_needs"]);
            animal.IsAdopted = Convert.ToBoolean(reader["is_adopted"]);
            animal.IsGood = Convert.ToBoolean(reader["is_good"]);
            animal.OwnerName = Convert.ToString(reader["owner_name"]);
            animal.Sex = Convert.ToString(reader["sex"]);
            animal.Weight = Convert.ToInt32(reader["weight"]);
            animal.Age = Convert.ToInt32(reader["age"]);
            animal.Breed = Convert.ToString(reader["breed"]);
            animal.Species = Convert.ToString(reader["species"]);
            animal.AboutMe = Convert.ToString(reader["about_me"]);
            animal.Color = Convert.ToString(reader["color"]);   

            
            return animal;
        }
    }
}
