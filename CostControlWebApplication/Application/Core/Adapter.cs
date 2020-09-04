using AutoMapper;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Application.Services.Dtos;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CostControlWebApplication
{
    public static class Adapter
    {
        public static IMapper Mapping { get; set; }
        public static IPagingList<TDes> ProjectedAsPagingList<TDes>(this IEnumerable pagingList, int total, int pageIndex = 0, int pageSize = 10)
        {
            var totalPages = (int)System.Math.Ceiling((double)total / pageSize);
            return new QueryPagerResponse<TDes>(ProjectedAsCollection<TDes>(pagingList), pageIndex, 10, total) { TotalPages = totalPages };//(ProjectedAsCollection<TDes>(pagingList), total);

        }
        public static IPagingList<TDes> ProjectedAsPagingList<TDes>(this IPagingList pagingList )
        {
            var totalPages = (int)System.Math.Ceiling((double)pagingList.Total / pagingList.PageSize);
            return new QueryPagerResponse<TDes>(ProjectedAsCollection<TDes>(pagingList.Items), pagingList.PageIndex, pagingList.PageSize, pagingList.Total) { TotalPages = totalPages };//(ProjectedAsCollection<TDes>(pagingList), total);

        }
        /// <summary>
        /// Project a type using a DTO
        /// </summary>
        /// <typeparam name="TProjection">The dto projection</typeparam>
        /// <param name="items"></param>
        /// <returns>The projected type</returns>
        public static TProjection ProjectedAs<TProjection>(this object items, IMapper mapping = null)

        {

            if (items == null) return default(TProjection);

            return mapping != null ? mapping.Map<TProjection>(items) : Mapping.Map<TProjection>(items);
        }
        /// <summary>
        /// Project a type using a DTO
        /// </summary>
        /// <typeparam name="TProjection">The dto projection</typeparam>
        /// <param name="items"></param>
        /// <returns>The projected type</returns>
        public static TProjection ProjectedAs<TSource, TProjection>(this TSource items, TProjection projection, IMapper mapping = null)
        {

            if (items == null) return projection;

            return mapping != null ? mapping.Map<TSource, TProjection>(items, projection) : Mapping.Map<TSource, TProjection>(items, projection);
        }
        /// <summary>
        /// projected a enumerable collection of items
        /// </summary>
        /// <typeparam name="TProjection">The dtop projection type</typeparam>
        /// <param name="items">the collection of entity items</param>
        /// <returns>Projected collection</returns>
        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable items, IMapper mapping = null)

        {

            if (items == null) return BingoX.Utility.EmptyUtility<TProjection>.EmptyArray.ToList();
            List<TProjection> tolist;


            tolist = mapping != null ? mapping.Map<List<TProjection>>(items) : Mapping.Map<List<TProjection>>(items);



            return tolist.ToList();
        }
        /// <summary>
        /// projected a enumerable collection of items
        /// </summary>
        /// <typeparam name="TProjection">The dtop projection type</typeparam>
        /// <param name="items">the collection of entity items</param>
        /// <returns>Projected collection</returns>
        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<object> items, IMapper mapping = null)

        {

            if (items == null) return BingoX.Utility.EmptyUtility<TProjection>.EmptyArray.ToList();
            List<TProjection> tolist;
            var temlplist = items.ToList();


            tolist = mapping != null ? mapping.Map<List<TProjection>>(temlplist) : Mapping.Map<List<TProjection>>(temlplist);



            return tolist.ToList();
        }
        /// <summary>
        /// projected a enumerable collection of items
        /// </summary>
        /// <typeparam name="TProjection">The dtop projection type</typeparam>
        /// <param name="items">the collection of entity items</param>
        /// <returns>Projected collection</returns>
        public static TProjection[] ProjectedAsArray<TProjection>(this IEnumerable<object> items, IMapper mapping = null)

        {

            if (items == null) return BingoX.Utility.EmptyUtility<TProjection>.EmptyArray;
            List<TProjection> tolist;
            var temlplist = items.ToList();


            tolist = mapping != null ? mapping.Map<List<TProjection>>(temlplist) : Mapping.Map<List<TProjection>>(temlplist);



            return tolist.ToArray();
        }

    }
}
