using BingoX.Domain;

namespace CostControlWebApplication.Domain
{
    public class TargetCost : Entity, ISnowflakeEntity<TargetCost>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public long ApprovalFileId { get; set; }


    }
}
