using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class ProjectCostController : Controller
    {


        public IActionResult Index([FromServices] CostInOutService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjectCostOut(queryRequest);
            return View(list);

        }
    }
    [Authorize, ApiControllerAttribute, Route("~/api/Project/costout")]
    public class  ProjectCostApiController : Controller
    {
        [HttpGet("~/api/ProjectCost")]
        public IPagingList GetProjects([FromServices] CostInOutService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjectCostOut(queryRequest);

            return list;
        }
        [HttpPost("")]
        public void AddCostout([FromServices] CostInOutService service, [FromBody] ProjectCostOutDto dto)
        {

            service.AddCostout(dto);


        }
        [HttpPut("/{id}")]
        public void EditCostout([FromServices] CostInOutService service, [FromBody] ProjectCostOutDto dto, [FromRoute] long id)
        {

            service.EditCostout(id, dto);


        }
    }
}
