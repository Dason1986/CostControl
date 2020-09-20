using BingoX.Domain;

namespace CostControlWebApplication.Domain
{
    public class Supplier : Entity, ISnowflakeEntity<Supplier>
    {
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

        public string Tel { get; set; }

    }
}
