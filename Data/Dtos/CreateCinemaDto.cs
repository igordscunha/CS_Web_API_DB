using CS_API_WEB.Models;
using System.ComponentModel.DataAnnotations;

namespace CS_API_WEB.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Você precisa inserir o ID de um endereço existente.")]
        public int EnderecoId { get; set; }
    }
}
