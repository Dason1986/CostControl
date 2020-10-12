namespace CostControlWebApplication.Application.Services.Dtos
{
    public class ProjectInfoListItmeDto : IDto,IDateDto
    {
        public long ID { get; set; }
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
        /// 商業/政府/住宅 項目类型
        /// </summary>
        public string ProjectType { get; set; }

        /// <summary>
        /// 現金流入S
        /// </summary>
        public string CashInAmount { get; set; }
        /// <summary>
        /// 現金流出T
        /// </summary>
        public string CashOutAmount { get; set; }
        /// <summary>
        /// 應收賬款X
        /// </summary>
        public string ReceivableAmount { get; set; }
        /// <summary>
        /// 應付賬款Y
        /// </summary>
        public string PayableAmount { get; set; }

        /// <summary>
        /// 結算金額R
        /// </summary>
        public string BalanceAmount { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

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
        /// 完工百分比E（%）
        /// </summary>
        public decimal CompletionRatio { get; set; }
        /// <summary>
        /// 合同金額L
        /// </summary>
        public string ContractAmount { get; set; }
        /// <summary>
        /// 成本金額L
        /// </summary>
        public string CostAmount { get; set; }
        /// <summary>
        /// 後加金額L1
        /// </summary>
        public string AdditionalAmount { get; set; }
        /// <summary>
        /// 開工時間
        /// </summary>
        public string BeginDate { get; set; }

        /// <summary>
        /// 開工時間
        /// </summary>
        public string EndDate { get; set; }


        public string CreatedDate { get; set; }

        public string Created { get; set; }

        public string StateDisplay { get; set; }
    }
}
