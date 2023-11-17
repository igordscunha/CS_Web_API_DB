using CS_API_WEB.Models;
using System.ComponentModel.DataAnnotations;

namespace CS_API_WEB.Data.Dtos;

public class UpdateEnderecoDto
{
    public string Logradouro { get; set; }
    public int Numero { get; set; }
}
