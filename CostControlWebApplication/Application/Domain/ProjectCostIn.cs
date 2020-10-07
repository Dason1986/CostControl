using BingoX.Domain;
using System;

namespace CostControlWebApplication.Domain
{
    public class ProjectCostIn : Entity, ISnowflakeEntity<ProjectCostIn>
    {
        public long ProjectId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public long LastHomeId { get; set; }

        public string Title { get; set; }
        public string Remark { get; set; }

        public decimal ContractAmount { get; set; }
        public decimal AdditionalAmount { get; set; }
        public decimal SettlementAmount { get; set; }
        public decimal OriginalContractAmount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal SecuringAmountRate { get; set; }
        public decimal SubtractSecuringAmount { get; set; }
        public decimal SubtractPrepaidAmount { get; set; }
        public decimal SubtractOtherAmount { get; set; }
        public decimal ReceivableInvoiceAmount { get; set; }
        public decimal ReceivedProjectAmount { get; set; }
        public DateTime? ReceivedProjectDate { get; set; }
        public decimal ReceivedSecuringAmount { get; set; }
        public DateTime? ReceivedSecuringAmountDate { get; set; }
        public decimal SurplusSecuringAmount { get; set; }
        public decimal SurplusProjectAmount { get; set; }
    }
}
