using BingoX;
using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;
using System.Collections.Generic;

namespace CostControlWebApplication.Services
{
    public class BasicDataService : BaseService
    {

        public BasicDataService(IRepository<BasicData> repository, ResourceService resourceService, IBoundedContext bounded, IStaffeUser user): base(bounded, user)
        {
            this.repository = repository;
            this.resourceService = resourceService;
        }
        private readonly IRepository<BasicData> repository;
        private readonly ResourceService resourceService;
        public IList<BasicDataDto> Query(long parentId)
        {

            if (parentId == 0)
            {
                throw new LogicException("父级编号为空");
            }
            Specification<BasicData> specification = new Specification<BasicData>();
            specification.And(n => n.ParentId == parentId);


            specification.Orderby(n => n.IndexNo);
            specification.Orderby(n => n.DataValue);
            specification.PageSize = 100;
            int total = 0;
            var list = repository.PageList(specification,ref total).ProjectedAsCollection<BasicDataDto>();
            return list;
        }
        public IList<BasicDataDto> QueryRoot(string name = null, string groupCode = null)
        {


            Specification<BasicData> specification = new Specification<BasicData>();
            specification.And(n => n.ParentId == null);
            if (!string.IsNullOrEmpty(name)) specification.And(n => n.Name.Contains(name));
            if (!string.IsNullOrEmpty(groupCode)) specification.And(n => n.GroupCode.Contains(groupCode));
            specification.Orderby(n => n.ID);
            specification.PageSize = 100;
            int total = 0;
            var list = repository.PageList(specification, ref total).ProjectedAsCollection<BasicDataDto>();
            return list;
        }

        public BasicDataDto Get(long id)
        {
            throw new NotImplementedException();
        }

        public void AddBasicData(BasicDataDto dto)
        {
            long parentID = dto.ParentID;
            if (parentID <= 0) throw new LogicException("上级编号无效");
            if (string.IsNullOrEmpty(dto.Name)) throw new LogicException("名稱不能为空");
            if (string.IsNullOrEmpty(dto.DataValue)) throw new LogicException("数值不能为空");
            var entity = new BasicData
            {

                State = CommonState.Enabled,
                Name = dto.Name,
                ParentId = parentID,
                DataValue = dto.DataValue,
                Remark = dto.Remark
            };
            entity.Created(this);
            repository.Add(entity);
            repository.UnitOfWork.Commit();
            resourceService.ChangedBasics();
        }

        public void UpdateBasicData(BasicDataDto dto)
        {
            long parentID = dto.ParentID;
            if (parentID <= 0) throw new LogicException("上级编号无效");
            if (string.IsNullOrEmpty(dto.Name)) throw new LogicException("名稱不能为空");
            if (string.IsNullOrEmpty(dto.DataValue)) throw new LogicException("数值不能为空");
            BasicData entity = repository.GetId(dto.ID);
            if (entity == null) throw new LogicException("修改数据不存在");
            entity.DataValue = dto.DataValue;
            entity.IndexNo = dto.IndexNo;
            entity.Name = dto.Name;
            entity.Remark = dto.Remark;
            entity.State = dto.State ;
            entity.Modified(this);
            repository.Update(entity);
            repository.UnitOfWork.Commit();
            resourceService.ChangedBasics();
        }
    }
}
