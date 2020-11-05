using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;
using System.Collections.Generic;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class ProjectIncomeController : Controller
    {


        public IActionResult Index([FromServices] CostInOutService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjectCostin(queryRequest);
            return View(list);

        }
    }
    [Authorize, ApiControllerAttribute, Route("~/api/Project/costin")] 
    public class ProjectIncomeApiController : Controller
    {
        [HttpGet("~/api/ProjectIncome")]
        public IPagingList GetProjects([FromServices] CostInOutService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjectCostin(queryRequest);

            return list;
        }
        [HttpPost("")]
        public void AddCostin([FromServices] CostInOutService service, [FromBody] ProjectCostInDto dto)
        {

            service.AddCostin(dto);


        }
        [HttpGet("~/api/Project/costins/{id}")]
        public IList<ProjectCostInDto> GetCostins([FromServices] CostInOutService service, [FromRoute] long id)
        {

            return service.GetProjectCostins(id);


        }
        [HttpGet("~/api/Project/costin/{id}")]
        public ProjectCostInDto GetCostin([FromServices] CostInOutService service,   [FromRoute] long id)
        {

          return   service.GetProjectCostin(id);


        }
        [HttpPut("~/api/Project/costin/{id}")]
        public void EditCostin([FromServices] CostInOutService service, [FromBody] ProjectCostInDto dto, [FromRoute] long id)
        {

            service.EditCostin(id, dto);


        }
    }
}
