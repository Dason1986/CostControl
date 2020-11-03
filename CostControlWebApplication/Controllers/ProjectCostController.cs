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
    [Authorize, ApiControllerAttribute, Route("~/api/ProjectCost")]
    public class  ProjectCostApiController : Controller
    {
        [HttpGet()]
        public IPagingList GetProjects([FromServices] CostInOutService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjectCostOut(queryRequest);

            return list;
        }
    }
}
