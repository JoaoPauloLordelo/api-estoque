using System.ComponentModel.DataAnnotations;

namespace AprendizadoCSharp.Application.DTOs.Auth
{
    public record RegisterDTO
    {
        [Required]
        public string? Username{ get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
