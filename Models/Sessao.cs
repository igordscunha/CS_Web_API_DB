using CS_API_WEB.Data.Dtos;
using System.ComponentModel.DataAnnotations;

namespace CS_API_WEB.Models;

public class Sessao
{
    [Required(ErrorMessage = "Você precisa especificar o ID de um filme.")]
    public int? FilmeId { get; set; }
    public virtual Filme Filme { get; set; }

    [Required(ErrorMessage = "Você precisa especificar o ID de um cinema.")]
    public int? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
}
