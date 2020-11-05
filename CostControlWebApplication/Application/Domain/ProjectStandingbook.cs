using BingoX.Domain;
using CostControlWebApplication.Application;
using System;

namespace CostControlWebApplication.Domain
{
    public class ProjectStandingbook : Entity, ISnowflakeEntity<ProjectStandingbook>
    {

  
        public long ProjectId { get; set; }
       
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
        /// 商業/政府/住宅 項目类型
        /// </summary>
        public long ProjectTypeId { get; set; }
        /// <summary>
        /// 備註AH
        /// </summary>
        public string Remark { get; set; }

       

 
    }
}
