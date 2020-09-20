using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Domain;
using System;

namespace CostControlWebApplication.Services
{
    public class TargetCostService :  BaseService
    {
        public TargetCostService(IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
           
        
        }
     

        public IPagingList<TargetCost> GetProjects(ProjectQueryRequest queryRequest)
        {
            throw new NotImplementedException();
        }
    }


}
