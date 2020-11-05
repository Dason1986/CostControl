using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CostControlWebApplication.Application.Services.Dtos
{
    public class ProjectProcurementDto : IDto
    {
        public long ID { get; set; }
        /// <summary>
        /// 項目編號A
        /// </summary> 
        [DisplayName("項目編號")]
        public string Code { get; set; }

        /// <summary>
        /// 項目名稱B
        /// </summary>
        [DisplayName("項目名稱")]
        public string Name { get; set; }

        public long ProjectId { get; set; }
        /// <summary>
        /// 採購審批類型
        /// </summary>
        public string ProcurementType { get; set; }

        [DisplayName("採購審批類型")]
        public string ProcurementTypeName { get; set; }
        /// <summary>
        /// 項目負責人意見  1类
        /// </summary>
        [DisplayName("項目負責人意見")]
        public string ManagerOpinion { get; set; }
        [DisplayName("供應商/分判商")]
        public string SupplierName { get; set; }

        [DisplayName("材料/外判類型")]
        public long SupplierType { get; set; }
        /// <summary>
        /// 供應商名稱
        /// </summary>
        public long SupplierID { get; set; }
        /// <summary>
        /// 成本部意見
        /// </summary>
        [DisplayName("成本部意見")]
        public string CosterOpinion { get; set; }
        /// <summary>
        /// 部門經理意見
        /// </summary>
        [DisplayName("部門經理意見")]
        public string DepartmentOpinion { get; set; }

        /// <summary>
        /// A本次材料對應item、金額（對業主的BQ合同）
        /// </summary>
        public decimal ItemAmount { get; set; }
        /// <summary>
        /// B採購金額
        /// </summary>
        [DisplayName("採購金額")]
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
        public string PaymentMethod { get; set; }


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
        public string PaidAmount { get; set; }
        /// <summary>
        /// 費用承擔公司  4类
        /// </summary>
        public string ExpenseCompany { get; set; }


        [DisplayName("狀態")]
        public string State { get; set; }
        /// <summary>
        /// 備註AH
        /// </summary>
        [DisplayName("備註")]
        public string Remark { get; set; }

        [DisplayName("提交時間")]
        public string CreatedDate { get; set; }

        [DisplayName("提交人")]
        public string Created { get; set; }
        public IList<ProjectAboutFileDto> Files { get; set; }

        public IList<ProcurementBQItemDto> Items { get; set; }
    }
}
