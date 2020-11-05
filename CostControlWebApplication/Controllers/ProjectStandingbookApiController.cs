using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;
using BingoX.ComponentModel.Data;

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

        [HttpGet("")]
        public IPagingList Index([FromServices] StandingbookService service, [FromQuery] ProjectQueryRequest queryRequest)
        {

            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<ProjectStandingbookDto>();
            return list;

        }


    }
}
