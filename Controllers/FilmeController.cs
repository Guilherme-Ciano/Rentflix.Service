using Microsoft.AspNetCore.Mvc;
using rentflix.service.DTOs;
using rentflix.service.Repositories;

namespace rentflix.service.Controllers;

[ApiController]
[Route("filmes")]

public class FilmeController : ControllerBase
{
    private readonly FilmeRepository _filmeRepository;

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public IEnumerable<FilmeDTO> GetAllFilmes()
    {
        try
        {
            return _filmeRepository.GetAll();
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
        var newItem = new FilmeDTO
        {
            Titulo = item.Titulo,
            ClassificacaoIndicativa = item.ClassificacaoIndicativa,
            Sinopse = item.Sinopse,
            Genero = item.Genero,
            Lancamento = item.Lancamento,
        };

        try
        {

            _filmeRepository.Create(newItem);
            return CreatedAtRoute("GetFilme", new { id = newItem.Id }, newItem);

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
    [HttpPut("{id}")]
    public ActionResult<FilmeDTO> UpdateFilme(int id, FilmeDTO item)
    {
        var newItem = new FilmeDTO
        {
            Titulo = item.Titulo,
            ClassificacaoIndicativa = item.ClassificacaoIndicativa,
            Sinopse = item.Sinopse,
            Genero = item.Genero,
            Lancamento = item.Lancamento,
        };

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
