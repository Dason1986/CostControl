using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostControlWebApplication.Application
{
    public interface IDateDto
    {
        string BeginDate { get; set; }
        string EndDate { get; set; }
    }
    public interface IDate : IEstimatedDate
    {
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
    }
    public interface IEstimatedDate
    {
        DateTime? EstimatedBeginDate { get; set; }
        DateTime? EstimatedEndDate { get; set; }
    }
}
