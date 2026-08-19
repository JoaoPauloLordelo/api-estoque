using AprendizadoCSharp.Application.DTOs.Stocks;
using AprendizadoCSharp.Application.Mappers;
using AprendizadoCSharp.Domain.Stocks.Interfaces.Repositories;
using AprendizadoCSharp.Domain.Stocks.Models;
using AprendizadoCSharp.Infrasctucture.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAllStocks()
        {
            List<GetStockDTO> stocks = (await _stockRepository.GetAllStock()).Select(s => s.toGetStockDTO()).ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStock([FromRoute] long id)
        {
            Stock? stock = await _stockRepository.GetStock(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.toGetStockDTO());

        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockDTO stockDTO)
        {
            Stock stock = stockDTO.toStockFromCreateDTO();
            await _stockRepository.SaveStock(stock);
            await _stockRepository.SaveChanges();
            return CreatedAtAction(nameof(GetStock), new { id = stock.Id }, stock.toGetStockDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock([FromRoute] long id, [FromBody] UpdateStockDTO stockDTO) 
        {
            Stock? stock = await _stockRepository.GetStock(id);
            if (stock == null)
            {
                return NotFound();
            }

            stock.updateStockFromDTO(stockDTO);
            await _stockRepository.SaveChanges();
            return Ok(stock.toGetStockDTO());

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] long id)
        {
            Stock? stock = await _stockRepository.GetStock(id);
            if (stock == null)
            {
                return NotFound();
            }
            _stockRepository.DeleteStock(stock);
            await _stockRepository.SaveChanges();
            
            return NoContent();

        }

    }
}
