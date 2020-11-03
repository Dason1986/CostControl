using System.Collections;
using System.Collections.Generic;

namespace CostControlWebApplication.Application.Services.Dtos
{
    public class ProjectMasterDto : IDto, IDateDto
    {
        public long ID { get; set; }
        /// <summary>
        /// 項目編號A
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 項目名稱B
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 項目地址
        /// </summary>
        public string Address { get; set; }
        public string ProjectType { get; set; }
        public string ManagerName { get; set; }
        public string SetterName { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ContractorsName { get; set; }
        public long ContractorsId { get; set; }
        public long ManagerId { get; set; }
        public long SetterId { get; set; }
        public long FirstId { get; set; }
        public long SecondId { get; set; }
        public long ProjectTypeId { get; set; }
        /// <summary>
        /// 合同金額L
        /// </summary>
        public string ContractAmount { get; set; }
        /// <summary>
        /// 開工時間
        /// </summary>
        public string BeginDate { get; set; }

        /// <summary>
        /// 開工時間
        /// </summary>
        public string EndDate { get; set; }
        public string EstimatedBeginDate { get; set; }
        public string EstimatedEndDate { get; set; }


        public string CreatedDate { get; set; }

        public string Created { get; set; }

        public string StateDisplay { get; set; }

        public IList<ProjectProcurementDto> Procurements { get; set; }
        public IList<ProjectAboutFileDto> Files { get; set; }
    }
}
