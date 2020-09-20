using BingoX.Domain;
using System;

namespace CostControlWebApplication.Domain
{
    public abstract class Entity : ISnowflakeEntity<Entity>, IAuditCreated, IAuditModified, IDomainEntry
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Created { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Modified { get; set; }
    }
}
