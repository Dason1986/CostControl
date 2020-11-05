using BingoX.Domain;

namespace CostControlWebApplication.Domain
{
    public class Supplier : Entity, ISnowflakeEntity<Supplier>
    {
     

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        public string OfficeTel { get; set; }
        public string Fax { get; set; }
        public string ManName { get; set; }
        public string ManTel { get; set; }
        public bool IsCompany { get; set; }
        public string Code { get; set; }
        public int CurrentNumber { get; set; }
        public CommonState State { get; set; }
    }
}
