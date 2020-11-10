using BingoX.Domain;

namespace CostControlWebApplication.Domain
{
    public class VIProjectProcurement : ProjectProcurement, ISnowflakeEntity<VIProjectProcurement>, IProjectEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public string SupplierName { get; set; }

        public long ManagerId { get; set; }
    }
}
