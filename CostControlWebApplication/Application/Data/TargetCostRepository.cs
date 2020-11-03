using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Domain;
using System;
using System.Collections.Generic;

namespace CostControlWebApplication.Application.Data
{
    public class TargetCostRepository : Repository
    {
        public TargetCostRepository(RepositoryContextOptions options) : base(options)
        {
            dataAccessorTargetCost = CreateWrapper<ProjectTargetCost>();
            dataAccessorTargetCostDetail = CreateWrapper<ProjectTargetCostDetail>();
            dataAccessorVITargetCostDetail = CreateWrapper<VIProjectTargetCost>();
        }


        IDataAccessor<ProjectTargetCostDetail> dataAccessorTargetCostDetail;
        IDataAccessor<VIProjectTargetCost> dataAccessorVITargetCostDetail;
        IDataAccessor<ProjectTargetCost> dataAccessorTargetCost;
        public void Add(ProjectTargetCost entity)
        {
            dataAccessorTargetCost.Add(entity);
        }

        internal void AddDetail(ProjectTargetCostDetail entity)
        {
            throw new NotImplementedException();
        }

        internal bool ExistCode(string code)
        {
            throw new NotImplementedException();
        }

        public ProjectTargetCost GetId(long id)
        {
            return dataAccessorTargetCost.GetId(id);
        }

        public IList<ProjectTargetCostDetail> GetDetails(long id)
        {
            return dataAccessorTargetCostDetail.Where(n => n.TargetCostId == id);
        }

        public IPagingList<VIProjectTargetCost> PagingList(ISpecification<VIProjectTargetCost> specification)
        {
            int total = 0;
            return dataAccessorVITargetCostDetail.PageList(specification, ref total).ProjectedAsPagingList(total, specification);
        }
    }
}
