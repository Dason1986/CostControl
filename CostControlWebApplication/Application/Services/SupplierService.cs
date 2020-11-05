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

        public SupplierService(IRepository<Supplier> repository, ResourceService resourceService, IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;
            this.resourceService = resourceService;
        }
        private readonly IRepository<Supplier> repository;
        private readonly ResourceService resourceService;

        public void AddSuppiler(SupplierDto dto)
        {
            Supplier entity = new Supplier();
            if (dto.IsCompany)
            {
                if (string.IsNullOrEmpty(dto.Code)) throw new BingoX.LogicException("爲公司時編號不能爲空");
                if(repository.Exist(x => x.Code == dto.Code))throw new BingoX.LogicException("編號已經存在");
            }
            entity.Created(this);
            entity.Name = dto.Name;
            entity.ManName = dto.ManName;
            entity.ManTel = dto.ManTel;
            entity.OfficeTel = dto.OfficeTel;
            entity.Address = dto.Address;
            entity.Code = dto.Code;
            entity.IsCompany = dto.IsCompany;
            entity.State = dto.State == "1" ? CommonState.Enabled : CommonState.Disabled;
            repository.Add(entity);
            repository.UnitOfWork.Commit();
            resourceService.ChangedSupplier();
        }
        public void UpdateSuppiler(SupplierDto dto)
        {
            if (dto.IsCompany)
            {
                if (string.IsNullOrEmpty(dto.Code)) throw new BingoX.LogicException("爲公司時編號不能爲空");
                var exist = repository.Get(x => x.Code == dto.Code);
                if(exist!=null && exist.ID!= dto.ID) throw new BingoX.LogicException("編號已經存在");
            }
            Supplier entity = repository.GetId(dto.ID);
            if (entity == null) throw new BingoX.AspNetCore.NotFoundEntityException();
            entity.Modified(this);
            entity.ManName = dto.ManName;
            entity.ManTel = dto.ManTel;
            entity.OfficeTel = dto.OfficeTel;
            entity.Code = dto.Code;
            entity.IsCompany = dto.IsCompany;
            entity.Address = dto.Address;
            entity.State = dto.State == "1" ? CommonState.Enabled : CommonState.Disabled;
            repository.Update(entity);
            repository.UnitOfWork.Commit();
            resourceService.ChangedSupplier();
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
