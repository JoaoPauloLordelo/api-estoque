using AprendizadoCSharp.Application.DTOs.Stocks;
using AprendizadoCSharp.Application.Mappers;
using AprendizadoCSharp.Domain.Stocks.Filters;
using AprendizadoCSharp.Domain.Stocks.Interfaces.Repositories;
using AprendizadoCSharp.Domain.Stocks.Models;
using Microsoft.AspNetCore.Mvc;

namespace AprendizadoCSharp.Application.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRespository _stockRepository;
        public StockController(IStockRespository stockRepository)
        {
            this._stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStocks([FromQuery] StockQueryParams queryParams)
        {
            List<GetStockDTO> stocks = (await this._stockRepository.GetAllStock(queryParams)).Select(s => s.toGetStockDTO()).ToList();
            return Ok(stocks);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetStock([FromRoute] long id)
        {
            Stock? stock = await this._stockRepository.GetStock(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.toGetStockDTO());

        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockDTO stockDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Stock stock = stockDTO.toStockFromCreateDTO();
            await this._stockRepository.SaveStock(stock);
            await this._stockRepository.SaveChanges();
            return CreatedAtAction(nameof(GetStock), new { id = stock.Id }, stock.toGetStockDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateStock([FromRoute] long id, [FromBody] UpdateStockDTO stockDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Stock? stock = await this._stockRepository.GetStock(id);
            if (stock == null)
            {
                return NotFound();
            }

            stock.updateStockFromDTO(stockDTO);
            await this._stockRepository.SaveChanges();
            return Ok(stock.toGetStockDTO());

        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteStock([FromRoute] long id)
        {
            Stock? stock = await this._stockRepository.GetStock(id);
            if (stock == null)
            {
                return NotFound();
            }
            this._stockRepository.DeleteStock(stock);
            await _stockRepository.SaveChanges();
            
            return NoContent();

        }

    }
}
