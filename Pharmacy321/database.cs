using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pharmacy321
{
    public class Database
    {
        private string connectionString;
      


        public Database()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString;
        }

        public DataTable GetClients()
        {
            DataTable clientsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID_Klient, FName, Name, Othestvo, Pochta, Telefon, Skidka FROM Klient"; // Убедитесь, что вы выбираете все необходимые поля
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(clientsTable);
                }
            }

            return clientsTable;
        }
        public DataTable GetSpecialists()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID_Sotudnica, FName + ' - ' + Doljnost AS FullNameAndPosition FROM Sotrudnic";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public void AddClient(string FName, string Name, string Othestvo, string Pochta, string Telefon, string Skidka)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Klient (FName, Name,  Othestvo, Pochta, Telefon, Skidka) VALUES (@FName, @Name, @Othestvo, @Pochta, @Telefon, @Skidka)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@FName", FName);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Othestvo", Othestvo);
                command.Parameters.AddWithValue("@Pochta", Pochta);
                command.Parameters.AddWithValue("@Telefon", Telefon);
                command.Parameters.AddWithValue("@Skidka", Skidka);
                command.ExecuteNonQuery();
            }
        }
        public void RecordAppointment(string clientName, string specialistName)
        {
            // Логика для записи клиента на прием в базу данных
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Appointments (ClientName, SpecialistName) VALUES (@ClientName, @SpecialistName)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@ClientName", clientName);
                command.Parameters.AddWithValue("@SpecialistName", specialistName);
                command.ExecuteNonQuery();
            }
        }

    }
}