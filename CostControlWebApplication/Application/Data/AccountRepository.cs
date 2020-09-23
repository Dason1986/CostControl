using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CostControlWebApplication.Application.Data
{
    public class AccountRepository : Repository
    {
        public AccountRepository(RepositoryContextOptions options) : base(options)
        {
            dataAccessorAccountUser = CreateWrapper<AccountUser>();
        }
        IDataAccessor<AccountUser> dataAccessorAccountUser;
        public AccountUser Get(string uid, string pwd)
        {
            return dataAccessorAccountUser.Get(n => n.Account == uid && n.Pwd == pwd);
        }

        public IPagingList<AccountUser> GetPagingList(ISpecification<AccountUser> specification)
        {
            int total = 0;
            return dataAccessorAccountUser. PageList(specification, ref total).ProjectedAsPagingList(total, specification);
        }

        public void AddUser(AccountUser user)
        {
            dataAccessorAccountUser.Add(user);
        }

        public AccountUser GetUser(string account)
        {
            return dataAccessorAccountUser.Get(n => n.Account == account);
        }

        public AccountUser GetUserById(long userid)
        {
            return dataAccessorAccountUser.GetId(userid);
        }

        public void DeleteUser(AccountUser user)
        {
            dataAccessorAccountUser.Delete(user);
        }

        public void UpdateUser(AccountUser user)
        {
            dataAccessorAccountUser.Update(user);
        }
    }
}
