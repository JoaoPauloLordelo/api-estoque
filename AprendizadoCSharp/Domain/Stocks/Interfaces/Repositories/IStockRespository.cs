using AprendizadoCSharp.Domain.Stocks.Filters;
using AprendizadoCSharp.Domain.Stocks.Models;


namespace AprendizadoCSharp.Domain.Stocks.Interfaces.Repositories
{ 
    public interface IStockRespository
    {
        public Task<Stock> GetStock(long id);
        public Task<List<Stock>> GetAllStock(StockQueryParams queryParams);
        public Task SaveChanges();
        public Task SaveStock(Stock stock);
        public void DeleteStock(Stock stock);

    }
}
