using System;
using Npgsql;
namespace EncapsulationTest.utils
{
    public class Connector
    {
        //Connection Strings
        private static string connectionString="Server=localhost;Port=5432;User Id=postgres;Password=root;Database=StudentDb";
        //Database Connection Manipulators
        protected NpgsqlConnection connection;
        protected NpgsqlCommand commmand;
        protected NpgsqlDataReader reader;


        public void connect()
        {
            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        public void disconnect()
        {
            try
            {
                if(connection != null)
                {
                    connection.Close();
                }

                if(commmand != null)
                {
                    connection.Close();
                }

                if(reader != null)
                {
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }
    }
}
