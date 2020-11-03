using BingoX.Domain;

namespace CostControlWebApplication.Domain
{
    public class VIProjectProcurement : ProjectProcurement, ISnowflakeEntity<VIProjectProcurement>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public string SupplierName { get; set; }
    }
}
