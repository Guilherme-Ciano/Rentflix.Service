using System.Net;
using Microsoft.AspNetCore.Mvc;
using rentflix.service.DTOs;
using rentflix.service.Repositories;

namespace rentflix.service.Controllers;

[ApiController]
[Route("filmes")]

public class FilmeController : ControllerBase
{
    private FilmeRepository _filmeRepository = new FilmeRepository();

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public IEnumerable<FilmeDTO> GetAllFilmes()
    {
        try
        {
            List<FilmeDTO> filmes = _filmeRepository.GetAll();

            return filmes;
        }
        catch (Exception ex)
        {
            return (IEnumerable<FilmeDTO>)StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
    [HttpGet("{id}")]
    public FilmeDTO GetFilme(int id)
    {
        try
        {
            return _filmeRepository.GetById(id);
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
    [HttpPost]
    public ActionResult<FilmeDTO> CreateFilme(FilmeDTO item)
    {
        FilmeDTO novoFilme = new FilmeDTO(
            item.Titulo,
            item.Genero,
            item.Sinopse,
            item.ClassificacaoIndicativa,
            item.Lancamento,
            item.Poster
        );

        try
        {

            _filmeRepository.Create(novoFilme);
            string token = Guid.NewGuid().ToString();
            Object response = new { message = "Filme criado com sucesso!", token = token, data = novoFilme };
            return Ok(response);

        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
    [HttpPut("{id}")]
    public ActionResult<FilmeDTO> UpdateFilme(int id, FilmeDTO item)
    {
        var newItem = new FilmeDTO(
            item.Titulo,
            item.Genero,
            item.Sinopse,
            item.ClassificacaoIndicativa,
            item.Lancamento,
            item.Poster
        );

        try
        {
            _filmeRepository.Update(newItem);
            return newItem;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
    [HttpDelete("{id}")]
    public ActionResult<FilmeDTO> DeleteFilme(int id)
    {
        try
        {

            var filme = _filmeRepository.GetById(id);
            if (filme == null)
            {
                return NotFound();
            }

            _filmeRepository.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
