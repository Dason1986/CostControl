using BingoX.AspNetCore;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace CostControlWebApplication.Services
{
    public class ResourceService : ISingleService
    {
        private readonly IServiceProvider serviceProvider;

        public ResourceService(System.IServiceProvider serviceProvider, IBoundedContext bounded)
        {
            this.serviceProvider = serviceProvider;
            ChangedBasics();
        }
        IList<BasicData> Basics;
        public void ChangedBasics()
        {
            var repository = serviceProvider.GetService<ResourceRepository>();
            Basics = repository.GetAll();
        }
        public IList<BasicData> GetBasics(string groupcode)
        {
            var id = Basics.FirstOrDefault()?.ID;
            return Basics.Where(n => n.ParentId == id).ToList();
        }
    }
}
