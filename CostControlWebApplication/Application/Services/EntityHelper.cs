using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Services
{
    static class EntityHelper
    {
        public static void Created<T>(this T t, IBaseService service) where T : Entity
        {
            t.ID = service.Bounded.Generator.New();
            t.CreatedDate = service.Bounded.DateTimeService.GetNow();
            t.ModifiedDate = service.Bounded.DateTimeService.GetNow();
            t.Created = service.User.Name;
            t.Modified = service.User.Name;
        }
        public static void Modified<T>(this T t, IBaseService service) where T : Entity
        {


            t.ModifiedDate = service.Bounded.DateTimeService.GetNow();

            t.Modified = service.User.Name;
        }
    }
}
