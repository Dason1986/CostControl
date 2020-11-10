using BingoX.Domain;

namespace CostControlWebApplication.Domain
{
    public class ProcurementBQItem  : Entity, ISnowflakeEntity<ProcurementBQItem>
    {
      
        public long ProjectId { get; set; }
        public long ProcurementId { get; set; }

        /// <summary>
        /// 項目
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 中標數量
        /// </summary>
        public decimal BidQuantity { get; set; }
        /// <summary>
        /// 中標單價
        /// </summary>
        public decimal BidPrice { get; set; }
        /// <summary>
        /// 中標總計
        /// </summary>
        public decimal BidAmount { get; set; }
        /// <summary>
        /// 採購數量
        /// </summary>
        public decimal ProcurementQuantity { get; set; }
        /// <summary>
        /// 採購單價
        /// </summary>
        public decimal ProcurementPrice { get; set; }
        /// <summary>
        /// 採購金額
        /// </summary>
        public decimal ProcurementAmount { get; set; }

        /// <summary>
        /// 已採購數量
        /// </summary>
        public decimal ProcurementEndQuantity { get; set; }

        /// <summary>
        /// 已採購單價
        /// </summary>
        public decimal ProcurementEndPrice { get; set; }

        /// <summary>
        /// 已採購金額
        /// </summary>
        public decimal ProcurementEndAmount { get; set; }
        /// <summary>
        /// 總採購金額
        /// </summary>
        public decimal ProcurementEndTotalAmount { get; set; }

        /// <summary>
        /// 其他暫估 總採購數量
        /// </summary>
        public decimal  TotalQuantity { get; set; }
        /// <summary>
        /// 其他暫估 單價
        /// </summary>
        public decimal OtherPrice { get; set; }
        /// <summary>
        /// 其他暫估 總計
        /// </summary>
        public decimal Total { get; set; }



        /// <summary>
        /// 備註AH
        /// </summary>
        public string Remark { get; set; }
        public ProcurementType ProcurementType { get;   set; }
    }
}
