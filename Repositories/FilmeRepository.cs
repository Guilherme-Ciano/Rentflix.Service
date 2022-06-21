using rentflix.service.Interfaces;
using rentflix.service.DTOs;
using MySqlConnector;
using Dapper;

namespace rentflix.service.Repositories
{
    public class FilmeRepository : FilmeInterface
    {
        public IEnumerable<FilmeDTO> GetAll()
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    return connection.Query<FilmeDTO>("SELECT * FROM filmes ORDER BY id ASC");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FilmeDTO GetById(int id)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    return (FilmeDTO)connection.Query<FilmeDTO>("SELECT * FROM filmes WHERE id = @id", new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Create(FilmeDTO filme)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    connection.Execute("INSERT INTO filmes (titulo, classificacao_indicativa, sinopse, genero, lancamento) VALUES (@titulo, @classificacao_indicativa, @sinopse, @genero, @lancamento)", filme);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(FilmeDTO filme)
        {
            try
            {
                using (MySqlConnection connection = DB_Connection.GetConnection())
                {
                    connection.Execute("UPDATE filmes SET titulo = @titulo, classificacao_indicativa = @classificacao_indicativa, sinopse = @sinopse, genero = @genero, lancamento = @lancamento WHERE id = @id", filme);
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
                    connection.Execute("DELETE FROM filmes WHERE id = @id", new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}