using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Application.Services.Dtos
{
    public class SupplierDto : Dto
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
        public string State { get; set; }
    }
}
