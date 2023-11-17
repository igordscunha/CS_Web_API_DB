using CS_API_WEB.Models;
using System.ComponentModel.DataAnnotations;

namespace CS_API_WEB.Data.Dtos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
}
