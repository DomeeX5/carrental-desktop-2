using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carrental_desktop_2
{
    internal class DatabaseHandler
    {
        MySqlConnection connection;
        private const string DB_HOST = "localhost";
        private const int DB_PORT = 3306;
        private const string DB_DBNAME = "probavizsga";
        private const string DB_USER = "root";
        private const string DB_PASSWORD = "";
        public DatabaseHandler()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = DB_HOST;
            builder.Port = DB_PORT;
            builder.Database = DB_DBNAME;
            builder.UserID = DB_USER;
            builder.Password = DB_PASSWORD;
            connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
        }

        public List<Car> ReadData()
        {
            List<Car> cars = new List<Car>();
            string sql = "SELECT * from cars";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string license_plate_number = reader.GetString("license_plate_number");
                    string brand = reader.GetString("brand");
                    string model = reader.GetString("model");
                    int daily_cost = reader.GetInt32("daily_cost");
                    cars.Add(new Car(id, license_plate_number, brand, model, daily_cost));
                }
            }

            return cars;
        }

        public bool DeleteById(int id)
        {
            string sql = "DELETE from cars WHERE id = @id";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", id);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
