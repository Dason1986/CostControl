using BingoX;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Domain;
using System;

namespace CostControlWebApplication.Application.Data
{
    public class BasicDataRepository : Repository
    {
        public BasicDataRepository(RepositoryContextOptions options) : base(options)
        {
            dataAccessorBasicData = CreateWrapper<BasicData>();
        }
        private readonly IDataAccessor<BasicData> dataAccessorBasicData;

        public IPagingList<BasicData> PageList(Specification<BasicData> specification)
        {
            int total = 0;
            return dataAccessorBasicData.PageList(specification, ref total).ProjectedAsPagingList(total, specification);
        }
        public bool ExistChildren(long id)
        {
            return dataAccessorBasicData.Exist(n => n.ParentId == id);
        }

        public bool ExistDataValue(long parentId, string dataValue)
        {
            return dataAccessorBasicData.Exist(n => n.ParentId == parentId && n.DataValue == dataValue);
        }
        public void AddBasicData(BasicData entity)
        {



            bool existvalue = ExistDataValue(entity.ParentId.Value, entity.DataValue);
            if (existvalue) throw new LogicException("数据值已经存在");



            dataAccessorBasicData.Add(entity);


        }

        public BasicData GetId(long id)
        {
            return dataAccessorBasicData.GetId(id);
        }

        public void UpdateBasicData(BasicData entity)
        {
            dataAccessorBasicData.Update(entity);
        }
    }
}
