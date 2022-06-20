using Microsoft.AspNetCore.Mvc;
using rentflix.service.Models;
using rentflix.service.DTOs;
using rentflix.service.Repositories;

namespace rentflix.service.Controllers;

[ApiController]
[Route("cliente")]
public class ClienteController : ControllerBase
{
    private readonly ClienteRepository _clienteRepository;


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public IEnumerable<ClienteDTO> GetAllClientes()
    {
        try
        {
            return _clienteRepository.GetAll();
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
    public ClienteDTO GetCliente(int id)
    {
        return _clienteRepository.GetById(id);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
    [HttpPost]
    public ActionResult<ClienteDTO> CreateCliente(ClienteDTO item)
    {
        var newItem = new ClienteDTO
        {
            Nome = item.Nome,
            CPF = item.CPF,
            DataNascimento = item.DataNascimento,
        };

        try
        {

            _clienteRepository.Create(newItem);
            return CreatedAtRoute("GetCliente", new { id = newItem.Id }, newItem);

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
    public ActionResult<ClienteDTO> UpdateCliente(int id, ClienteDTO item)
    {
        try
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Nome = item.Nome;
            cliente.CPF = item.CPF;
            cliente.DataNascimento = item.DataNascimento;

            _clienteRepository.Update(cliente);
            return cliente;

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
    public ActionResult DeleteCliente(int id)
    {
        try
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _clienteRepository.Delete(id);
            return NoContent();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}