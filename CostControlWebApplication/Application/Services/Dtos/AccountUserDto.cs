using System.Linq;
using System.Threading.Tasks;

namespace CostControlWebApplication.Application.Services.Dtos
{
    public class AccountUserDto : Dto
    {
       
        public int State { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string RoleType { get; set; }
       
        public string Email { get; set; }
        public string CreateDate { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string ComfirmPassword { get; set; }
    }
}
