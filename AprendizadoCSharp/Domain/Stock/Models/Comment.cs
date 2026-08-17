using System.Runtime.CompilerServices;

namespace AprendizadoCSharp.Domain.Stock.Models
{ 
    public class Comment
    {
        public int Id { get; set; }
        public string Title{ get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public long StockId { get; set; }
        public Stock stock { get; set; }

    }
}
