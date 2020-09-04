using BingoX.ComponentModel.Data;
using System.Collections;
using System.Collections.Generic;

namespace CostControlWebApplication.Application.Services.Dtos
{
    public class QueryPagerResponse<TModel> : IPagingList<TModel>
    {


        public QueryPagerResponse()
        {
        }

        public QueryPagerResponse(List<TModel> list, int pageIndex, int pageSize, int total)
        {
            Items = list;
            PageIndex = pageIndex;
            PageSize = pageSize;
            Total = total;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<TModel> Items { get; set; }

        ICollection<TModel> IPagingList<TModel>.Items { get { return Items; } }

        ICollection IPagingList.Items { get { return Items; } }


    }
}
