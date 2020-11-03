using CostControlWebApplication.Application;
using System;

namespace CostControlWebApplication.Domain
{
    public class VIProjectStandingbook : ProjectStandingbook, BingoX.Domain.ISnowflakeEntity<VIProjectStandingbook>, IDate
    {

     

        public string Code { get; set; }
        public string  Name { get; set; }
     

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
}
