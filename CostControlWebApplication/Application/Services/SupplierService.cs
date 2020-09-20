using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Application.Services.Dtos;
using System;

namespace CostControlWebApplication.Services
{
    public class SupplierService :  BaseService
    {
        public SupplierService(IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
           
          
        }
   
        
        public IPagingList<SupplierDto> GetPagingList(SupplierQueryRequest filterRequest)
        {
            throw new NotImplementedException();
        }
    }
}
