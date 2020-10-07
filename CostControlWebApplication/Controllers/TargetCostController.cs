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
        [HttpGet("~/api/TargetCost")]
        public IPagingList GetList([FromServices] TargetCostService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<TargetCostListItmeDto>();
            return list;


        }

        [HttpPost("~/api/TargetCost")]
        public void AddTargetCost([FromServices] TargetCostService service, [FromBody] TargetCostDto dto)
        {
            TargetCost entity = dto.ProjectedAs<TargetCost>();
            service.Add(entity);


        }

        [HttpGet("~/api/targetcost/{id}")]
        public TargetCostDto Get([FromServices] TargetCostService service, [FromRoute] long id)
        {
            var dto = service.Get(id);
            return dto;

        }
        [HttpGet("~/api/targetcost/detail/{id}")]
        public TargetCostDetailDto[] GetDetails([FromServices] TargetCostService service, [FromRoute] long id)
        {
            var dto = service.GetDetails(id).ProjectedAsArray<TargetCostDetailDto>();
            return dto;

        }
    }
}
