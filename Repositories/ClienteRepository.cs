using System.Net;
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
                    return connection.Query<ClienteDTO>("SELECT * FROM clientes ORDER BY id ASC");
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
                    return (ClienteDTO)connection.Query<ClienteDTO>("SELECT * FROM clientes WHERE id = @id", new { id });
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
                    connection.Execute("INSERT INTO clientes (nome, cpf, data_nascimento, email, senha) VALUES (@Nome, @CPF, @DataNascimento, @Email, @Senha)", cliente);
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
                    connection.Execute("UPDATE clientes SET nome = @Nome, cpf = @CPF, data_nascimento = @DataNascimento WHERE id = @Id", cliente);
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
                    connection.Execute("DELETE FROM clientes WHERE id = @id", new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}