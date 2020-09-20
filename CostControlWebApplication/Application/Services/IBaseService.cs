using BingoX.AspNetCore;

namespace CostControlWebApplication.Services
{
    public interface IBaseService : IService
    {
        IBoundedContext Bounded { get; }
        ICurrentUser User { get; }
    }
    public abstract  class BaseService: IBaseService
    {
      
        public BaseService(IBoundedContext bounded, ICurrentUser user)
        {

            this.Bounded = bounded;
            this.User = user;
        }
        public IBoundedContext Bounded { get; private set; }
        public ICurrentUser User { get; private set; }
    }
}
