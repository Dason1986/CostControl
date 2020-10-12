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
            dataAccessorTargetCost = CreateWrapper<TargetCost>();
            dataAccessorTargetCostDetail = CreateWrapper<TargetCostDetail>();
        }


        IDataAccessor<TargetCostDetail> dataAccessorTargetCostDetail;
        IDataAccessor<TargetCost> dataAccessorTargetCost;
        public void Add(TargetCost entity)
        {
            dataAccessorTargetCost.Add(entity);
        }

        internal void AddDetail(TargetCostDetail entity)
        {
            throw new NotImplementedException();
        }

        internal bool ExistCode(string code)
        {
            throw new NotImplementedException();
        }

        public TargetCost GetId(long id)
        {
            return dataAccessorTargetCost.GetId(id);
        }

        public IList<TargetCostDetail> GetDetails(long id)
        {
            return dataAccessorTargetCostDetail.Where(n => n.TargetCostId == id);
        }

        public IPagingList<TargetCost> PagingList(ISpecification<TargetCost> specification)
        {
            int total = 0;
            return dataAccessorTargetCost.PageList(specification, ref total).ProjectedAsPagingList(total, specification);
        }
    }
}
