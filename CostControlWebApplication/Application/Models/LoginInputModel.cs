namespace CostControlWebApplication.Models
{
    public class LoginInputModel
    {


        /// <summary>
        /// 
        /// </summary>
        public string ReturnUrl { get; set; }

        
        /// <summary>
        /// 帐号
        /// </summary>

        public string Account { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>

        public string Password { get; set; }
    }
}
