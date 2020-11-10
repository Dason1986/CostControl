namespace CostControlWebApplication.Domain
{
    public interface IProjectEntity
    {
        long ID { get; }
        string Code { get; }
        string Name { get; }
        long ManagerId { get;  }
    }
}
