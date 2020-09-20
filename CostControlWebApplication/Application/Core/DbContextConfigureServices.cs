using BingoX.AspNetCore.Extensions;
using CostControlWebApplication.Application.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace CostControlWebApplication
{
    [DIConfigureServicesAttribute(1)]
    public class DbContextConfigureServices : DIConfigureServices
    {
        public DbContextConfigureServices(IConfiguration configuration, IServiceCollection services) : base(configuration, services)
        {
        }

        protected override void Register()
        {
       var ass=     this.GetType().Assembly;
           
            services.AddRepository(configuration, n =>
            {

                n.DefaultConnectionName = "db1";
                n.AddSqlSugar(
                    dbi =>
                    {
                        dbi.CustomConnectionName = "db1";
                        dbi.AppSettingConnectionName = "DefaultConnection";
                        dbi.DataAccessorAssembly = ass;
                        dbi.EntityAssembly = ass;
                        dbi.DomainEntityAssembly = ass;
                        dbi.DbContextType = typeof(SqlSugarDbBoundedContext);
                        dbi.RepositoryAssembly = ass;
                        //     dbi.Intercepts.Add(new AopBatchInvoice());
                        dbi.DbContextOption = new ConnectionConfig()
                        {
                            ConnectionString = configuration.GetConnectionString("DefaultConnection"),
                            DbType = DbType.MySql  ,
                            IsAutoCloseConnection = true,
                            InitKeyType = InitKeyType.Attribute,
                            
                        };
                    }
                );

            });
        }
    }
}
