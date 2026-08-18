using AprendizadoCSharp.Domain.Stock.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprendizadoCSharp.Application.DTOs.Stock
{
    public record GetStockDTO
    {
        public long Id { get; set; }
        public string Symbol { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}
