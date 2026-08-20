using AprendizadoCSharp.Application.DTOs.Stocks;
using AprendizadoCSharp.Application.Mappers;
using AprendizadoCSharp.Domain.Stocks.Interfaces.Repositories;
using AprendizadoCSharp.Domain.Stocks.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace AprendizadoCSharp.Application.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repository;
        private readonly IStockRespository _stockRepository;

        public CommentController(ICommentRepository repository, IStockRespository stockRepository)
        {
            this._repository = repository;
            this._stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComents()
        {
            List<GetCommentDTO> comments = (await this._repository.GetAllAsync()).Select(c => c.toGetCommentDTO()).ToList();
            return Ok(comments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            Comment? comment = await this._repository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.toGetCommentDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentDTO commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stock? stock = await this._stockRepository.GetStock(commentDto.StockId);
            if (stock == null)
            {
                return BadRequest("O item Stock nao existe com o id enviado");
            }
            Comment comment = commentDto.toCommentFromDTO();
            await this._repository.SaveComment(comment);
            await this._repository.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.toGetCommentDTO());
        }
    }
}
