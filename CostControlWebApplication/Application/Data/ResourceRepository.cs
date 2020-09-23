using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CostControlWebApplication.Application.Data
{
    public class ResourceRepository : Repository
    {
        public ResourceRepository(RepositoryContextOptions options) : base(options)
        {
            dataAccessorBasicData = CreateWrapper<BasicData>();
            dataAccessorSupplier = CreateWrapper<Supplier>();
            dataAccessorAccountUser = CreateWrapper<AccountUser>();
        }
        IDataAccessor<BasicData> dataAccessorBasicData;
        IDataAccessor<Supplier> dataAccessorSupplier; 
        IDataAccessor<AccountUser> dataAccessorAccountUser; 
        public IList<BasicData> GetBasicData()
        {
            return dataAccessorBasicData.QueryAll();
        }
        public IList<Supplier> GetSupplier()
        {
            return dataAccessorSupplier.Where(n => n.State == CommonState.Enabled);
        }

        public IList<AccountUser> GetUser()
        {
            return dataAccessorAccountUser.Where(n=>n.State== CommonState.Enabled&& n.RoleType==  RoleType.Staffer);
        }
    }
}
