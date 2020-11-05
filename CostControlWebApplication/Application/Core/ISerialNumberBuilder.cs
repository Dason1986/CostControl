namespace CostControlWebApplication
{
    /// <summary>
    /// 序號生成器
    /// </summary>
    public interface ISerialNumberBuilder
    {
        /// <summary>
        /// 當前號碼
        /// </summary>
        int CurrentNumber { get; }

        /// <summary>
        /// 序號格式
        /// </summary>
        string SerialNumberFormat { get; }

 
         

        /// <summary>
        /// 取出最新序號
        /// </summary>
        /// <returns></returns>
        string Dequeue();


      
    }
}
