using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CostControlWebApplication.Application.Services.Dtos
{
    public class ProjectMasterDto : IDto, IDateDto
    {
        public long ID { get; set; }
        [DisplayName("項目編號")]
        /// <summary>
        /// 項目編號A
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 項目名稱B
        /// </summary>
        [DisplayName("項目名稱")]
        public string Name { get; set; }

        [DisplayName("公司名稱")]
        /// <summary>
        /// 項目編號A
        /// </summary>
        public string CompanyName { get; set; }
        public long CompanyId { get; set; }
        /// <summary>
        /// 項目地址
        /// </summary>
        [DisplayName("項目地址")]
        public string Address { get; set; }
        [DisplayName("項目類型")]
        public string ProjectType { get; set; }
        [DisplayName("項目經理")]
        public string ManagerName { get; set; }
        [DisplayName("定作人")]
        public string SetterName { get; set; }
        [DisplayName("承建商")]
        public string ContractorsName { get; set; }
        [DisplayName("第一分判")]
        public string FirstName { get; set; }
        [DisplayName("第二分判")]
        public string SecondName { get; set; }
        [DisplayName("第三分判")]
        public string ThirdName { get; set; }
        public long CreateFileId { get; set; }
        public long ContractorsId { get; set; }
      
        public long ManagerId { get; set; }
        public long SetterId { get; set; }
        public long FirstId { get; set; }
        public long SecondId { get; set; }
        public long ThirdId { get; set; }
        public long ProjectMainId { get; set; }
        [DisplayName("項目主體")]
        public string ProjectMain { get; set; }
        /// <summary>
        /// 合同金額L
        /// </summary>
        [DisplayName("合約金額")]
        public decimal ContractAmount { get; set; }

        /// <summary>
        /// 開工時間
        /// </summary>
        [DisplayName("開工時間")]
        public string BeginDate { get; set; }

        /// <summary>
        /// 開工時間
        /// </summary>
        [DisplayName("完工時間")]
        public string EndDate { get; set; }
        [DisplayName("預計開始日期")]
        public string EstimatedBeginDate { get; set; }
        [DisplayName("預計結束日期")]
        public string EstimatedEndDate { get; set; }


        [DisplayName("提交時間")]
        public string CreatedDate { get; set; }

        [DisplayName("提交人")]
        public string Created { get; set; }

        public string StateDisplay { get; set; }

        public IList<ProjectProcurementDto> Procurements { get; set; }
        public IList<ProjectAboutFileDto> Files { get; set; }
        public IList<ProjectCostInDto> Costin { get; set; }
        public IList<ProjectCostOutDto> Costout { get; set; }
    }
}
