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

        public ClienteDTO GetClienteLogging(LoggingDTO item)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    var result = connection.Query("SELECT * FROM clientes WHERE email = @Email AND senha = @Senha", item).ToList();
                    if (result == null)
                    {
                        return null;
                    }
                    else
                    {
                        List<ClienteDTO> clientes = new List<ClienteDTO>();
                        result.ForEach(x =>

                        clientes.Add(new ClienteDTO
                        (
                            x.id,
                            x.nome,
                            x.cpf,
                            x.data_nascimento,
                            x.email,
                            x.senha
                        )));

                        return clientes.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}