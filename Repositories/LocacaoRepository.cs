using rentflix.service.Interfaces;
using rentflix.service.DTOs;
using MySqlConnector;
using Dapper;

namespace rentflix.service.Repositories
{
    public class LocacaoRepository : LocacaoInterface
    {
        public IEnumerable<LocacaoDTO> GetAll()
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    return connection.Query<LocacaoDTO>("SELECT * FROM locacoes ORDER BY id ASC");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(LocacaoDTO locacao)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    connection.Execute("INSERT INTO locacoes (cliente_id, filme_id, data_locacao, data_devolucao) VALUES (@cliente_id, @filme_id, @data_locacao, @data_devolucao)", locacao);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(LocacaoDTO locacao)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    connection.Execute("UPDATE locacoes SET cliente_id = @cliente_id, filme_id = @filme_id, data_locacao = @data_locacao, data_devolucao = @data_devolucao WHERE id = @id", locacao);
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
                    connection.Execute("DELETE FROM locacoes WHERE id = @id", new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LocacaoDTO GetById(int id)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    return (LocacaoDTO)connection.Query<LocacaoDTO>("SELECT * FROM locacoes WHERE id = @id", new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LocacaoDTO GetByClienteId(int id)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    return (LocacaoDTO)connection.Query<LocacaoDTO>("SELECT * FROM locacoes WHERE cliente_id = @id", new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LocacaoDTO GetByFilmeId(int id)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    return (LocacaoDTO)connection.Query<LocacaoDTO>("SELECT * FROM Locacao WHERE FilmeId = @id", new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<LocacaoDTO> GetByDataLocacao(DateTime dataLocacao)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    return connection.Query<LocacaoDTO>("SELECT * FROM Locacao WHERE DataLocacao = @dataLocacao", new { dataLocacao });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}