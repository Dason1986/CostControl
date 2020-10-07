using AutoMapper;
using AutoMapper.Configuration;
using BingoX.Domain;
using BingoX.Helper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CostControlWebApplication
{
    public interface IMappingResolver
    {

    }
    interface IMappingResolver<T1, T2> : IMappingResolver
    {
        void Map(IMappingExpression<T1, T2> mapping);
    }
    public class MappingProfile : MapperConfigurationExpression
    {
        private static bool isInitialized;
        private readonly Assembly mapperAssembly;
        private readonly Assembly entityAssembly;
        private readonly Assembly dtoAssembly;
        private readonly MethodInfo methodCreateMap;
        private readonly IDictionary<string, object> mapdic = new Dictionary<string, object>();
        public MappingProfile()
        {
            methodCreateMap = this.GetType().GetMethods().Where(n => n.Name == "CreateMap").ToList()[0];

            mapperAssembly = this.GetType().Assembly;
            entityAssembly = this.GetType().Assembly;
            dtoAssembly = this.GetType().Assembly;
            OnConfigure();
        }

        protected void OnConfigure()
        {
            if (isInitialized) return;
            isInitialized = true;

            string[] splist = new string[] { ";" };
            CreateMap<string[], string>().ConvertUsing(s => s == null ? string.Empty : string.Join(";", s));
            CreateMap<string, string[]>().ConvertUsing(s => s == null ? new string[0] : s.Split(splist, StringSplitOptions.RemoveEmptyEntries));
            CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
            CreateMap<bool, int>().ConvertUsing(s => s ? 1 : 0);
            CreateMap<int, bool>().ConvertUsing(s => s > 0);
            CreateMap<DateTime?, string>().ConvertUsing(s => string.Format("{0:yyyy-MM-dd}",s));
            CreateMap<Enum, string>().ConvertUsing(s => Convert.ToInt32(s).ToString());
            //   CreateMap<Enum, string>().ConvertUsing(s => s == null ? string.Empty : BingoX.Utility.EnumUtility.GetDescription(s));
          
            Create<TargetCost, TargetCostListItmeDto>();
            Create<TargetCost, TargetCostDto>();
            Create<FileEntry, ProjectAboutFile>();
            InitDto();

            //CreateEntityToDto(mappingResolvers, valueModelentities, valueModeldtos);



        }


        private void InitDto()
        {
            var mappingResolvers = mapperAssembly.ExportedTypes.OfType<Type>().Where(o => typeof(IMappingResolver).IsAssignableFrom(o) && o.IsClass && !o.IsAbstract).ToArray();

            var entities = entityAssembly.ExportedTypes.OfType<Type>().Where(o => (typeof(IDomainEntry).IsAssignableFrom(o)) && o.IsClass && !o.IsAbstract).ToArray();

            var dtos = dtoAssembly.ExportedTypes.OfType<Type>().Where(o => (typeof(IDto).IsAssignableFrom(o)) && o.IsClass && !o.IsAbstract).ToArray();






            CreateEntityToDto(mappingResolvers, entities, dtos);
        }
        void Create<T1, T2>()
        {

            Create(typeof(T1), typeof(T2));
            Create(typeof(T2), typeof(T1));
        }
        object Create(Type type1, Type type2)
        {
            var key = $"{type1.FullName} => {type2.FullName}";
            if (mapdic.ContainsKey(key)) return mapdic[key];
            var genericMethod = methodCreateMap.MakeGenericMethod(type1, type2);
            var mapp = genericMethod.Invoke(this, null);
            mapdic.Add(key, mapp);
            return mapp;
        }
        private void CreateEntityToDto(Type[] mappingResolvers, Type[] entities, Type[] dtos)
        {

            foreach (TypeInfo item in mappingResolvers)
            {
                var interfaceitem = item.ImplementedInterfaces.FirstOrDefault(n => n.Name == "IMappingResolver`2");
                if (interfaceitem == null || interfaceitem.GenericTypeArguments == null || interfaceitem.GenericTypeArguments.Length == 0) continue;

                var map = Create(interfaceitem.GenericTypeArguments[0], interfaceitem.GenericTypeArguments[1]);
                var resolver = Activator.CreateInstance(item) as IMappingResolver;
                var method2 = resolver.GetType().GetMethods().FirstOrDefault(n => n.Name == "Map");
                method2.Invoke(resolver, new object[] { map });
            }
            foreach (var entity in entities)
            {

                var dtoname = entity.Name + "Dto";
                var dtoitem = dtos.FirstOrDefault(o => o.Name == dtoname);
                if (dtoitem == null) continue;


                Create(entity, dtoitem);
                Create( dtoitem, entity);


            }
        }

    }
}
