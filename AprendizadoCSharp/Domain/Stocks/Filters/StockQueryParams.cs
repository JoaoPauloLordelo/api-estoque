namespace AprendizadoCSharp.Domain.Stocks.Filters
{
    public class StockQueryParams
    {
        public string? companyName { get; set; } = null;
        public string? symbol { get; set; } = null;
        public string? sortBy { get; set; } = null;
        public bool isDescending { get; set; } = false;
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 20;
    }
}
