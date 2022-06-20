using rentflix.service.Interfaces;
using rentflix.service.DTOs;
using MySqlConnector;
using Dapper;

namespace rentflix.service.Repositories
{
    public class ClienteRepository : ClienteInterface
    {
        public IEnumerable<ClienteDTO> GetAll()
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    return connection.Query<ClienteDTO>("SELECT * FROM Cliente ORDER BY Id ASC");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteDTO GetById(int id)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    return (ClienteDTO)connection.Query<ClienteDTO>("SELECT * FROM Cliente WHERE Id = @id", new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(ClienteDTO cliente)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    connection.Execute("INSERT INTO Cliente (Nome, CPF, DataNascimento) VALUES (@Nome, @CPF, @DataNascimento)", cliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(ClienteDTO cliente)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    connection.Execute("UPDATE Cliente SET Nome = @Nome, CPF = @CPF, DataNascimento = @DataNascimento WHERE Id = @Id", cliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    connection.Execute("DELETE FROM Cliente WHERE Id = @id", new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}