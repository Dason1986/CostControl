using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace CostControlWebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var assembly = this.GetType().Assembly; ;

            services.AddStandard(assembly)
            .AddMvcOptions(options =>
            {

                options.Filters.Add<LogerExceptionFilterAttribute>();
            }).AddNewtonsoftJson(n=>n.SerializerSettings.Converters.Add(new NumberConverter()));

            services.FindConfigureServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
       
   
            System.Console.WriteLine("version:{0}", Configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //  //  app.UseHsts();
            //}
            app.UseSession();
            app.UseStaticFiles();
            AddFileStorage(app, env);

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
             
            Adapter.Mapping = app.ApplicationServices.GetService<IMapper>();
        }

        private static void AddFileStorage(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var path = Path.Combine(env.ContentRootPath, "FileStorage");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
             var cont = new FileExtensionContentTypeProvider();
          //  cont.Mappings.Add(".gree", "applaction/octet-stream");
            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = cont,
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "FileStorage")),
                RequestPath = new PathString("/FileStorage")
            });
        }
    }
}
