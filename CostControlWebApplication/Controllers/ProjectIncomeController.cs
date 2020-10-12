using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class ProjectIncomeController : Controller
    {


        public IActionResult Index([FromServices] ProjectService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjectCostin(queryRequest);
            return View(list);

        }
    }
    [Authorize, ApiControllerAttribute, Route("~/api/ProjectIncome")] 
    public class ProjectIncomeApiController : Controller
    {
    [HttpGet()]
        public IPagingList GetProjects([FromServices] ProjectService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjectCostin(queryRequest);

            return list;
        }

    }
}
