using System.ComponentModel.DataAnnotations;

namespace CS_API_WEB.Data.Dtos;

public class CreateSessaoDto
{
    [Required(ErrorMessage = "Você precisa especificar o ID de um filme.")]
    public int FilmeId { get; set; }

    [Required(ErrorMessage = "Você precisa especificar o ID de um cinema.")]
    public int CinemaId { get; set; }
}
