using System.ComponentModel;

namespace CostControlWebApplication.Domain
{
    public enum ProcurementState
    {
   
      
        Draft = 0,
        [Description("保存")]
        Save = 1,
        [Description("提交")]
        Submit = 2,
       
    }
}
