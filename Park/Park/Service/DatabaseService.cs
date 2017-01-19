using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park.Service
{
    public class DatabaseService
    {
        public List<Models.Park> LoadAllPark()
        {
            List<Models.Park> result = new List<Models.Park>();

            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ParkData;Integrated Security=True");
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = "Select * from ParkData";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Park item = new Models.Park();
                item.Manager = reader["Manager"].ToString();
                item.Users= reader["Users"].ToString();
                item.Map= reader["Map"].ToString();
                item.Number = reader["Number"].ToString();
                result.Add(item);
            }
            connection.Close();
            return result;
        }

        public Models.Park GetParkByID(string id)
        {
            Models.Park result = new Models.Park();

            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ParkData;Integrated Security=True");

            connection.Open();

            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
Select * from ParkData
Where Manager='{0}'", id);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Park item = new Models.Park();

                item.Manager = reader["Manager"].ToString();
                item.Users = reader["Users"].ToString();
                item.Map = reader["Map"].ToString();
                item.Number = reader["Number"].ToString();
                result = item;
            }
            connection.Close();
            return result;
        }
        public void CreatePark(Models.Park newPark)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ParkData;Integrated Security=True");
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    ParkData(Manager,Users,Map,Number)
VALUES          ('{0}','{1}','{2}','{3}')
", newPark.Manager, newPark.Users, newPark.Map, newPark.Number);

            command.ExecuteNonQuery();

            connection.Close();
        }
        public void DeletePark(string id)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ParkData;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
DELETE FROM ParkData
Where Manager='{0}'
", id);

            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdatePark(Models.Park updatePark)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ParkData;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
UPDATE          ParkData
SET             Users='{1}',Map='{2}',Number='{3}'
Where           Manager='{0}'
", updatePark.Manager, updatePark.Users, updatePark.Map, updatePark.Number);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}