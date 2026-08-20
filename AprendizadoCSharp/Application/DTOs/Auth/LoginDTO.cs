using System.ComponentModel.DataAnnotations;

namespace AprendizadoCSharp.Application.DTOs.Auth
{
    public record LoginDTO
    {
        [Required]
        public string Username{ get; set; }
        [Required]
        public string Password{ get; set; }
    }
}
