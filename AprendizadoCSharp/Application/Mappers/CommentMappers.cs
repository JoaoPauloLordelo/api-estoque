using AprendizadoCSharp.Application.DTOs.Stocks;
using AprendizadoCSharp.Domain.Stocks.Models;

namespace AprendizadoCSharp.Application.Mappers
{
    public static class CommentMappers
    {
        public static GetCommentDTO toGetCommentDTO(this Comment comment)
        {
            return new GetCommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId,
                Title = comment.Title
            };
        }

        public static Comment toCommentFromDTO(this CreateCommentDTO dto)
        {
            return new Comment
            {
                Content = dto.Content,
                StockId = dto.StockId,
                Title = dto.Title
            };
        }
    }
}
