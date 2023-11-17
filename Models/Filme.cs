using System.ComponentModel.DataAnnotations;

namespace CS_API_WEB.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O Título do filme é obrigatório!")]
    [StringLength(40, ErrorMessage = "O título deve conter menos de 40 caracteres.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O Diretor do filme é obrigatório!")]
    [StringLength(25, ErrorMessage = "O diretor deve conter menos de 25 caracteres.")]
    public string Diretor { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório!")]
    [StringLength(15, ErrorMessage = "Gênero inválido")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigatório!")]
    [Range(70, 600, ErrorMessage = "O filme deve ter pelo menos 70 minutos e até 600 minutos de duração.")]
    public int Duracao { get; set; }
    public virtual ICollection<Sessao> Sessoes { get; set; }
}