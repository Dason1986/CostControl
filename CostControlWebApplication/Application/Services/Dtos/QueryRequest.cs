namespace CostControlWebApplication.Services
{
    public class QueryRequest
    {
        public int PageIndex { get; set; }
        public int PageNo { get; set; }

        public int PageSize { get; set; } = 10;
    }
}
