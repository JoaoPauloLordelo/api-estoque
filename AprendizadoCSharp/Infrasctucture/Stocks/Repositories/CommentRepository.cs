using AprendizadoCSharp.Domain.Stocks.Interfaces.Repositories;
using AprendizadoCSharp.Domain.Stocks.Models;
using AprendizadoCSharp.Infrasctucture.Context;
using Microsoft.EntityFrameworkCore;

namespace AprendizadoCSharp.Infrasctucture.Stocks.Repositories{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            List<Comment> comments = await this._context.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            Comment? comment = await this._context.Comments.FindAsync(id);
            return comment;
        }

        public async Task SaveChanges()
        {
            await this._context.SaveChangesAsync();
        }

        public async Task SaveComment(Comment comment)
        {
            await this._context.Comments.AddAsync(comment);
        }
    }
}
