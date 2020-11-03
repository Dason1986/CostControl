using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;

namespace CostControlWebApplication.Controllers
{
    [Authorize, ApiControllerAttribute, Route("~/api/Project/Standingbook")]
    public class ProjectStandingbookApiController : Controller
    {

        [HttpGet("{id}")]
        public ProjectStandingbookDto GetProject([FromServices] StandingbookService service, [FromRoute] long id)
        {

            return service.GetProject(id);


        }


        [HttpPost("")]
        public void AddProject([FromServices] StandingbookService service, [FromBody] ProjectStandingbookDto dto)
        {

            service.Add(dto);


        }
        [HttpPost("costout")]
        public void AddCostout([FromServices] CostInOutService service, [FromBody] ProjectCostOutDto dto)
        {

            service.AddCostout(dto);


        }
        [HttpPut("costout/{id}")]
        public void EditCostout([FromServices] CostInOutService service, [FromBody] ProjectCostOutDto dto, [FromRoute] long id)
        {

            service.EditCostout(id, dto);


        }
        [HttpPost("costin")]
        public void AddCostin([FromServices] CostInOutService service, [FromBody] ProjectCostInDto dto)
        {

            service.AddCostin(dto);


        }
        [HttpPut("costin/{id}")]
        public void EditCostin([FromServices] CostInOutService service, [FromBody] ProjectCostInDto dto, [FromRoute] long id)
        {

            service.EditCostin(id, dto);


        }
    }
}
