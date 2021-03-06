﻿using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using BingoX.Domain;
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
            dataAccessorProjectCalculation = CreateWrapper<ProjectCalculation>();
            dataAccessorProjectCalculationDetail = CreateWrapper<ProjectCalculationDetail>();
        }



        IDataAccessor<ProjectStandingbook> dataAccessorProjectStandingbook;

        IDataAccessor<ProjectCalculation> dataAccessorProjectCalculation;
        IDataAccessor<ProjectCalculationDetail> dataAccessorProjectCalculationDetail;
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

        public void AddCalculationDetail(ProjectCalculationDetail entity)
        {
            dataAccessorProjectCalculationDetail.Add(entity);
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

        internal ProjectAboutFile GetFile(long createFileId)
        {
            return dataAccessorAboutFiles.GetId(createFileId);
        }

        public void UpdateProcurement(ProjectProcurement entity)
        {
            dataAccessorProjectProcurement.Update(entity);
        }

        public ProjectProcurement GetProcurement(long id)
        {
            return dataAccessorProjectProcurement.GetId(id);
        }

        public void Update(ProjectAboutFile entity)
        {
            dataAccessorAboutFiles.Update(entity);
        }
        public void UpdateMaster(ProjectMaster entity)
        {
            dataAccessorProjectMaster.Update(entity);
        }
        public void AddMaster(ProjectMaster entity)
        {
            dataAccessorProjectMaster.Add(entity);
        }
        public void AddCalculation(ProjectCalculation entity)
        {
            dataAccessorProjectCalculation.Add(entity);
        }
        public void AddTargetCost(ProjectTargetCost entity)
        {
            dataAccessorProjectTargetCost.Add(entity);
        }
     
        public ProjectCalculation GetCalculation(long id)
        {
            return dataAccessorProjectCalculation.Get(n => n.ProjectId == id);
        }
        public VIProjectCalculation GetVICalculation(long id)
        {
            return CreateWrapper<VIProjectCalculation>().GetId(id);
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
        public IList<ProjectAboutFile> GetFiles(long[] ids)
        {
            return dataAccessorAboutFiles.Where(n => ids.Contains(n.ID)).OrderByDescending(n => n.ID).ToList();
        }

        public IList<VIProjectProcurement> GetProcurements(long id)
        {
            return dataAccessorVIProjectProcurement.Where(n => n.ProjectId == id).OrderByDescending(n => n.ID).ToList();
        }

        public IList<ProcurementBQItem> GetProcurementBQItems(long id)
        {
            return CreateWrapper<ProcurementBQItem>().Where(n => n.ProcurementId == id).OrderByDescending(n => n.ID).ToList();
        }

        public void AddStandingbook(ProjectStandingbook entity)
        {
            dataAccessorProjectStandingbook.Add(entity);
        }

        public IPagingList<T> PagingList<T>(ISpecification<T> specification) where T : IEntity<T>
        {
            int total = 0;
            return CreateWrapper<T>().PageList(specification, ref total).ProjectedAsPagingList(total, specification);
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
