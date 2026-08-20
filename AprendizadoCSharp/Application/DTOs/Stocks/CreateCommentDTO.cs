using System.ComponentModel.DataAnnotations;

namespace AprendizadoCSharp.Application.DTOs.Stocks
{
    public class CreateCommentDTO
    {
        [Required]
        [MinLength(5, ErrorMessage ="Titulo precisa ter mais que 5 caracteres")]
        [MaxLength(20, ErrorMessage = "Titulo não pode ter mais que 20 caracteres")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Mensagem precisa ter mais que 10 caracteres")]
        [MaxLength(50, ErrorMessage = "Mensagem não pode ter mais que 50 caracteres")]
        public string Content { get; set; } = string.Empty;
        [Required]
        public long StockId { get; set; }
    }
}