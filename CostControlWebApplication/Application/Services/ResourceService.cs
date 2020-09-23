using BingoX.AspNetCore;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace CostControlWebApplication.Services
{
    public class ResourceService : ISingleService
    {
        private readonly IServiceProvider serviceProvider;

        public ResourceService(System.IServiceProvider serviceProvider, IBoundedContext bounded)
        {
            this.serviceProvider = serviceProvider;
            Init();
        }
        IList<BasicData> Basics;
        OptionEntry[] Supplier;
        OptionEntry[] User;
        IDictionary<string, OptionEntry[]> TreeBasics;
        private void Init()
        {
            ChangedBasics();
            ChangedSupplier();
            ChangedUser();
        }
        public void ChangedUser()
        {
            try
            {
                var http = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                var repository = http.RequestServices.GetService<ResourceRepository>();
                User = repository.GetUser().Select(n =>
                {
                    var entry = new OptionEntry { Label = n.Name, Value = n.ID.ToString(), Id = n.ID.ToString() };
               
                    return entry;
                }).ToArray();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void ChangedSupplier()
        {
            try
            {
                var http = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                var repository = http.RequestServices.GetService<ResourceRepository>();
                Supplier = repository.GetSupplier().Select(n =>
                    {
                        var entry = new OptionEntry { Label = n.Name, Value = n.ID.ToString(), Id = n.ID.ToString() };
                        ForeachChild(entry);
                        return entry;
                    }).ToArray();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void ChangedBasics()
        {
            try
            {
                var http = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
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
            }
            catch (Exception ex)
            {

                throw ex;
            }

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

        public OptionEntry[] GetLastHome()
        {
            return Supplier;
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
