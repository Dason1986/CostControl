using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CostControlWebApplication.Application.Services.Dtos
{
    public class ProjectStandingbookDto : IDto
    {
        public long ID { get; set; }

        /// <summary>
        /// 項目編號A
        /// </summary>
        [DisplayName("項目編號")]
        public string Code { get; set; }

        /// <summary>
        /// 項目名稱B
        /// </summary>
        [DisplayName("項目名稱")]
        public string Name { get; set; }
        /// <summary>
        /// 項目名稱B
        /// </summary>
        [DisplayName("項目地址")]
        public string Address { get; set; }

        /// <summary>
        /// 開工時間
        /// </summary>
        [DisplayName("開工時間")]
        public string BeginDate { get; set; }

        /// <summary>
        /// 預計開始日期
        /// </summary>
        [DisplayName("預計開始日期")]
        public string EstimatedBeginDate { get; set; }
        /// <summary>
        /// 預計結束日期
        /// </summary>
        [DisplayName("預計結束日期")]
        public string EstimatedEndDate { get; set; }
        /// <summary>
        /// 開工時間
        /// </summary>
        [DisplayName("結束時間")]
        public string EndDate { get; set; }

        [DisplayName("項目經理")]
        public string ManagerName { get; set; }
        [DisplayName("項目主體")]
        public string ProjectMain { get; set; }

        [DisplayName("定作人")]
        public string SetterName { get; set; }
        [DisplayName("承建商")]
        public string ContractorsName { get; set; }
        [DisplayName("第一分判")]
        public string FirstName { get; set; }
        [DisplayName("第二分判")]
        public string SecondName { get; set; }
        [DisplayName("第三分判")]
        public string ThirdName { get; set; }

        [DisplayName("合約類型")]
        public string ContractType { get; set; }
         

        /// <summary>
        /// 大判/分判  承接类型 
        /// </summary> 
        [DisplayName("承接类型")]
        public string Undertaking { get; set; }
        /// <summary>
        /// 商業/政府/住宅 項目类型
        /// </summary>
        [DisplayName("項目类型")]
        public string ProjectType { get; set; }

        /// <summary>
        /// 現金流入S
        /// </summary>
        [DisplayName("現金流入")]
        public decimal CashInAmount { get; set; }
        /// <summary>
        /// 現金流出T
        /// </summary>
        [DisplayName("現金流出")]
        public decimal CashOutAmount { get; set; }
        /// <summary>
        /// 應收賬款X
        /// </summary>
        [DisplayName("應收賬款")]
        public decimal ReceivableAmount { get; set; }
        /// <summary>
        /// 應付賬款Y
        /// </summary>
        [DisplayName("應付賬款")]
        public decimal PayableAmount { get; set; }

        /// <summary>
        /// 結算金額R
        /// </summary>
        [DisplayName("結算金額")]
        public string BalanceAmount { get; set; }




        /// <summary>
        /// 完工百分比E（%）
        /// </summary>
        [DisplayName("完工百分比")]
        public decimal CompletionRatio { get; set; }
        /// <summary>
        /// 合同金額L
        /// </summary>
        [DisplayName("合同金額")]
        public decimal ContractAmount { get; set; }
        /// <summary>
        /// 後加金額L1
        /// </summary>
        [DisplayName("後加金額")]
        public decimal AdditionalAmount { get; set; }
        /// <summary>
        /// 合約結算方式
        /// </summary>
        [DisplayName("合約結算方式")]
        public long SettlementMethodName { get; set; }

        /// <summary>
        /// 目標毛利率M（%）
        /// </summary>
        [DisplayName("目標毛利率")]
        public decimal TargetGrossProfitRate { get; set; }
        /// <summary>
        /// 核算毛利率N（%）
        /// </summary>
        [DisplayName("核算毛利率")]
        public decimal AccountingGrossProfitRate { get; set; }


        /// <summary>
        /// 保固應收Z
        /// </summary>
        [DisplayName("保固應收")]
        public decimal SecuringAmount { get; set; }
        /// <summary>
        /// 保固金比例
        /// </summary>
        [DisplayName("保固金比例")]
        public decimal SecuringAmountRate { get; set; }
        /// <summary>
        /// 保固應付
        /// </summary>
        [DisplayName("保固應付")]
        public decimal SecuringPayableAmount { get; set; }
        /// <summary>
        /// 預計項目應收V
        /// </summary>
        [DisplayName("預計項目應收")]
        public decimal EstimatedProjctReceivableAmount { get; set; }
        /// <summary>
        /// 預計項目應付W
        /// </summary>
        [DisplayName("預計項目應付")]
        public decimal EstimatedProjctPayableAmount { get; set; }

        public string CreatedDate { get; set; }

        public string Created { get; set; }

        public string StateDisplay { get; set; } 
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
        [DisplayName("備註")]
        public string Remark { get; set; }

        public IList<ProjectCostInDto> CostIn { get; set; }
        public IList<ProjectCostOutDto> CostOut { get; set; }
        public IList<ProjectAboutFileDto> AboutFiles { get; set; }
    }
}
