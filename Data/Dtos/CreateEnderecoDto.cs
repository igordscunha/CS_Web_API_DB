using CS_API_WEB.Models;
using System.ComponentModel.DataAnnotations;

namespace CS_API_WEB.Data.Dtos;

public class CreateEnderecoDto
{
    [Required]
    [StringLength(200, ErrorMessage = "Por favor insira um endereço válido.")]
    public string Logradouro { get; set; }

    [Required]
    [Range(1, 99999, ErrorMessage = "Por favor insira um número válido.")]
    public int Numero { get; set; }
}
