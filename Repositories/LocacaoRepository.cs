using rentflix.service.Interfaces;
using rentflix.service.DTOs;
using MySqlConnector;
using Dapper;

namespace rentflix.service.Repositories
{
    public class LocacaoRepository : LocacaoInterface
    {
        public List<LocacaoDTO> GetAll()
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    List<LocacaoDTO> locacoes = new List<LocacaoDTO>();
                    var result = connection.Query("SELECT * FROM locacoes").ToList();

                    result.ForEach(x =>
                    {
                        locacoes.Add(new LocacaoDTO(
                            x.id,
                            x.cliente_id,
                            x.filme_id,
                            x.data_locacao,
                            x.data_devolucao
                        ));
                    });

                    if (result == null)
                    {
                        return new List<LocacaoDTO>();
                    }
                    else
                    {
                        return locacoes;
                    }
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
                    connection.Execute("INSERT INTO locacoes (cliente_id, filme_id, data_locacao, data_devolucao) VALUES (@Id_Cliente, @Id_Filme, @DataLocacao, @DataDevolucao)", locacao);
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