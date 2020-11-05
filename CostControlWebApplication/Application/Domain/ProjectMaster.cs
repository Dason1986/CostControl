using BingoX.Domain;
using CostControlWebApplication.Application;
using System;

namespace CostControlWebApplication.Domain
{
    public class VIProjectMaster : ProjectMaster, ISnowflakeEntity<VIProjectMaster>
    {
        public string ProjectMain { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string SetterName { get; set; }

        public string ManagerName { get; set; }

        public string ContractorsName { get; set; }
    }
    public class ProjectMaster : Entity, ISnowflakeEntity<ProjectMaster>, IDate
    {
        /// <summary>
        /// 項目編號A
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 項目名稱B
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 項目地址
        /// </summary>
        public string Address { get; set; }
 
        /// <summary>
        /// 定作人
        /// </summary>
        public long SetterId { get; set; }
        /// <summary>
        /// 承建商
        /// </summary>
        public long ContractorsId { get; set; }


        /// <summary>
        /// 第一分判J
        /// </summary>
        public long FirstId { get; set; }
        /// <summary>
        /// 第二分判K
        /// </summary>
        public long SecondId { get; set; }
        /// <summary>
        /// 第二分判K
        /// </summary>
        public long ThirdId { get; set; }
        /// <summary>
        /// 項目經理D
        /// </summary>
        public long ManagerId { get; set; }
        /// <summary>
        /// 開工時間
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// 開工時間
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        ///  項目类型
        /// </summary>
        public long ProjectMainId { get; set; }
        /// <summary>
        ///  公司
        /// </summary>
        public long CompanyId { get; set; }
        /// <summary>
        /// 備註AH
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 合同金額L
        /// </summary>
        public decimal ContractAmount { get; set; } 
        /// <summary>
        /// 預計開始日期
        /// </summary>
        public DateTime? EstimatedBeginDate { get; set; }
        /// <summary>
        /// 預計結束日期
        /// </summary>
        public DateTime? EstimatedEndDate { get; set; }
        public CommonState State { get; set; }
    }
}
