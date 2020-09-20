using BingoX.DataAccessor.SqlSugar;
using SqlSugar;

namespace CostControlWebApplication.Application.Data
{
    public class SqlSugarDbBoundedContext : SqlSugarDbContext
    {
        public SqlSugarDbBoundedContext(ConnectionConfig config) : base(config)
        {
        }
    }
}
