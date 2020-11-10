using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CostControlWebApplication.Application.Services.Dtos
{
    public class ProjectCalculationDto : IDto
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







     
        public string FirstName { get; set; }
      
        public string SecondName { get; set; }
      
        public string ThirdName { get; set; }
        [DisplayName("分判費用")]
        public decimal OutsourcingCost { get; set; }
        [DisplayName("暫估費用")]
        public decimal OutsourcingCost1 { get; set; }
        [DisplayName("材料費用")]
        public decimal MaterialCost { get; set; }
        [DisplayName("人力成本")]
        public decimal HumanCost { get; set; }
        [DisplayName("工人工資")]
        public decimal Salary { get; set; }
        [DisplayName("項目管理費")]
        public decimal MangerCost { get; set; }
        [DisplayName("合計")]
        public decimal Total { get { return MangerCost + HumanCost + MaterialCost + OutsourcingCost + Salary; } }
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

        public IList<ProjectCalculationDetailDto> Items { get; set; }
        [DisplayName("提交時間")]
        public string CreatedDate { get; set; }

        [DisplayName("提交人")]
        public string Created { get; set; }

    }

    public class ProjectCalculationDetailDto : IDto
    {

    }
}
