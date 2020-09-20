namespace CostControlWebApplication.Services
{
    public class UpdatePasswordRequest
    {
        /// <summary>
        /// 用户编号 
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string ComfirmPassword { get; set; }
    }
}
