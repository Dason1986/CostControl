using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class TargetCostController : Controller
    {


        public IActionResult Index([FromServices] TargetCostService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<TargetCostListItmeDto>();
            return View(list);

        }
    } 
    [Authorize, ApiControllerAttribute, Route("~/api/TargetCost")]

    public class TargetCostApiController : Controller
    {
        [HttpGet()]
        public IPagingList GetList([FromServices] TargetCostService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<TargetCostListItmeDto>();
            return list;


        }

        [HttpPost()]
        public void AddTargetCost([FromServices] TargetCostService service, [FromBody] TargetCostDto dto)
        {
           
            service.Add(dto);


        }

        [HttpGet("{id}")]
        public TargetCostDto Get([FromServices] TargetCostService service, [FromRoute] long id)
        {
            var dto = service.Get(id);
            return dto;

        }
        [HttpGet("detail/{id}")]
        public TargetCostDetailDto[] GetDetails([FromServices] TargetCostService service, [FromRoute] long id)
        {
            var dto = service.GetDetails(id).ProjectedAsArray<TargetCostDetailDto>();
            return dto;

        }
    }
}
