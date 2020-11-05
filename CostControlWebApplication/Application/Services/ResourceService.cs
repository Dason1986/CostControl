using BingoX.AspNetCore;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CostControlWebApplication.Services
{
    public class ResourceService : ISingleService
    {
        private readonly IServiceProvider serviceProvider;

        public ResourceService(System.IServiceProvider serviceProvider, IBoundedContext bounded)
        {
            this.serviceProvider = serviceProvider;
            Init().GetAwaiter();
        }
        IList<BasicData> Basics;
        OptionEntry[] Supplier;
        OptionEntry[] Company;
        OptionEntry[] User;
        IDictionary<string, OptionEntry[]> TreeBasics;
        private async Task Init()
        {
            await ChangedBasics();
            await ChangedSupplier();
            await ChangedUser();
        }
        public Task ChangedUser()
        {
            var http = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
            return Task.Run(() =>
            {

                var repository = http.RequestServices.GetService<ResourceRepository>();
                User = repository.GetUser().Select(n =>
                {
                    var entry = new OptionEntry { Label = n.Name, Value = n.ID.ToString(), Id = n.ID.ToString() };

                    return entry;
                }).ToArray();
            });




        }
        public Task ChangedSupplier()
        {
            var http = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
            return Task.Run(() =>
            {
                var repository = http.RequestServices.GetService<ResourceRepository>().GetSupplier();
                Supplier = repository.Select(n =>
                   {
                       var entry = new OptionEntry { Label = n.Name, Value = n.ID.ToString(), Id = n.ID.ToString() };
                       ForeachChild(entry);
                       return entry;
                   }).ToArray();
                Company = repository.Where(n => n.IsCompany).Select(n =>
                      {
                          var entry = new OptionEntry { Label = n.Name, Value = n.ID.ToString(), Id = n.ID.ToString() };
                          ForeachChild(entry);
                          return entry;
                      }).ToArray();

            }
           );

        }
        public Task ChangedBasics()
        {
            var http = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
            return Task.Run(() =>
            {
                var repository = http.RequestServices.GetService<ResourceRepository>();
                Basics = repository.GetBasicData();
                TreeBasics = new Dictionary<string, OptionEntry[]>();
                foreach (var item in Basics.Where(n => !string.IsNullOrEmpty(n.GroupCode)))
                {
                    TreeBasics.Add(item.GroupCode, Basics.Where(n => n.ParentId == item.ID).Select(n =>
                    {
                        var entry = Create(n);
                        ForeachChild(entry);
                        return entry;
                    }).ToArray());
                }
            });


        }
        OptionEntry Create(BasicData basicData)
        {
            OptionEntry entry = new OptionEntry { Label = basicData.Name, Value = basicData.DataValue, Id = basicData.ID.ToString(), Disabled = basicData.State == CommonState.Disabled };
            return entry;
        }
        void ForeachChild(OptionEntry entry)
        {
            entry.Children = Basics.Where(n => n.ParentId.ToString() == entry.Id).Select(n =>
             {
                 var entry = Create(n);
                 ForeachChild(entry);
                 return entry;
             }).ToArray();
        }
        public OptionEntry[] GetBasics(string groupcode)
        {
            return TreeBasics.ContainsKey(groupcode) ? TreeBasics[groupcode] : null;
        }

        public OptionEntry[] GetSupplier()
        {
            return Supplier;
        }
        public OptionEntry[] GetCompany()
        {
            return Company;
        }
        public OptionEntry[] GetUser()
        {
            return User;
        }
    }
    public class OptionEntry
    {
        public string Label { get; set; }
        public string Id { get; set; }
        public bool Disabled { get; set; }
        public OptionEntry[] Children { get; set; }
        public string Value { get; set; }
    }
}
