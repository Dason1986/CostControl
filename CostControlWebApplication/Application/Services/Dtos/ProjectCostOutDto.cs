using System;

namespace CostControlWebApplication.Application.Services.Dtos
{
    public class ProjectCostOutDto:IDto
    {
        public long Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }

        public string CostType { get; set; }
        public string Department { get; set; }
        public string Currency { get; set; }
        public string SettlementMethod { get; set; }
        public long ProjectId { get; set; }
        public string OrderNo { get; set; }

        public long CostTypeId { get; set; }
        public string CostoutDate { get; set; }
        public long DepartmentId { get; set; }
        public long PartyId { get; set; }
        public string Title { get; set; }
        public long CurrencyId { get; set; }
        public decimal ReceiveAmount { get; set; }
        public decimal ExpendAmount { get; set; }
        public string InvoiceNo { get; set; }
        public long SettlementMethodId { get; set; }
        public string CheckNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string TransferDate { get; set; }
        public string ExpectedPaymentDate { get; set; }
        public string FollowUser { get; set; }
        public string Dispatcher { get; set; }
        public string ExchangeDate { get; set; }
        public bool Confirmation { get; set; }
        public bool Handover { get; set; }
        public string Remark { get; set; }
    }
}
