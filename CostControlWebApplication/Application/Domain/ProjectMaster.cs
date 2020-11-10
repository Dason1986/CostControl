using BingoX.Domain;
using CostControlWebApplication.Application;
using System;

namespace CostControlWebApplication.Domain
{
    public class VIProjectMaster : ProjectMaster, ISnowflakeEntity<VIProjectMaster>, IProjectEntity
    {
        public string ProjectMain { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }

        public string SetterName { get; set; }

        public string ManagerName { get; set; }
        public string CreateFileName { get; set; }
        public string CompanyName { get; set; }
        public string ContractorsName { get; set; }
        public string ContractType { get; set; }
        public string ProjectType { get; set; }
        public string SettlementMethod { get; set; }
        public string Undertaking { get; set; }
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
        /// 立项目文件
        /// </summary>
        public long CreateFileId { get; set; }
        /// <summary>
        /// 承建商
        /// </summary>
        public long ContractorsId { get; set; }

        /// <summary>
        /// 大判/分判  承接类型 
        /// </summary>
        public long UndertakingId { get; set; }
        /// <summary>
        /// 商業/政府/住宅 項目类型
        /// </summary>
        public long ProjectTypeId { get; set; }
 

        /// <summary>
        /// 合約類別
        /// </summary>
        public long ContractTypeId { get; set; }

        /// <summary>
        /// 合約結算方式
        /// </summary>
        public long SettlementMethodId { get; set; }
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
