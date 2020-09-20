using BingoX;
using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using CostControlWebApplication.Models;
using System.Threading.Tasks;

namespace CostControlWebApplication.Services
{
    public class AccountService : IService
    {
        public AccountService(AccountRepository repository, IBoundedContext bounded)
        {
            this.repository = repository;
            Bounded = bounded;
        }
        private readonly AccountRepository repository;
        public IBoundedContext Bounded { get; private set; }


        public IPagingList<AccountUserDto> GetPagingList(AccounQueryRequest filterRequest)
        {
            Specification<AccountUser> specification = new Specification<AccountUser>();
            specification.SetPage(filterRequest);
            return repository.GetPagingList(specification).ProjectedAsPagingList<AccountUserDto>();
        }
        public void DeleteUser(long userid)
        {
            if (userid <= 0) throw new LogicException("用户无效");
            AccountUser user = repository.GetUserById(userid);
            if (user == null) throw new LogicException("用户不存在");
            if (user.RoleType == RoleType.Admin) throw new LogicException("管理员不能删除");


            repository.DeleteUser(user);
            repository.UnitOfWork.Commit();
        }
        public void AddUser(AccountUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Account)) throw new LogicException("帐号为空");
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new LogicException("名称为空");
            if (string.IsNullOrWhiteSpace(dto.PassWord)) throw new LogicException("密码为空");
            if (string.IsNullOrWhiteSpace(dto.ComfirmPassword)) throw new LogicException("确认密码为空");
            if (dto.PassWord != dto.ComfirmPassword) throw new LogicException("两次密码不一致");
            AccountUser user = repository.GetUser(dto.Account);
            if (user != null) throw new LogicException("帐号已经存在，不能添加");
            user = new AccountUser()
            {
                ID = Bounded.Generator.New(),
                Account = dto.Account,
                Name = dto.Name,

                Pwd = BingoX.Security.SecurityExtension.MD5.Encrypt(dto.PassWord),

                State = CommonState.Enabled,
                CreateDate = Bounded.DateTimeService.GetNow(),
            };
            repository.AddUser(user);
            repository.Commit();
        }
        public void UpdatePassWord(UpdatePasswordRequest updatePasswordRequest)
        {
            if (updatePasswordRequest == null) throw new LogicException("无效请求");
            if (updatePasswordRequest.UserId <= 0) throw new LogicException("用户无效");
            if (updatePasswordRequest.Password == updatePasswordRequest.ComfirmPassword) throw new LogicException("两次密码不一致");
            var pwdmd5 = BingoX.Security.SecurityExtension.MD5.Encrypt(updatePasswordRequest.Password);
            AccountUser user = repository.GetUserById(updatePasswordRequest.UserId);
            if (user == null) throw new LogicException("用户不存在");
            user.Pwd = pwdmd5;
            repository.UpdateUser(user);
            repository.UnitOfWork.Commit();
        }
        public void EditUser(AccountUserDto dto)
        {
            AccountUser user = repository.GetUserById(dto.ID);
            user.Name = dto.Name;
            user.Email = dto.Email;

            repository.UpdateUser(user);
            repository.UnitOfWork.Commit();
        }

        public AccountUser Login(string account, string password)
        {
            var pwd = BingoX.Security.SecurityExtension.MD5.Encrypt(password);
            return repository.Get(account, pwd);
        }
    }
}
