using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;

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
        public void RecordAppointment(int clientId, int specialistId, int contractId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Zapis (ID_klienta, ID_Spec_Sotrudnic, ID_Dogovora) VALUES (@ClientId, @SpecialistId, @ContractId)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@ClientId", clientId);
                command.Parameters.AddWithValue("@SpecialistId", specialistId);
                command.Parameters.AddWithValue("@ContractId", contractId);
                command.ExecuteNonQuery();
            }
        }


        private int GetClientIdByName(string clientName)
        {
            // Метод для получения ID клиента по имени
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID_Klient FROM Klient WHERE LOWER(FName + ' ' + Name) = @ClientName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientName", clientName);
                    return (int)command.ExecuteScalar(); // Возвращает первый найденный ID_Klient
                }
            }
        }
        public DataTable GetEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Sotrudnic", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable employees = new DataTable();
                adapter.Fill(employees);
                return employees;
            }
        }

        public DataTable GetContracts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT ID_Dogovora, Nomer_Dogovota FROM Dogovor", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable contracts = new DataTable();
                adapter.Fill(contracts);
                return contracts;
            }
        }


        public void AddEmployee(string fName, string name, string othestvo, string adres, string telefon, string poshta, string doljnost, string shas_rabot)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Sotrudnic (FName, Name, Othestvo, Adres, Telefon, Poshta, Doljnost, Shas_Rabot) VALUES (@FName, @Name, @Othestvo, @Adres, @Telefon, @Poshta, @Doljnost, @Shas_Rabot)", connection);
                command.Parameters.AddWithValue("@FName", fName);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Othestvo", othestvo);
                command.Parameters.AddWithValue("@Adres", adres);
                command.Parameters.AddWithValue("@Telefon", telefon);
                command.Parameters.AddWithValue("@Poshta", poshta);
                command.Parameters.AddWithValue("@Doljnost", doljnost);
                command.Parameters.AddWithValue("@Shas_Rabot", shas_rabot);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void CreateContract(string Nomer_Dogovota)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Dogovor (Nomer_Dogovota) VALUES (@Nomer_Dogovota)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nomer_Dogovota", Nomer_Dogovota);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении договора: {ex.Message}");
            }
        }


    }
}