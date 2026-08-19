using AprendizadoCSharp.Application.DTOs.Stocks;
using AprendizadoCSharp.Domain.Stocks.Interfaces.Repositories;
using AprendizadoCSharp.Domain.Stocks.Models;
using AprendizadoCSharp.Infrasctucture.Context;
using Microsoft.EntityFrameworkCore;

namespace AprendizadoCSharp.Infrasctucture.Stocks.Repositories
{
    public class StockRepository : IStockRespository
    {
        private readonly ApplicationDBContext _context;
        
        public StockRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        public async Task DeleteStock(Stock stock)
        {
            this._context.Stocks.Remove(stock);
        }

        public async Task<List<Stock>> GetAllStock()
        {
            List<Stock> stocks = await _context.Stocks.ToListAsync();
            return stocks;
        }

        public async Task<Stock?> GetStock(long id)
        {
            Stock? stock = await this._context.Stocks.FindAsync(id);
            return stock;
        }

        public async Task SaveChanges()
        {
            await this._context.SaveChangesAsync();
        } 

        public Task SaveStock(Stock stock)
        {
            this._context.Stocks.Add(stock);
        }
    }
}
