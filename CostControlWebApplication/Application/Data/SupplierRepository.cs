using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CostControlWebApplication.Application.Data
{
    public class SupplierRepository : Repository<Supplier>
    {
        public SupplierRepository(RepositoryContextOptions options) : base(options)
        {
            dataAccessor = CreateWrapper<Supplier>();
        }
        IDataAccessor<Supplier> dataAccessor;
        public void Update(Supplier entity)
        {
            dataAccessor.Update(entity);
        }

        public Supplier GetId(long id)
        {
            return dataAccessor.GetId(id);
        }

        public IList<Supplier> PageList(ISpecification<Supplier> specification, ref int total)
        {
            return dataAccessor.PageList(specification, ref total);
        }

        public void Add(Supplier entity)
        {
            dataAccessor.Add(entity);
        }
    }
}
