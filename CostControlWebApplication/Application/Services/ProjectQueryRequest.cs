namespace CostControlWebApplication.Services
{
    public class ProjectQueryRequest : QueryRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
