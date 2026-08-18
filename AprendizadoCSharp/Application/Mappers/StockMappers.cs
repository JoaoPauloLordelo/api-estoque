using AprendizadoCSharp.Application.DTOs.Stock;
using AprendizadoCSharp.Domain.Stock.Models;

namespace AprendizadoCSharp.Application.Mappers
{
    public static class StockMappers
    {
        public static GetStockDTO toGetStockDTO(this Stock stockModel)
        {
            return new GetStockDTO
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }
    }
}
