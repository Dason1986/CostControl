using BingoX.Domain;
using System.Collections.Generic;

namespace CostControlWebApplication.Domain
{
    public class BasicData : Entity, ISnowflakeEntity<BasicData>
    {
        /// <summary>
        /// 父類编号
        /// </summary>

        public long? ParentId { get; set; }





        /// <summary>
        /// 父類编号
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public virtual ICollection<BasicData> Items { get; set; }


        /// <summary>
        /// 名称
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// 組別
        /// </summary>

        public string GroupCode { get; set; }

        /// <summary>
        /// 数据值
        /// </summary>

        public string DataValue { get; set; }
        /// <summary>
        /// 排序
        /// </summary>

        public int IndexNo { get; set; }

        /// <summary>
        /// 描述
        /// </summary>

        public string Remark { get; set; }
        public CommonState State { get; set; }
    }
}
