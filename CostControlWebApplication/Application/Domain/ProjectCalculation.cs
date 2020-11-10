using BingoX.Domain;
using System;

namespace CostControlWebApplication.Domain
{
    public class ProjectCalculation : Entity, ISnowflakeEntity<ProjectCalculation>
    {
        public long ProjectId { get; set; }
        /// <summary>
        /// 人力成本
        /// </summary>
        public decimal HumanCost { get; set; }
        /// <summary>
        /// 工人工資
        /// </summary>
        public decimal Salary { get; set; }
        /// <summary>
        /// 管理成本
        /// </summary>
        public decimal  MangerCost { get; set; }
        /// <summary>
        /// 物料采购成本
        /// </summary>
        public decimal  MaterialCost { get; set; }
        /// <summary>
        /// 外判成本
        /// </summary>
        public decimal OutsourcingCost { get; set; }
        /// <summary>
        /// 管理成本
        /// </summary>
        public decimal OffsetMangerCost { get; set; }
        /// <summary>
        /// 物料采购成本
        /// </summary>
        public decimal OffsetMaterialCost { get; set; }
        /// <summary>
        /// 外判成本
        /// </summary>
        public decimal OffsetOutsourcingCost { get; set; }

    }
    public class VIProjectCalculation : ProjectCalculation, ISnowflakeEntity<VIProjectCalculation>, IProjectEntity
    {  
        /// <summary>
        /// 項目編號A
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 項目名稱B
        /// </summary>
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; } 

        public long ManagerId { get; }
        /// <summary>
        /// 開工時間
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// 開工時間
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 預計開始日期
        /// </summary>
        public DateTime? EstimatedBeginDate { get; set; }
        /// <summary>
        /// 預計結束日期
        /// </summary>
        public DateTime? EstimatedEndDate { get; set; }

    }
    public class ProjectCalculationDetail : Entity, ISnowflakeEntity<ProjectCalculationDetail>
    {
        public long ProjectId { get; set; }
        public long CalculationId { get; set; }
        public long ProcurementId { get; set; }
        public int OrderNo { get; set; }
        /// <summary>
        /// 合約金額
        /// </summary>
        public decimal ContractAmount { get; set; }
        /// <summary>
        /// B分判金額
        /// </summary>
        public decimal ProcurementAmount { get; set; }
        /// <summary>
        /// 暫估費用
        /// </summary>
        public decimal EstimateCost { get; set; }
        /// <summary>
        /// 預計目標毛利
        /// </summary>
        public decimal GrossMargin { get; set; }
        public string Remark { get; set; }
         


    }
}
