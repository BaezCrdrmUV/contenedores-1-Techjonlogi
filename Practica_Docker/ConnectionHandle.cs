using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace Practica_Docker
{
    class ConnectionHandle
    {
        MySqlConnection connection;
        private string connectionString;

        public ConnectionHandle() {
            connectionString = "server=192.168.100.32;port=33061;user=admin;password=admin;database=Persona";
            connection = new MySqlConnection(connectionString);
        }



        public List<string> ExecuteReader(string sqlQuery, string getValue = "nombre")
        {
            List<string> values = new List<string>();
            try
            {
                connection.Open();
                var command = new MySqlCommand(sqlQuery, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var value = reader.GetString(getValue);
                   
                    values.Add(value);
                }

                if (values.Count == 0) Console.WriteLine("Vacío");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error", ex.Message);
            }
            return values;
        }



        public void ExecuteQuery(string sqlQuery)
        {
            try
            {
                connection.Open();
                var command = new MySqlCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error", ex.Message);
            }
        }


    }
}
