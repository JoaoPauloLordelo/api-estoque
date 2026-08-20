using AprendizadoCSharp.Application.DTOs.Stocks;
using AprendizadoCSharp.Domain.Stocks.Filters;
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

        public void DeleteStock(Stock stock)
        {
            this._context.Stocks.Remove(stock);
        }

        public async Task<List<Stock>> GetAllStock(StockQueryParams queryParams)
        {
            IQueryable<Stock> query = _context.Stocks.AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryParams.companyName))
            {
                query = query.Where(s => (s.CompanyName.ToLower().Contains(queryParams.companyName.ToLower())));
            }
            if (!string.IsNullOrWhiteSpace(queryParams.symbol))
            {
                query = query.Where(s => (s.Symbol.ToLower().Contains(queryParams.symbol.ToLower())));
            }
            if (!string.IsNullOrWhiteSpace(queryParams.sortBy))
            {
                if (queryParams.sortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    query = queryParams.isDescending ? query.OrderByDescending(s => s.Symbol) : query.OrderBy(s => s.Symbol);
                }
            }
            int skipNumber = (queryParams.pageNumber - 1) * queryParams.pageSize;
            List<Stock> stocks = await query.Skip(skipNumber).Take(queryParams.pageSize).ToListAsync();

            return stocks;
        }

        public async Task<Stock?> GetStock(long id)
        {
            Stock? stock = await this._context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
            return stock;
        }

        public async Task SaveChanges()
        {
            await this._context.SaveChangesAsync();
        } 

        public async Task SaveStock(Stock stock)
        {
            await this._context.Stocks.AddAsync(stock);
        }
    }
}
