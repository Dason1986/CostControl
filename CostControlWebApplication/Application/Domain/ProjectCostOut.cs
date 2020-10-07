using BingoX.Domain;
using System;

namespace CostControlWebApplication.Domain
{
    public class ProjectCostOut : Entity, ISnowflakeEntity<ProjectCostOut>
    {
        public long ProjectId { get; set; }
        public string OrderNo { get; set; }

        public long CostTypeId { get; set; }
        public DateTime? CostoutDate { get; set; }
        public long DepartmentId { get; set; }
        public string Title { get; set; }
        public long CurrencyId { get; set; }
        public decimal ReceiveAmount { get; set; }
        public decimal ExpendAmount { get; set; }
        public string InvoiceNo { get; set; }
        public long SettlementMethodId { get; set; }
        public string CheckNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? TransferDate { get; set; }
        public DateTime? ExpectedPaymentDate { get; set; }
        public string FollowUser { get; set; }
        public string Dispatcher { get; set; }
        public DateTime? ExchangeDate { get; set; }
        public bool Confirmation { get; set; }
        public bool Handover { get; set; }
        public string Remark { get; set; }
    }
}
