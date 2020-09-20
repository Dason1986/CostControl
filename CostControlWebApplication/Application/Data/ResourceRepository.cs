using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Domain;
using System.Collections.Generic;

namespace CostControlWebApplication.Application.Data
{
    public class ResourceRepository : Repository
    {
        public ResourceRepository(RepositoryContextOptions options) : base(options)
        {
            dataAccessorBasicData = CreateWrapper<BasicData>();
        }
        IDataAccessor<BasicData> dataAccessorBasicData;
        public IList<BasicData> GetAll()
        {
            return dataAccessorBasicData.QueryAll();
        }
    }
}
