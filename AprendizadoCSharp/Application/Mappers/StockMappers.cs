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

        public static Stock toStockFromCreateDTO(this CreateStockDTO stockDTO)
        {
            return new Stock
            {
                Symbol = stockDTO.Symbol,
                CompanyName = stockDTO.CompanyName,
                Purchase = stockDTO.Purchase,
                LastDiv = stockDTO.LastDiv,
                Industry = stockDTO.Industry,
                MarketCap = stockDTO.MarketCap
            };
        }

        public static void updateStockFromDTO(this Stock stock, UpdateStockDTO dto)
        {
            stock.Symbol = dto.Symbol;
            stock.CompanyName = dto.CompanyName;
            stock.Purchase = dto.Purchase;
            stock.LastDiv = dto.LastDiv;
            stock.Industry = dto.Industry;
            stock.MarketCap = dto.MarketCap;
        }
    }
}
