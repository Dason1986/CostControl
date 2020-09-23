using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Domain;
using System;

namespace CostControlWebApplication.Application.Data
{
    public class ProjectRepository : Repository
    {
        public ProjectRepository(RepositoryContextOptions options) : base(options)
        {
            dataAccessorProjectInfo = CreateWrapper<ProjectInfo>();
            dataAccessorVIProjectInfo = CreateWrapper<VIProjectInfo>();
        }
        IDataAccessor<ProjectInfo> dataAccessorProjectInfo;
        IDataAccessor<VIProjectInfo> dataAccessorVIProjectInfo;
        internal void Add(ProjectInfo entity)
        {
            dataAccessorProjectInfo.Add(entity);
        }

        public IPagingList<VIProjectInfo> PagingList(ISpecification<VIProjectInfo> specification)
        {
            int total = 0;
            return dataAccessorVIProjectInfo.PageList(specification, ref total).ProjectedAsPagingList(total,specification);
        }
    }
}
