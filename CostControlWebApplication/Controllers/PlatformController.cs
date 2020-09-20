using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CostControlWebApplication.Services;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Application.Services.Dtos;
using System.Collections;
using System.Collections.Generic;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class PlatformController : Controller
    {

        public IActionResult Staffer([FromServices] AccountService service, [FromQuery] AccounQueryRequest filterRequest)
        {
            IPagingList list = service.GetPagingList(filterRequest);
            return View(list);
        }
        public IActionResult Setting([FromServices] SettingService service)
        {
            SettingDto setting = service.GetSetting();
            return View(setting);
        }
        public IActionResult Supplier([FromServices] SupplierService service, [FromQuery] SupplierQueryRequest filterRequest)
        {
            IPagingList list = service.GetPagingList(filterRequest);
            return View(list);
        }
        public IActionResult BasicData([FromServices] BasicDataService service)
        {
            var list = service.QueryRoot();
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
        public IList<BasicDataDto> APIStaffer([FromServices] BasicDataService service, [FromQuery] string name, [FromQuery] string groupCode)
        {
            var list = service.QueryRoot(name, groupCode);
            return list;
        }
        [HttpGet("~/api/Platform/Staffer")]
        public IPagingList APIStaffer([FromServices] AccountService service, [FromQuery] AccounQueryRequest filterRequest)
        {
            IPagingList list = service.GetPagingList(filterRequest);
            return list;
        }
        [HttpPost("~/api/Platform/Staffer")]
        public void AddUser([FromServices] AccountService service, [FromBody] AccountUserDto dto)
        {
            service.AddUser(dto);
        }

        [HttpPut("~/api/Platform/Staffer/{id}")]
        public void EditUser([FromServices] AccountService service, [FromBody] AccountUserDto dto)
        {
            service.EditUser(dto);
        }
    }
}
