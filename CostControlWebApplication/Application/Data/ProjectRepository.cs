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
            dataAccessorProjectStandingbook = CreateWrapper<ProjectStandingbook>();
            dataAccessorProjectTargetCost = CreateWrapper<ProjectTargetCost>();
            dataAccessorProjectCostIn = CreateWrapper<ProjectCostIn>();
            dataAccessorProjectCostOut = CreateWrapper<ProjectCostOut>();
            dataAccessorVIProjectInfo = CreateWrapper<VIProjectStandingbook>();
            dataAccessorAboutFiles = CreateWrapper<ProjectAboutFile>();
            dataAccessorProjectMaster = CreateWrapper<ProjectMaster>();
            dataAccessorVIProjectMaster = CreateWrapper<VIProjectMaster>();
            dataAccessorProjectProcurement = CreateWrapper<ProjectProcurement>();
            dataAccessorVIProjectProcurement = CreateWrapper<VIProjectProcurement>();
            dataAccessorProjectProcurementBQItem = CreateWrapper<ProcurementBQItem>();
        }


        IDataAccessor<ProjectStandingbook> dataAccessorProjectStandingbook;

        IDataAccessor<ProjectTargetCost> dataAccessorProjectTargetCost;
        IDataAccessor<ProjectCostIn> dataAccessorProjectCostIn;
        IDataAccessor<ProjectCostOut> dataAccessorProjectCostOut;
        IDataAccessor<VIProjectStandingbook> dataAccessorVIProjectInfo;
        IDataAccessor<ProjectAboutFile> dataAccessorAboutFiles;
        IDataAccessor<ProjectMaster> dataAccessorProjectMaster;
        IDataAccessor<VIProjectMaster> dataAccessorVIProjectMaster;
        IDataAccessor<ProjectProcurement> dataAccessorProjectProcurement;
        IDataAccessor<VIProjectProcurement> dataAccessorVIProjectProcurement;
        IDataAccessor<ProcurementBQItem> dataAccessorProjectProcurementBQItem;

        public bool ExistCode(string code)
        {
            return dataAccessorProjectMaster.Exist(x => x.Code == code);
        }
        public bool ExistProcurement(long id)
        {
            return dataAccessorProjectProcurement.Exist(x => x.ID == id);
        }

        public void AddBQItems(List<ProcurementBQItem> items)
        {
            dataAccessorProjectProcurementBQItem.AddRange(items);
        }

        public Supplier GetSupplier(long companyId)
        {
            return CreateWrapper<Supplier>().GetId(companyId);
        }

        public void AddProcurement(ProjectProcurement entity)
        {
            dataAccessorProjectProcurement.Add(entity);
        }
        public void UpdateProcurement(ProjectProcurement entity)
        {
            dataAccessorProjectProcurement.Update(entity);
        }

        public ProjectProcurement GetProcurement(long id)
        {
            return dataAccessorProjectProcurement.GetId(id);
        }

        public void Add(ProjectMaster entity)
        {
            dataAccessorProjectMaster.Add(entity);
        }
        public void Add(ProjectTargetCost entity)
        {
            dataAccessorProjectTargetCost.Add(entity);
        }

        public IList<ProjectAboutFile> GetProcurementFiles(long id)
        {
            return dataAccessorAboutFiles.Where(n => n.ForeignID == id).OrderByDescending(n => n.ID).ToList();
        }
        public IList<ProjectCostIn> GetCostins(long id)
        {
            return CreateWrapper<ProjectCostIn>().Where(n => n.ProjectId == id).OrderByDescending(n => n.ID).ToList();
        }
        public IList<ProjectCostOut> GetCostouts(long id)
        {
            return CreateWrapper<ProjectCostOut>().Where(n => n.ProjectId == id).OrderByDescending(n => n.ID).ToList();
        }

        public IList<ProjectAboutFile> GetFiles(long id)
        {
            return dataAccessorAboutFiles.Where(n => n.ProjectId == id).OrderByDescending(n => n.ID).ToList();
        }

        public IList<VIProjectProcurement> GetProcurements(long id)
        {
            return dataAccessorVIProjectProcurement.Where(n => n.ProjectId == id).OrderByDescending(n => n.ID).ToList();
        }

        public IList<ProcurementBQItem> GetProcurementBQItems(long id)
        {
            return CreateWrapper<ProcurementBQItem>().Where(n => n.ProcurementId == id).OrderByDescending(n => n.ID).ToList();
        }

        public void Add(ProjectStandingbook entity)
        {
            dataAccessorProjectStandingbook.Add(entity);
        }
        public IPagingList<VIProjectProcurement> PagingList(Specification<VIProjectProcurement> specification)
        {
            int total = 0;
            return dataAccessorVIProjectProcurement.PageList(specification, ref total).ProjectedAsPagingList(total, specification);
        }
        public IPagingList<VIProjectMaster> PagingList(ISpecification<VIProjectMaster> specification)
        {
            int total = 0;
            return dataAccessorVIProjectMaster.PageList(specification, ref total).ProjectedAsPagingList(total, specification);
        }
        public IPagingList<VIProjectStandingbook> PagingList(ISpecification<VIProjectStandingbook> specification)
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


        public decimal GetProjectExpendAmount(long projectId)
        {
            return GetCostouts(projectId).Sum(n => n.ExpendAmount);
        }

        public VIProjectMaster GetProjectMaster(long id)
        {
            return dataAccessorVIProjectMaster.GetId(id);
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
        public IList<ProjectAboutFile> AboutFiless(long id)
        {
            return dataAccessorAboutFiles.Where(n => n.ProjectId == id).OrderByDescending(n => n.ID).ToList();
        }
        public void AddAboutFile(ProjectAboutFile entity)
        {
            dataAccessorAboutFiles.Add(entity);
        }

        public ProjectCostOut GetCostout(long id)
        {
            return dataAccessorProjectCostOut.GetId(id);
        }

        public VIProjectStandingbook GetStandingbook(long id)
        {
            return dataAccessorVIProjectInfo.GetId(id);
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
