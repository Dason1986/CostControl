using BingoX.Domain;
using System;
using System.ComponentModel;

namespace CostControlWebApplication.Domain
{
    public class VIProjectCostOut : ProjectCostOut, ISnowflakeEntity<VIProjectCostOut>
    {
        public string Code { get; set; }

        public string Name { get; set; } 

        public string CostType { get; set; }
        public string Department { get; set; }
        public string Currency { get; set; }
        public string SettlementMethod { get; set; }
    }
    public class ProjectCostOut : Entity, ISnowflakeEntity<ProjectCostOut>
    {
        public long ProjectId { get; set; }
        [Category("Info")]
        public string OrderNo { get; set; }
        [Category("Info")]
        public long CostTypeId { get; set; }
        public DateTime? CostoutDate { get; set; }
        [Category("Info")]
        public long DepartmentId { get; set; }
        [Category("Info")]
        public string Title { get; set; }
        [Category("Info")]
        public long CurrencyId { get; set; }
        [Category("Info")]
        public decimal ReceiveAmount { get; set; }
        [Category("Info")]
        public decimal ExpendAmount { get; set; }
        [Category("Info")]
        public string InvoiceNo { get; set; }
        [Category("Info")]
        public long SettlementMethodId { get; set; }
        [Category("Info")]
        public string CheckNumber { get; set; }
        [Category("Info")]
        public DateTime? InvoiceDate { get; set; }
        [Category("Info")]
        public DateTime? TransferDate { get; set; }
        [Category("Info")]
        public DateTime? ExpectedPaymentDate { get; set; }
        [Category("Info")]
        public string FollowUser { get; set; }
        [Category("Info")]
        public string Dispatcher { get; set; }
        [Category("Info")]
        public DateTime? ExchangeDate { get; set; }
        [Category("Info")]
        public bool Confirmation { get; set; }
        [Category("Info")]
        public bool Handover { get; set; }
        [Category("Info")]
        public string Remark { get; set; }
    }
}
