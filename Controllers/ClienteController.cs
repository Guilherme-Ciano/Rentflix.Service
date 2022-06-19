using Microsoft.AspNetCore.Mvc;
using rentflix.service.DTOs;

namespace rentflix.service.Controllers;

[ApiController]
[Route("[cliente]")]
public class ClienteController : ControllerBase
{
    [HttpGet(Name = "GetCliente")]
    public IEnumerable<ClienteDTO> GetAllClientes()
    {
        var clientes = _repository.Getclientes().Select(item => item.AsDTO());

        return clientes;
    }

    [HttpGet("{id}")]
    public ActionResult<ClienteDTO> GetCliente(Guid id)
    {
        var item = _repository.GetItem(id);

        if (item == null)
        {
            return NotFound();
        }

        return item.AsDTO();
    }

    [HttpPost]
    public ActionResult<ClienteDTO> CreateCliente(CreateClienteDTO item)
    {
        var newItem = new ClienteDTO
        {
            Nome = item.Nome,
            CPF = item.CPF,
            DataNascimento = item.DataNascimento,
        };

        _repository.CreateItem(newItem);

        return CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, newItem.AsDTO());
    }

    [HttpPut("{id}")]
    public ActionResult<ClienteDTO> UpdateCliente(int id, UpdateClienteDTO item)
    {
        var existingItem = _repository.GetItem(id);

        if (existingItem == null)
        {
            return NotFound();
        }

        Item updatedItem = existingItem with
        {
            Name = item.Name,
            Price = item.Price
        };

        _repository.UpdateItem(updatedItem);

        return updatedItem.AsDTO();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCliente(int id)
    {
        var existingItem = _repository.GetItem(id);

        if (existingItem == null)
        {
            return NotFound();
        }

        _repository.DeleteItem(id);

        return NoContent();
    }
}