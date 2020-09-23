using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;

namespace CostControlWebApplication.Services
{
  
    public class ProjectService : BaseService
    {
        private readonly ProjectRepository repository;

        public ProjectService(ProjectRepository repository, IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;
        }
        public void Add(ProjectInfoDto dto)
        {
            ProjectInfo entity = dto.ProjectedAs<ProjectInfo>();

            entity.Created(this);
            repository.Add(entity);
            repository.UnitOfWork.Commit();
        }
        public IPagingList<VIProjectInfo> GetProjects(ProjectQueryRequest queryRequest)
        {
           
                Specification<VIProjectInfo> specification = new Specification<VIProjectInfo>();
                specification.SetPage(queryRequest);
            return repository.PagingList(specification);
            //return new PagingList<VIProjectInfo>(new VIProjectInfo[] {
            //    new VIProjectInfo {
            //    Code= "MII-2020001",
            //    Name= "項目名稱B" ,
            //    ManagerName="張三",
            //    SupremeManagerName="李四",
            //    ContractType="政府",
            //    Undertaking="分判",
            //    ProjectType="政府",
            //    Address="黑沙XXXXX路XX號",
            //    ProjectMain="裝修工程",
            //    SetterName="王五",
            //    ContractorsName="XXX承建商",
            //    FirstName="分判J",
            //    SecondName="分判K",
            //    ContractAmount=23000000m,
            //    CashInAmount=1233351.75m,
            //    CashOutAmount=154635.18m,
            //    PayableAmount=10468130.93m,
            //    ReceivableAmount=6083352.90m,
            //    CostAmount=20000000m,
            //    BeginDate=new DateTime(2019,1,2),
            //    EndDate=new DateTime(2020,7,2),
            //    TargetGrossProfitRate=6.17m,
            //    AccountingGrossProfitRate=6.17m,
            //    CompletionRatio=10m,
            //    State= ProjectState.Progress,
            //} ,
            //      new VIProjectInfo {
            //    Code= "MII-2020002",
            //    Name= "項目名稱C" ,
            //    ManagerName="張三",
            //    SupremeManagerName="李四",
            //    ContractType="私人",
            //    Undertaking="分判",
            //    ProjectType="住宅",
            //    Address="黑沙XXXXX路XX號",
            //    ProjectMain="建築設計（含機電+結構+消防+供排水）",
            //    SetterName="王五",
            //    ContractorsName="XXX承建商",
            //    FirstName="分判J",
            //    SecondName="分判K",
            //    TargetGrossProfitRate=6.17m,
            //    AccountingGrossProfitRate=6.17m,
            //    CompletionRatio=10m,
            //    State= ProjectState.Progress,
            //},  new VIProjectInfo {
            //    Code= "MII-2020003",
            //    Name= "項目名稱D" ,
            //    ManagerName="張三",
            //    SupremeManagerName="李四",
            //    ContractType="政府",
            //    Undertaking="大判",
            //    ProjectType="商業",
            //    Address="黑沙XXXXX路XX號",
            //    ProjectMain="維修及保養項目",
            //    SetterName="王五",
            //    ContractorsName="XXX承建商",
            //    FirstName="分判J",
            //    SecondName="分判K",
            //    TargetGrossProfitRate=6.17m,
            //    AccountingGrossProfitRate=6.17m,
            //    CompletionRatio=10m,
            //    State= ProjectState.None,
            //}



            //}, 0, 10, 11);
        }
    }


}
