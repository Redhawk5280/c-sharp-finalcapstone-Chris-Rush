using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Capstone.DAO
{
    public class VolunteerSqlDao : IVolunteerDao
    {
        private readonly string connectionString;
        public VolunteerSqlDao(string dbConnectionString) 
        {
            connectionString = dbConnectionString;

        }

        public Application AddApplication(Application application)
        {
            Application newApplication = null;

            string sql = "INSERT INTO volunteer_apps (applicant_name, applicant_email, weekday_available, weekend_available, interest, isApproved) " +
                         "OUTPUT INSERTED.app_id " +
                         "VALUES (@name, @email, @weekday_available, @weekend_available, @interest, null)";

            int newAppId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", application.AppName) ;
                    cmd.Parameters.AddWithValue("@email", application.AppEmail);
                    cmd.Parameters.AddWithValue("@weekday_available", application.WeekdayAvailable);
                    cmd.Parameters.AddWithValue("@weekend_available", application.WeekendAvailable);
                    cmd.Parameters.AddWithValue("@interest", application.Interest);

                    newAppId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                newApplication = GetApplicationById(newAppId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newApplication;
        }

        public List<Application> GetAllApplications()
        {
            List<Application> appList = new List<Application>();
            string sqlcmd = "SELECT app_id, applicant_name, applicant_email, weekday_available, weekend_available, interest, isApproved FROM volunteer_apps";

            try
            {
            using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Application application = MapRowToApplication(reader);
                        appList.Add(application);
                    }
                }

            }
            catch (SqlException ex)
            {
               throw new DaoException("SQL exception occurred", ex);
            }

            return appList;
        }

        public Application GetApplicationById(int id)
        {
            Application application = null;

            string sql =
                "SELECT app_id, applicant_name, applicant_email, weekday_available, weekend_available, interest, isApproved " + 
                "FROM volunteer_apps " + 
                "WHERE app_id = @app_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@app_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        application = MapRowToApplication(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return application;
        }
        public Application UpdateApplication(Application application)
        {
            Application updatedApplication = null;
            string sql = "UPDATE volunteer_apps SET isApproved = @isApproved " +
                         "WHERE app_id = @app_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@app_id", application.AppId);
                    cmd.Parameters.AddWithValue("@isApproved", application.IsApproved);
                    cmd.ExecuteNonQuery();

                    updatedApplication = GetApplicationById(application.AppId);
                    if (updatedApplication.IsApproved == GetApplicationById(application.AppId).IsApproved)
                    {
                        return updatedApplication;
                    }
                    else
                    {
                        throw new DaoException("SQL exception occurred: did not update correct table item");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            
        }

        private Application MapRowToApplication(SqlDataReader reader)
        {
            Application application = new Application();
            application.AppId = Convert.ToInt32(reader["app_id"]);
            application.AppName = Convert.ToString(reader["applicant_name"]);
            application.AppEmail = Convert.ToString(reader["applicant_email"]);
            application.WeekdayAvailable = Convert.ToBoolean(reader["weekday_available"]);
            application.WeekendAvailable = Convert.ToBoolean(reader["weekend_available"]);
            application.Interest = Convert.ToString(reader["interest"]);
            if (!DBNull.Value.Equals(reader["isApproved"]))
            {
                application.IsApproved = Convert.ToBoolean(reader["isApproved"]);
            }
            return application;
        }
    }
}
