using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;
using System.Linq;

namespace CostControlWebApplication.Services
{
    public class ProjectProcurementService : BaseService
    {
        private readonly ProjectRepository repository;
        public ProjectProcurementService(ProjectRepository repository, IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;

        }
        public IPagingList<VIProjectProcurement> GetProcurements(ProjectQueryRequest queryRequest)
        {

            Specification<VIProjectProcurement> specification = EntityHelper.GetSpecification<VIProjectProcurement>();
            specification.SetPage(queryRequest);
            return repository.PagingList(specification);

        }
        public void Submit(ProjectProcurementDto dto)
        {
            if (dto.ID == 0 && !repository.ExistProcurement(dto.ID)) throw new BingoX.LogicException("編號不存在");
            var entity = dto.ProjectedAs<ProjectProcurement>();
            entity.State = ProcurementState.Submit;
            repository.UpdateProcurement(entity);
            repository.UnitOfWork.Commit();
        }
        public void Edit(ProjectProcurementDto dto)
        {
            if (dto.ID == 0   ) throw new BingoX.LogicException("編號不存在");
            var entity = repository.GetProcurement(dto.ID);
            if (entity==null) throw new BingoX.LogicException("編號不存在");
            dto.ProjectedAs(entity);  
            entity.State = ProcurementState.Enabled;
            var items = dto.Items.Where(n => n.Id == 0).Select(n =>
              {
                  var en = n.ProjectedAs<ProcurementBQItem>();
                  en.ProcurementId = entity.ID;
                  en.ProjectId = entity.ProjectId;
                  en.Created(this);
                  return en;
              }).ToList();
            repository.AddBQItems(items);
            repository.UpdateProcurement(entity);
            repository.UnitOfWork.Commit();
        }

        public ProjectProcurement GetDraftProcurement()
        {
            var entity = new ProjectProcurement();
            entity.State = ProcurementState.Draft;
            entity.Created(this);
            repository.AddProcurement(entity);
            repository.UnitOfWork.Commit();
            return entity;
        }

        public ProjectProcurementDto GetProcurement(long id)
        {
            var entity = repository.GetProcurement(id);
            if (entity == null) return null;
            var dto = entity.ProjectedAs<ProjectProcurementDto>();
            if (dto == null) return dto;
            dto.Files = repository.GetProcurementFiles(id).ProjectedAsCollection<ProjectAboutFileDto>();
            dto.Items = repository.GetProcurementBQItems(id).ProjectedAsCollection<ProcurementBQItemDto>();
            return dto;
        }
    }


}
