using System.ComponentModel.DataAnnotations;

namespace AprendizadoCSharp.Application.DTOs.Stocks
{
    public class CreateStockDTO
    {
        [Required]
        [MaxLength(10, ErrorMessage ="Symbol só pode ter até 10 caracteres")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "CompanyName só pode ter até 10 caracteres")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1,100000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.0001,100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Industry só pode ter até 10 caracteres")]
        public string Industry { get; set; } = string.Empty;
        [Range(0, 1000)]
        public long MarketCap { get; set; }
    }
}
