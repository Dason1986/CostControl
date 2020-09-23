using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;

namespace CostControlWebApplication.Services
{
    public class SupplierService : BaseService
    {
        private readonly IRepository<Supplier> repository;

        public SupplierService(IRepository<Supplier> repository, IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;
        }

        public void AddSuppiler(SupplierDto dto)
        {
            Supplier entity = new Supplier();
            entity.Created(this); 
            entity.Name = dto.Name;
            entity.ManName = dto.ManName;
            entity.ManTel = dto.ManTel;
            entity.OfficeTel = dto.OfficeTel;
            entity.Address = dto.Address;
            entity.State = dto.State == "1" ? CommonState.Enabled : CommonState.Disabled;
            repository.Add(entity);
            repository.UnitOfWork.Commit();
        }
        public void UpdateSuppiler(SupplierDto dto)
        {
            Supplier entity = repository.GetId(dto.ID);
            entity.Modified(this);
            entity.ManName = dto.ManName;
            entity.ManTel = dto.ManTel;
            entity.OfficeTel = dto.OfficeTel;
            entity.Address = dto.Address;
            entity.State = dto.State == "1" ? CommonState.Enabled : CommonState.Disabled;
            repository.Update(entity);
            repository.UnitOfWork.Commit();
        }
        public SupplierDto Get(long id)
        {
            return repository.GetId(id).ProjectedAs<SupplierDto>();
        }
        public IPagingList<SupplierDto> GetPagingList(SupplierQueryRequest filterRequest)
        {
            Specification<Supplier> specification = new Specification<Supplier>();
            specification.SetPage(filterRequest);
            if (!string.IsNullOrEmpty(filterRequest.Name)) specification.And(n => n.Name.Contains(filterRequest.Name));
            if (!string.IsNullOrEmpty(filterRequest.ManName)) specification.And(n => n.ManName.Contains(filterRequest.ManName));
            int total = 0;
            var list = repository.PageList(specification, ref total);
            return list.ProjectedAsPagingList<SupplierDto>(total, filterRequest);

        }
    }
}
