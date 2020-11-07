using BingoX.Domain;
using CostControlWebApplication.Application;
using System;

namespace CostControlWebApplication.Domain
{

    public class VIProjectTargetCost : ProjectTargetCost, ISnowflakeEntity<VIProjectTargetCost>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Address { get; set; }


        public long FirstId { get; set; }
        public long SecondId { get; set; }

        public long SetterId { get; set; }

        public long ManagerId { get; set; }

        public long ContractorsId { get; set; }

        public string ProjectType { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string SetterName { get; set; }

        public string ManagerName { get; set; }

        public string ContractorsName { get; set; }
    }
    public class ProjectTargetCost : Entity, ISnowflakeEntity<ProjectTargetCost>, IEstimatedDate
    {


        public long ProjectId { get; set; }

        /// <summary>
        /// 項目类型
        /// </summary>
        public long ProjectTypeId { get; set; }

        /// <summary>
        /// 審批文件
        /// </summary>
        public long ApprovalFileId { get; set; }
        /// <summary>
        /// 上家
        /// </summary>
        public long LastHomeId { get; set; }
        /// <summary>
        /// 估算的開工時間
        /// </summary>
        public DateTime? EstimatedBeginDate { get; set; }

        /// <summary>
        /// 估算的開工時間
        /// </summary>
        public DateTime? EstimatedEndDate { get; set; }
        /// <summary>
        /// 建築總面積
        /// </summary>
        public decimal BuildSize { get; set; }
        /// <summary>
        /// 建築面積單方成本造價
        /// </summary>
        public decimal BuildUnitCost { get; set; }
        /// <summary>
        /// 合約金額
        /// </summary>
        public decimal ContractAmount { get; set; }
        /// <summary>
        /// 合約內結算金額
        /// </summary>
        public decimal ContractInAmount { get; set; }
        /// <summary>
        /// 合約外後加減金額
        /// </summary>
        public decimal ContractOutAmount { get; set; }
        public CommonState State { get; set; }
    }
}
