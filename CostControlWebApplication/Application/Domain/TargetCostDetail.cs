using BingoX.Domain;
using System;

namespace CostControlWebApplication.Domain
{
    public class ProjectTargetCostDetail : Entity, ISnowflakeEntity<ProjectTargetCostDetail>
    {
        public long TargetCostId { get; set; }
        public long Code { get; set; }
        public long ParentCode { get; set; }

        public DateTime InputDate { get; set; }

        public string Title { get; set; }
        public string Remark { get; set; }

        public long SupplierId { get; set; }
    }
}
