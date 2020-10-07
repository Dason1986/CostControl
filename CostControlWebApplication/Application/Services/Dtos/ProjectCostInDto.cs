using System;

namespace CostControlWebApplication.Application.Services.Dtos
{
    public class ProjectCostInDto : IDto
    {
        public long ProjectId { get; set; }
        public string InvoiceDate { get; set; }
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
        public string ReceivedProjectDate { get; set; }
        public decimal ReceivedSecuringAmount { get; set; }
        public string ReceivedSecuringAmountDate { get; set; }
        public decimal SurplusSecuringAmount { get; set; }
        public decimal SurplusProjectAmount { get; set; }
    }
}
