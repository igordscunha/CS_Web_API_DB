using System.ComponentModel.DataAnnotations;

namespace CS_API_WEB.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "Por favor insira um endereço válido.")]
    public string Logradouro { get; set; }

    [Required]
    [Range(1, 99999, ErrorMessage = "Por favor insira um número válido.")]
    public int Numero { get; set; }
    public virtual Cinema Cinema { get; set; }
}
