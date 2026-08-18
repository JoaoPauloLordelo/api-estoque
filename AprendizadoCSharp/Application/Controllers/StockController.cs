using AprendizadoCSharp.Domain.Stock.Models;
using AprendizadoCSharp.Infrasctucture.Context;
using Microsoft.AspNetCore.Mvc;

namespace AprendizadoCSharp.Application.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext ApplicationDBContext)
        {
            this._context = ApplicationDBContext;
        }

        [HttpGet]
        public IActionResult GetAllStocks()
        {
            List<Stock> stocks = _context.Stocks.ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetStock([FromRoute] long id)
        {
            Stock stock = _context.Stocks.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);

        }
    }
}
