using Microsoft.AspNetCore.Mvc;
using rentflix.service.DTOs;
using rentflix.service.Repositories;

namespace rentflix.service.Controllers;

[ApiController]
[Route("locacoes")]

public class LocacaoController : ControllerBase
{
    private readonly LocacaoRepository _locacaoRepository;

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public IEnumerable<LocacaoDTO> GetAllLocacoes()
    {
        try
        {
            return _locacaoRepository.GetAll();
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
    public LocacaoDTO GetLocacao(int id)
    {
        try
        {
            return _locacaoRepository.GetById(id);
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
    [HttpGet("cliete/{id}")]
    public LocacaoDTO GetLocacaoByClienteId(int id)
    {
        try
        {
            return _locacaoRepository.GetByClienteId(id);
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
    [HttpGet("filme/{id}")]
    public LocacaoDTO GetLocacaoByFilmeId(int id)
    {
        try
        {
            return _locacaoRepository.GetByFilmeId(id);
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
    public ActionResult<LocacaoDTO> CreateLocacao(LocacaoDTO item)
    {
        var newItem = new LocacaoDTO
        {
            Id_Cliente = item.Id_Cliente,
            Id_Filme = item.Id_Filme,
            DataLocacao = item.DataLocacao,
            DataDevolucao = item.DataDevolucao,
        };

        try
        {
            _locacaoRepository.Create(newItem);
            return CreatedAtRoute("GetLocacao", new { id = newItem.Id }, newItem);
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
    [HttpPut("{id}")]
    public ActionResult<LocacaoDTO> UpdateLocacao(LocacaoDTO item)
    {
        var newItem = new LocacaoDTO
        {
            Id = item.Id,
            Id_Cliente = item.Id_Cliente,
            Id_Filme = item.Id_Filme,
            DataLocacao = item.DataLocacao,
            DataDevolucao = item.DataDevolucao,
        };

        try
        {
            _locacaoRepository.Update(newItem);
            return CreatedAtRoute("GetLocacao", new { id = newItem.Id }, newItem);
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
    [HttpDelete("{id}")]
    public ActionResult<LocacaoDTO> DeleteLocacao(int id)
    {
        try
        {
            _locacaoRepository.Delete(id);
            return Ok();
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

}


