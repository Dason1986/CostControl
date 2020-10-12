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


        public IActionResult Staffer([FromServices] AccountService service, [FromQuery] AccounQueryRequest filterRequest)
        {
            IPagingList list = service.GetPagingList(filterRequest).ProjectedAsPagingList<AccountUserDto>();
            return View(list);
        }
        public IActionResult Setting([FromServices] SettingService service)
        {
            SettingDto setting = service.GetSetting();
            return View(setting);
        }
        public IActionResult BasicData([FromServices] BasicDataService service, [FromQuery] string name, [FromQuery] string groupCode)
        {
            var list = service.QueryRoot(name, groupCode);
            return View(list);
        }
        public IActionResult Supplier([FromServices] SupplierService service, [FromQuery] SupplierQueryRequest filterRequest)
        {
            IPagingList list = service.GetPagingList(filterRequest);
            return View(list);
        }
    }
    [Authorize, ApiControllerAttribute, Route("~/api/Platform")]
    public class PlatformApiController : Controller
    {

        #region Staffer  
        [HttpGet("Staffer")]
        public IPagingList APIStaffer([FromServices] AccountService service, [FromQuery] AccounQueryRequest filterRequest)
        {
            IPagingList list = service.GetPagingList(filterRequest).ProjectedAsPagingList<AccountUserDto>();
            return list;
        }
        [HttpPost("Staffer")]
        public void AddUser([FromServices] AccountService service, [FromBody] AccountUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Account)) throw new LogicException("帐号为空");
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new LogicException("名稱为空");
            if (string.IsNullOrWhiteSpace(dto.PassWord)) throw new LogicException("密碼为空");
            if (string.IsNullOrWhiteSpace(dto.ComfirmPassword)) throw new LogicException("确认密碼为空");
            if (dto.PassWord != dto.ComfirmPassword) throw new LogicException("两次密碼不一致");
            var entity = dto.ProjectedAs<AccountUser>();
            service.AddUser(entity);
        }

        [HttpPut("Staffer/{id}")]
        public void EditUser([FromServices] AccountService service, [FromBody] AccountUserDto dto)
        {
            var entity = dto.ProjectedAs<AccountUser>();
            service.EditUser(entity);
        }
        #endregion
    
        #region BasicData

      
        [HttpGet]
        [Route("BasicData/{id}")]
        public IList<BasicDataDto> GetBasicDataList([FromServices] BasicDataService service, [FromRoute] long id)
        {
            return service.Query(id);
        }
        [HttpGet]
        [Route("BasicData/detail/{id}")]
        public BasicDataDto GetBasicDataItem([FromServices] BasicDataService service, [FromRoute] long id)
        {
            return service.Get(id);
        }
        [HttpPut]
        [Route("BasicData/{id}")]
        public void UpdateBasicData([FromServices] BasicDataService service, [FromBody] BasicDataDto dto)
        {
            service.UpdateBasicData(dto);
        }

        [HttpPost]
        [Route("BasicData")]
        public void AddBasicData([FromServices] BasicDataService service, [FromBody] BasicDataDto dto)
        {
            service.AddBasicData(dto);
        }
        [HttpGet("BasicData")]
        public IList<BasicDataDto> GetBasicData([FromServices] BasicDataService service, [FromQuery] string name, [FromQuery] string groupCode)
        {
            var list = service.QueryRoot(name, groupCode);
            return list;
        }
        #endregion
        #region SupplierService

     
        [HttpGet]
        [Route("Supplier/{id}")]
        public SupplierDto GetSupplier([FromServices] SupplierService service, [FromRoute] long id)
        {
            return service.Get(id);
        }

        [HttpPut]
        [Route("Supplier/{id}")]
        public void UpdateSupplier([FromServices] SupplierService service, [FromBody] SupplierDto dto)
        {
            service.UpdateSuppiler(dto);
        }

        [HttpPost]
        [Route("Supplier")]
        public void AddSupplier([FromServices] SupplierService service, [FromBody] SupplierDto dto)
        {
            service.AddSuppiler(dto);
        }
        [HttpGet("Supplier")]
        public IPagingList<SupplierDto> GetSupplier([FromServices] SupplierService service, [FromQuery] SupplierQueryRequest filterRequest)
        {
            var list = service.GetPagingList(filterRequest);
            return list;
        }
        #endregion


    }
}
