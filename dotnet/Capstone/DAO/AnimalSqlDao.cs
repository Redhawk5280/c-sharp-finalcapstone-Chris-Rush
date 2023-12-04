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
