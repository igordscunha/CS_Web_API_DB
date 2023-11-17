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

public class CinemaController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult RegistrarCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinema.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarCinemaPorId), new { Id = cinema.Id }, cinemaDto);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> ListarCinemas()
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinema.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ListarCinemaPorId(int id)
    {
        var cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema != null)
        {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarInformacaoUnicaCinema(int id, JsonPatchDocument<UpdateCinemaDto> patch)
    {
        var cinema = _context.Endereco.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound();

        var cinemaParaAtualizar = _mapper.Map<UpdateCinemaDto>(cinema);

        patch.ApplyTo(cinemaParaAtualizar, ModelState);

        if (!TryValidateModel(cinemaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(cinemaParaAtualizar, cinema);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletarCinema(int id)
    {
        var cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }

}