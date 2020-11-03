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
    public class TargetCostService : BaseService
    {
        private readonly TargetCostRepository repository;
        private readonly ISerialNumberProvider serialNumberProvider;

        public TargetCostService(TargetCostRepository repository, ISerialNumberProvider serialNumberProvider, IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;
            this.serialNumberProvider = serialNumberProvider;
        }


        public IPagingList<ProjectTargetCostListItmeDto> GetTargetCosts(ProjectQueryRequest queryRequest)
        {
            var specification = new Specification<VIProjectTargetCost>();
            if (!string.IsNullOrEmpty(queryRequest.Code)) specification.And(n => n.Code.Contains(queryRequest.Code));
            if (!string.IsNullOrEmpty(queryRequest.Name)) specification.And(n => n.Name.Contains(queryRequest.Name));
            specification.SetPage(queryRequest);

            return repository.PagingList(specification).ProjectedAsPagingList<ProjectTargetCostListItmeDto>();

        }

        public ProjectTargetCostDto Get(long id)
        {
            var dto = repository.GetId(id).ProjectedAs<ProjectTargetCostDto>();
            if (dto == null) return dto;
            dto.Details = new TargetCostDetailDto[] { };
            dto.Summary = new TargetCostSummaryItem[] {
             new TargetCostSummaryItem{ Id=1, Title="匯總表" },
             new TargetCostSummaryItem{ Id=2, No="A", Title="專業分包費", Children=new TargetCostSummaryItem[]{
                        new TargetCostSummaryItem{Id=21,Title="　準備工作" },
                        new TargetCostSummaryItem{Id=22, Title="　供排水工程" },
                        new TargetCostSummaryItem{Id=23, Title="　強弱電工程" },
                        new TargetCostSummaryItem{Id=24, Title="　通風及空調工程" },
                        new TargetCostSummaryItem{Id=25, Title="　消防工程" },
                        new TargetCostSummaryItem{Id=26, Title="　後加/後減工程" },
             } },
               new TargetCostSummaryItem{ Id=3, No="B", Title="材料費" , Children=new TargetCostSummaryItem[]{
                        new TargetCostSummaryItem{ Id=31,Title="　主要飾面材料" },
                        new TargetCostSummaryItem{ Id=32,Title="　輔助性使用材料" },
             } },
               new TargetCostSummaryItem{ Id=4, No="C", Title="人工費" , Children=new TargetCostSummaryItem[]{
                        new TargetCostSummaryItem{Id=41, Title="　項目人力成本" },
                        new TargetCostSummaryItem{Id=42, Title="　項目工人工資" },
             } },
               new TargetCostSummaryItem{ Id=5, No="D", Title="管理費" , Children=new TargetCostSummaryItem[]{
                        new TargetCostSummaryItem{Id=51, Title="　項目管理雜費" },
                        new TargetCostSummaryItem{Id=52, Title="　項目應酬費" },
             } },
             new TargetCostSummaryItem{ Id=6, Title="合計",Price="N/A", Cost="N/A", Profits="N/A" , ProfitsRate="N/A"},
            };
            return dto;

        }

        public void Add(ProjectTargetCostDto dto)
        {
            ProjectTargetCost entity = dto.ProjectedAs<ProjectTargetCost>();

            entity.State = CommonState.Enabled;
            entity.Created(this);
            repository.Add(entity);
            repository.UnitOfWork.Commit();
        }
        public void Add(TargetCostDetailDto dto)
        {
            ProjectTargetCostDetail entity = dto.ProjectedAs<ProjectTargetCostDetail>();

            entity.Created(this);
            repository.AddDetail(entity);
            repository.UnitOfWork.Commit();
        }
        public IList<ProjectTargetCostDetail> GetDetails(long id)
        {
            return repository.GetDetails(id);
        }
    }


}
