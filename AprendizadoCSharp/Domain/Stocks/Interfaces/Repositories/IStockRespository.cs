using AprendizadoCSharp.Domain.Stocks.Models;


namespace AprendizadoCSharp.Domain.Stocks.Interfaces.Repositories
{ 
    public interface IStockRespository
    {
        public Task<Stock> GetStock(long id);
        public Task<List<Stock>> GetAllStock();
        public Task SaveChanges();
        public Task SaveStock();
        public void Remove();

    }
}
