using BingoX.Domain;
using System;

namespace CostControlWebApplication.Domain
{
    public class VIProjectInfo : ProjectInfo, BingoX.Domain.ISnowflakeEntity<VIProjectInfo>
    {



        public string SupremeManagerName { get; set; }

        public string ManagerName { get; set; }
        public string SetterName { get; set; }
        public string ProjectMain { get; set; }


        public string ContractorsName { get; set; }
        public string ContractType { get; set; }
        public string SettlementMethod { get; set; }
        /// <summary>
        /// 大判/分判  承接类型 
        /// </summary>
        public string Undertaking { get; set; }
        /// <summary>
        /// 商業/政府/住宅 项目类型
        /// </summary>
        public string ProjectType { get; set; }

        /// <summary>
        /// 現金流入S
        /// </summary>
        public decimal CashInAmount { get; set; }
        /// <summary>
        /// 現金流出T
        /// </summary>
        public decimal CashOutAmount { get; set; }
        /// <summary>
        /// 應收賬款X
        /// </summary>
        public decimal ReceivableAmount { get; set; }
        /// <summary>
        /// 應付賬款Y
        /// </summary>
        public decimal PayableAmount { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
    public class ProjectInfo : ISnowflakeEntity<ProjectInfo>, IAuditCreated, IAuditModified
    {
        public long ID { get; set; }

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
        /// 最終責任人D1
        /// </summary>
        public long SupremeManagerId { get; set; }
        /// <summary>
        /// 定作人
        /// </summary>
        public long SetterId { get; set; }
        /// <summary>
        /// 項目經理D
        /// </summary>
        public long ManagerId { get; set; }
        /// <summary>
        /// 承建商I
        /// </summary>
        public long ContractorsId { get; set; }
        /// <summary>
        /// 項目主體
        /// </summary>
        public long ProjectMainId { get; set; }

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
        /// 目標毛利率M（%）
        /// </summary>
        public decimal TargetGrossProfitRate { get; set; }
        /// <summary>
        /// 核算毛利率N（%）
        /// </summary>
        public decimal AccountingGrossProfitRate { get; set; }
        /// <summary>
        /// 完工百分比E（%）
        /// </summary>
        public decimal CompletionRatio { get; set; }
        /// <summary>
        /// 合同金額L
        /// </summary>
        public decimal ContractAmount { get; set; }

        /// <summary>
        /// 必需上传審批單
        /// </summary>
        public bool MustApprovelFile { get; set; }
        /// <summary>
        /// 成本金額L
        /// </summary>
        public decimal CostAmount { get; set; }
        /// <summary>
        /// 後加金額L1
        /// </summary>
        public decimal AdditionalAmount { get; set; }
        /// <summary>
        /// 結算金額R
        /// </summary>
        public decimal BalanceAmount { get; set; }

        /// <summary>
        /// 保固應收Z
        /// </summary>
        public decimal SecuringAmount { get; set; }
        /// <summary>
        /// 保固金比例
        /// </summary>
        public decimal SecuringAmountRate { get; set; }
        /// <summary>
        /// 保固金比例
        /// </summary>
        public decimal SecuringPayableAmount { get; set; }
        /// <summary>
        /// 預計項目應收V
        /// </summary>
        public decimal EstimatedProjctReceivableAmount { get; set; }
        /// <summary>
        /// 預計項目應付W
        /// </summary>
        public decimal EstimatedProjctPayableAmount { get; set; }
        /// <summary>
        /// 大判/分判  承接类型 
        /// </summary>
        public long UndertakingId { get; set; }
        /// <summary>
        /// 商業/政府/住宅 项目类型
        /// </summary>
        public long ProjectTypeId { get; set; }
        /// <summary>
        /// 備註AH
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 開工時間
        /// </summary>
        public DateTime? BeginDate { get; set; }
        /// <summary>
        /// 估算的開工時間
        /// </summary>
        public DateTime? EstimatedBeginDate { get; set; }
        /// <summary>
        /// 開工時間
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 估算的開工時間
        /// </summary>
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Created { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Modified { get; set; }

        public ProjectState State { get; set; }
    }
    public enum ProjectState
    {
        Abnormal = -1,
        None = 0,
        Progress = 1,
        Complete = 10,
    }
    public enum CommonState
    {
        /// <summary>
        /// 未启用
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// 启用
        /// </summary>
        Enabled = 1,
        Deleted = -1
    }
}
