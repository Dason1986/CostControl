using BingoX.Domain;

namespace CostControlWebApplication.Domain
{
    public class ProjectCalculation : Entity, ISnowflakeEntity<ProjectCalculation>
    {
        public long ProjectId { get; set; }
        public decimal HumanCost { get; set; }
        public decimal Salary { get; set; }


    }
    public class ProjectCalculationDetail : Entity, ISnowflakeEntity<ProjectCalculationDetail>
    {
        public long ProjectId { get; set; }
        public long CalculationId { get; set; }
        public long ProcurementId { get; set; }
        public int OrderNo { get; set; }
        public decimal ContractAmount { get; set; }
        public decimal EstimateCost { get; set; }
        public decimal GrossMargin { get; set; }
        public string Remark { get; set; }
         


    }
}
