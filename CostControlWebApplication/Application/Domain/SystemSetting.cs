using BingoX.Domain;

namespace CostControlWebApplication.Domain
{
    public class SystemSetting : IStringEntity<SystemSetting>, IDomainEntry
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }

        public string DataValue { get; set; }
        public string GroupCode { get; set; }

        string IEntity<SystemSetting, string>.ID { get => Code; set => Code = value; }
    }
}
