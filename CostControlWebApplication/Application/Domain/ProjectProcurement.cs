﻿using BingoX.Domain;
using System.ComponentModel;

namespace CostControlWebApplication.Domain
{

    public class ProjectProcurement : Entity, ISnowflakeEntity<ProjectProcurement>
    {

        public long ProjectId { get; set; }
        /// <summary>
        /// 採購審批類型
        /// </summary>
      
        public ProcurementType ProcurementType { get; set; }

        /// <summary>
        /// 項目負責人意見  1类
        /// </summary>
        public string ManagerOpinion { get; set; }

        public string SupplierType { get; set; }
        /// <summary>
        /// 供應商名稱
        /// </summary>
        public long SupplierID { get; set; }
        /// <summary>
        /// 成本部意見
        /// </summary>
        public string CosterOpinion { get; set; }
        /// <summary>
        /// 部門經理意見
        /// </summary>
        public string DepartmentOpinion { get; set; }

        /// <summary>
        /// A本次材料對應item、金額（對業主的BQ合同）
        /// </summary>
        public decimal ItemAmount { get; set; }
        /// <summary>
        /// B採購金額
        /// </summary>
        public decimal ProcurementAmount { get; set; }

        /// <summary>
        /// 本次採購   1类
        /// </summary>
        public decimal ThisProcurementAmount { get; set; }
        /// <summary>
        /// 已採購     1类
        /// </summary>
        public decimal BeenProcurementAmount { get; set; }
        /// <summary>
        /// 總採購     1类
        /// </summary>
        public decimal AllProcurementAmount { get; set; }
        /// <summary>
        /// C其他暫估
        /// </summary>
        public decimal OtherAmount { get; set; }
        /// <summary>
        /// D 利潤比例  (D=1-(B+C)/A)
        /// </summary>
        public decimal ProfitsRate { get; set; }


        /// <summary>
        /// 材料用途  1类
        /// </summary>
        public string MaterialUsage { get; set; }
        /// <summary>
        /// 總採購金額 2类 3类
        /// </summary>
        public decimal TotalPurchaseAmount { get; set; }


        /// <summary>
        /// 支付方式  2类
        /// </summary>
        public long PaymentMethodId { get; set; }


        /// <summary>
        /// 聯繫電話  2类
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 聯繫地址  2类
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 代付金額  4类
        /// </summary>
        public decimal PaidAmount { get; set; }
        /// <summary>
        /// 費用承擔公司  4类
        /// </summary>
        public string ExpenseCompany { get; set; }


        /// <summary>
        /// 備註AH
        /// </summary>
        public string Remark { get; set; }
        public ProcurementState State { get; set; }
    }
    public enum ProcurementType
    {
        None = 0,
        /// <summary>
        /// 1-ADC材料採購審批單(對內)
        /// </summary>
        [Description("材料採購審批單")]
        Materials = 1,
        /// <summary>
        /// 2-ADC外判採購審批單(對內)
        /// </summary>
        [Description("外判採購審批單")]
        Outsourcing = 2,
        /// <summary>
        /// 3-ADC其他採購審批單(對內) 
        /// </summary>
        [Description("其他採購審批單")]
        Other = 3,
        /// <summary>
        /// 4-ADC工程代付審批單（對內）
        /// </summary>
        [Description("工程代付審批單")]
        Paid = 4,
    }
}
