using CS_API_WEB.Models;
using System.ComponentModel.DataAnnotations;

namespace CS_API_WEB.Data.Dtos;

public class ReadFilmeDto
{
    public string Titulo { get; set; }
    public string Diretor { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    public virtual ICollection<ReadSessaoDto> Sessoes { get; set; }
}
