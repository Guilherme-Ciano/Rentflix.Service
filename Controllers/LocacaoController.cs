using Microsoft.AspNetCore.Mvc;
using rentflix.service.DTOs;
using rentflix.service.Repositories;

namespace rentflix.service.Controllers;

[ApiController]
[Route("locacoes")]

public class LocacaoController : ControllerBase
{
    private LocacaoRepository _locacaoRepository = new LocacaoRepository();

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public IEnumerable<LocacaoDTO> GetAllLocacoes()
    {
        try
        {
            List<LocacaoDTO> locacoes = _locacaoRepository.GetAll();
            return locacoes;
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
        var newItem = new LocacaoDTO(
            item.Id_Cliente,
            item.Id_Filme,
            item.DataLocacao,
            item.DataDevolucao
        );

        try
        {
            _locacaoRepository.Create(newItem);
            Object response = new { message = "Locação criada com sucesso!", data = newItem };
            return Ok(response);
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
        var newItem = new LocacaoDTO(
            item.Id,
            item.Id_Cliente,
            item.Id_Filme,
            item.DataLocacao,
            item.DataDevolucao
        );

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


