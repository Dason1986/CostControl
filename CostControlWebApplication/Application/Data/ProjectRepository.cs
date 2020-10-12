using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CostControlWebApplication.Application.Data
{
    public class ProjectRepository : Repository
    {
        public ProjectRepository(RepositoryContextOptions options) : base(options)
        {
            dataAccessorProjectInfo = CreateWrapper<ProjectInfo>();
            dataAccessorProjectCostIn = CreateWrapper<ProjectCostIn>();
            dataAccessorProjectCostOut = CreateWrapper<ProjectCostOut>();
            dataAccessorVIProjectInfo = CreateWrapper<VIProjectInfo>();
            dataAccessorAboutFiles = CreateWrapper<ProjectAboutFile>();
        }
        IDataAccessor<ProjectInfo> dataAccessorProjectInfo;
        IDataAccessor<ProjectCostIn> dataAccessorProjectCostIn;
        IDataAccessor<ProjectCostOut> dataAccessorProjectCostOut;
        IDataAccessor<VIProjectInfo> dataAccessorVIProjectInfo;
        IDataAccessor<ProjectAboutFile> dataAccessorAboutFiles;

        public bool ExistCode(string code)
        {
            return dataAccessorProjectInfo.Exist(x => x.Code == code);
        }

        public void Add(ProjectInfo entity)
        {
            dataAccessorProjectInfo.Add(entity);
        }

        public IPagingList<VIProjectInfo> PagingList(ISpecification<VIProjectInfo> specification)
        {
            int total = 0;
            return dataAccessorVIProjectInfo.PageList(specification, ref total).ProjectedAsPagingList(total, specification);
        }
        public IPagingList<VIProjectCostIn> PagingList(ISpecification<VIProjectCostIn> specification)
        {
            int total = 0;
            return CreateWrapper<VIProjectCostIn>().PageList(specification, ref total).ProjectedAsPagingList(total, specification);
        }
        public IPagingList<VIProjectCostOut> PagingList(ISpecification<VIProjectCostOut> specification)
        {
            int total = 0;
            return CreateWrapper<VIProjectCostOut>().PageList(specification, ref total).ProjectedAsPagingList(total, specification);
        }
        public IList<ProjectCostIn> ProjectCostInList(long projectId)
        {

            return dataAccessorProjectCostIn.Where(n => n.ProjectId == projectId);
        }
        public IList<ProjectCostOut> ProjectCostOutList(long projectId)
        {

            return dataAccessorProjectCostOut.Where(n => n.ProjectId == projectId);
        }

        public decimal GetProjectExpendAmount(long projectId)
        {
            return ProjectCostOutList(projectId).Sum(n => n.ExpendAmount);
        }

        public VIProjectInfo GetProject(long id)
        {
            return dataAccessorVIProjectInfo.GetId(id);
        }

        public void AddCostin(ProjectCostIn entity)
        {
            dataAccessorProjectCostIn.Add(entity);
        }

        public void AddCostout(ProjectCostOut entity)
        {
            dataAccessorProjectCostOut.Add(entity);
        }
        public void UpdateCostout(ProjectCostOut entity)
        {
            dataAccessorProjectCostOut.Update(entity);
        }
        public IList<ProjectAboutFile> AboutFilesList(long id)
        {
            return dataAccessorAboutFiles.Where(n => n.ProjectId == id);
        }
        public void AddAboutFile(ProjectAboutFile entity)
        {
            dataAccessorAboutFiles.Add(entity);
        }

        public ProjectCostOut GetCostout(long id)
        {
            return dataAccessorProjectCostOut.GetId(id);
        }

        public ProjectCostIn GetCostIn(long id)
        {
            return dataAccessorProjectCostIn.GetId(id);
        } 
        public void UpdateCostIn(ProjectCostIn entity)
        {
            dataAccessorProjectCostIn.Update(entity);
        }
    }
}
