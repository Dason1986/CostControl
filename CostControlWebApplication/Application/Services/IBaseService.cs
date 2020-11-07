using BingoX.AspNetCore;

namespace CostControlWebApplication.Services
{
    public interface IBaseService : IService
    {
        IBoundedContext Bounded { get; }
        IStaffeUser User { get; }
    }
    public abstract  class BaseService: IBaseService
    {
      
        public BaseService(IBoundedContext bounded, IStaffeUser user)
        {

            this.Bounded = bounded;
            this.User = user;
        }
        public IBoundedContext Bounded { get; private set; }
        public IStaffeUser User { get; private set; }
    }
}
