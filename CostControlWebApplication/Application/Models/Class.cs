using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostControlWebApplication.Application
{
    public interface IDateDto
    {
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
    }
    public interface IDate : IEstimatedDate
    {
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public interface IEstimatedDate
    {
        DateTime? EstimatedBeginDate { get; set; }
        DateTime? EstimatedEndDate { get; set; }
    }
}
