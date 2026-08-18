using AprendizadoCSharp.Application.DTOs.Stock;
using AprendizadoCSharp.Application.Mappers;
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
            List<GetStockDTO> stocks = _context.Stocks.ToList().Select(s => s.toGetStockDTO()).ToList();
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
            return Ok(stock.toGetStockDTO());

        }

        [HttpPost]
        public IActionResult CreateStock([FromBody] CreateStockDTO stockDTO)
        {
            Stock stock = stockDTO.toStockFromCreateDTO();
            _context.Stocks.Add(stock);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStock), new { id = stock.Id }, stock.toGetStockDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStock([FromRoute] long id, [FromBody] UpdateStockDTO stockDTO) 
        {
            Stock? stock = _context.Stocks.FirstOrDefault(s => s.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            stock.updateStockFromDTO(stockDTO);
            _context.SaveChanges();
            return Ok(stock.toGetStockDTO());

        }
    }
}
