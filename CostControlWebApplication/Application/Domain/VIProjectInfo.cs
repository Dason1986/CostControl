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
        /// 商業/政府/住宅 項目类型
        /// </summary>
        public string ProjectType { get; set; }

        /// <summary>
        /// 現金流入S
        /// </summary>
        public decimal CashInProjectAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CashInSecuringAmount { get; set; }
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
}
