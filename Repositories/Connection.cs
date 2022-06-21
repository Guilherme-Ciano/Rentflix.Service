using MySqlConnector;

namespace rentflix.service.Repositories
{
    public class DB_Connection
    {
        public static string _connectionString = "Server=localhost;Database=rentflix;Uid=root;Pwd=admin;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public static MySqlConnection CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            return connection;
        }

        public static void CreateTables(MySqlConnection connection)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"CREATE TABLE IF NOT EXISTS `filmes` (
                                    `id` int(10) NOT NULL AUTO_INCREMENT,
                                    `titulo` varchar(100) NOT NULL,
                                    `classificacao_indicativa` int(10) NOT NULL,
                                    `sinopse` varchar(500) NOT NULL,
                                    `genero` varchar(100) NOT NULL,
                                    `lancamento` date NOT NULL,
                                    PRIMARY KEY (`id`)
                                ) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS `clientes` (
                                    `id` int(10) NOT NULL AUTO_INCREMENT,
                                    `nome` varchar(200) NOT NULL,
                                    `cpf` varchar(11) NOT NULL,
                                    `data_nascimento` date NOT NULL,
                                    PRIMARY KEY (`id`)
                                ) ENGINE=InnoDB DEFAULT CHARSET=utf8;";

            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS `locacoes` (
                                    `id` int(10) NOT NULL AUTO_INCREMENT,
                                    `cliente_id` int(10) NOT NULL,
                                    `filme_id` int(10) NOT NULL,
                                    `data_locacao` date NOT NULL,
                                    `data_devolucao` date NOT NULL,
                                    PRIMARY KEY (`id`)
                                ) ENGINE=InnoDB DEFAULT CHARSET=utf8;";

            command.ExecuteNonQuery();
            connection.Close();
        }
    }

}