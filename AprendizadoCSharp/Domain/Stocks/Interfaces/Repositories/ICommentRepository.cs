using AprendizadoCSharp.Domain.Stocks.Models;

namespace AprendizadoCSharp.Domain.Stocks.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAllAsync();

        public Task<Comment?> GetByIdAsync(int id);

        public Task SaveComment(Comment comment);

        public Task SaveChanges();
    }
}
