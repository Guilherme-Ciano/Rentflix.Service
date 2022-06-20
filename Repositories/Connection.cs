using MySqlConnector;

namespace rentflix.service.Repositories
{
    public class DB_Connection
    {
        public static string _connectionString = "Server=localhost;Database=rentflix;Uid=root;Pwd=root;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public static MySqlConnection CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            return connection;
        }
    }

}