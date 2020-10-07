using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CostControlWebApplication.Services;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Application.Services.Dtos;
using System.Collections;
using System.Collections.Generic;
using CostControlWebApplication.Domain;
using BingoX;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class PlatformController : Controller
    {
        #region Staffer

        public IActionResult Staffer([FromServices] AccountService service, [FromQuery] AccounQueryRequest filterRequest)
        {
            IPagingList list = service.GetPagingList(filterRequest).ProjectedAsPagingList<AccountUserDto>();
            return View(list);
        }
        [HttpGet("~/api/Platform/Staffer")]
        public IPagingList APIStaffer([FromServices] AccountService service, [FromQuery] AccounQueryRequest filterRequest)
        {
            IPagingList list = service.GetPagingList(filterRequest).ProjectedAsPagingList<AccountUserDto>();
            return list;
        }
        [HttpPost("~/api/Platform/Staffer")]
        public void AddUser([FromServices] AccountService service, [FromBody] AccountUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Account)) throw new LogicException("帐号为空");
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new LogicException("名称为空");
            if (string.IsNullOrWhiteSpace(dto.PassWord)) throw new LogicException("密码为空");
            if (string.IsNullOrWhiteSpace(dto.ComfirmPassword)) throw new LogicException("确认密码为空");
            if (dto.PassWord != dto.ComfirmPassword) throw new LogicException("两次密码不一致");
            var entity=   dto.ProjectedAs<AccountUser>();
            service.AddUser(entity);
        }

        [HttpPut("~/api/Platform/Staffer/{id}")]
        public void EditUser([FromServices] AccountService service, [FromBody] AccountUserDto dto)
        {
            var entity = dto.ProjectedAs<AccountUser>();
            service.EditUser(entity);
        }
        #endregion
        public IActionResult Setting([FromServices] SettingService service)
        {
            SettingDto setting = service.GetSetting();
            return View(setting);
        }
        #region BasicData

        public IActionResult BasicData([FromServices] BasicDataService service, [FromQuery] string name, [FromQuery] string groupCode)
        {
            var list = service.QueryRoot(name, groupCode);
            return View(list);
        }
        [HttpGet]
        [Route("~/api/Platform/BasicData/{id}")]
        public IList<BasicDataDto> GetBasicDataList([FromServices] BasicDataService service, [FromRoute] long id)
        {
            return service.Query(id);
        }
        [HttpGet]
        [Route("~/api/Platform/BasicData/detail/{id}")]
        public BasicDataDto GetBasicDataItem([FromServices] BasicDataService service, [FromRoute] long id)
        {
            return service.Get(id);
        }
        [HttpPut]
        [Route("~/api/Platform/BasicData/{id}")]
        public void UpdateBasicData([FromServices] BasicDataService service, [FromBody] BasicDataDto dto)
        {
            service.UpdateBasicData(dto);
        }

        [HttpPost]
        [Route("~/api/Platform/BasicData")]
        public void AddBasicData([FromServices] BasicDataService service, [FromBody] BasicDataDto dto)
        {
            service.AddBasicData(dto);
        }
        [HttpGet("~/api/Platform/BasicData")]
        public IList<BasicDataDto> GetBasicData([FromServices] BasicDataService service, [FromQuery] string name, [FromQuery] string groupCode)
        {
            var list = service.QueryRoot(name, groupCode);
            return list;
        }
        #endregion
        #region SupplierService

        public IActionResult Supplier([FromServices] SupplierService service, [FromQuery] SupplierQueryRequest filterRequest)
        {
            IPagingList list = service.GetPagingList(filterRequest);
            return View(list);
        }
        [HttpGet]
        [Route("~/api/Platform/Supplier/{id}")]
        public SupplierDto GetSupplier([FromServices] SupplierService service, [FromRoute] long id)
        {
            return service.Get(id);
        }

        [HttpPut]
        [Route("~/api/Platform/Supplier/{id}")]
        public void UpdateSupplier([FromServices] SupplierService service, [FromBody] SupplierDto dto)
        {
            service.UpdateSuppiler(dto);
        }

        [HttpPost]
        [Route("~/api/Platform/Supplier")]
        public void AddSupplier([FromServices] SupplierService service, [FromBody] SupplierDto dto)
        {
            service.AddSuppiler(dto);
        }
        [HttpGet("~/api/Platform/Supplier")]
        public IPagingList<SupplierDto> GetSupplier([FromServices] SupplierService service, [FromQuery] SupplierQueryRequest filterRequest)
        {
            var list = service.GetPagingList(filterRequest);
            return list;
        }
        #endregion


    }
}
