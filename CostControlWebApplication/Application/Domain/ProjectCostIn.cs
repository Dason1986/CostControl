using BingoX.Domain;
using System;
using System.ComponentModel;

namespace CostControlWebApplication.Domain
{
    public class VIProjectCostIn : ProjectCostIn, ISnowflakeEntity<VIProjectCostIn>
    {
        public string Code { get; set; }

        public string Name { get; set; }
        public string LastHome  { get; set; }
    }
    public class ProjectCostIn : Entity, ISnowflakeEntity<ProjectCostIn>
    {
        public long ProjectId { get; set; }
        [Category("Info")]
        public DateTime? InvoiceDate { get; set; }
        [Category("Info")]
        public long LastHomeId { get; set; }
        [Category("Info")]
        public string Title { get; set; }
        [Category("Info")]
        public string Remark { get; set; }
        [Category("Info")]
        public decimal ContractAmount { get; set; }
        [Category("Info")]
        public decimal AdditionalAmount { get; set; }
        [Category("Info")]
        public decimal SettlementAmount { get; set; }
        [Category("Info")]
        public decimal OriginalContractAmount { get; set; }
        [Category("Info")]
        public decimal InvoiceAmount { get; set; }
        [Category("Info")]
        public decimal SecuringAmountRate { get; set; }
        [Category("Info")]
        public decimal SubtractSecuringAmount { get; set; }
        [Category("Info")]
        public decimal SubtractPrepaidAmount { get; set; }
        [Category("Info")]
        public decimal SubtractOtherAmount { get; set; }
        [Category("Info")]
        public decimal ReceivableInvoiceAmount { get; set; }
        [Category("Info")]
        public decimal ReceivedProjectAmount { get; set; }
        [Category("Info")]
        public DateTime? ReceivedProjectDate { get; set; }
        [Category("Info")]
        public decimal ReceivedSecuringAmount { get; set; }
        [Category("Info")]
        public DateTime? ReceivedSecuringAmountDate { get; set; }
        [Category("Info")]
        public decimal SurplusSecuringAmount { get; set; }
        [Category("Info")]
        public decimal SurplusProjectAmount { get; set; }
    }
}
