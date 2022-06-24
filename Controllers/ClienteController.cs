using System.Net;
using Microsoft.AspNetCore.Mvc;
using rentflix.service.Models;
using rentflix.service.DTOs;
using rentflix.service.Repositories;

namespace rentflix.service.Controllers;

[ApiController]
[Route("clientes")]
public class ClienteController : ControllerBase
{
    private ClienteRepository ClienteRepository = new ClienteRepository();


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public IEnumerable<ClienteDTO> GetAllClientes()
    {
        try
        {
            return ClienteRepository.GetAll();
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
        try
        {
            return ClienteRepository.GetById(id);
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
    public ActionResult<ClienteDTO> CreateCliente(ClienteDTO item)
    {
        ClienteDTO cliente = new ClienteDTO(item.Nome, item.CPF, item.DataNascimento, item.Email, item.Senha);

        try
        {

            ClienteRepository.Create(cliente);

            string token = Guid.NewGuid().ToString();
            Object response = new { message = "Cliente criado com sucesso!", token = token, data = cliente };
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
    public ActionResult<ClienteDTO> UpdateCliente(int id, ClienteDTO item)
    {
        try
        {
            var cliente = ClienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Nome = item.Nome;
            cliente.CPF = item.CPF;
            cliente.DataNascimento = item.DataNascimento;

            ClienteRepository.Update(cliente);
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
            var cliente = ClienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            ClienteRepository.Delete(id);
            return NoContent();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}