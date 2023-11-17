using Microsoft.AspNetCore.Mvc;
using CS_API_WEB.Models;
using CS_API_WEB.Data;
using CS_API_WEB.Data.Dtos;
using AutoMapper;
using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch;

namespace CS_API_WEB.Controllers;

[ApiController]
[Route("[controller]")]

public class EnderecoController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult RegistrarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Endereco.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarEnderecoPorId),
            new { id = endereco.Id },
            endereco);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> ListarEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Endereco.Skip(skip).Take(take));

    }

    [HttpGet("{id}")]
    public IActionResult ListarEnderecoPorId(int id)
    {
        var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarInformacaoUnicaEndereco(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
    {
        var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        var enderecoParaAtualizar = _mapper.Map<UpdateEnderecoDto>(endereco);

        patch.ApplyTo(enderecoParaAtualizar, ModelState);

        if (!TryValidateModel(enderecoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(enderecoParaAtualizar, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarEndereco(int id)
    {
        var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        _context.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
}