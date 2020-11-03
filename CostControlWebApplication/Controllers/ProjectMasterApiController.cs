using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;

namespace CostControlWebApplication.Controllers
{
    [Authorize, ApiControllerAttribute, Route("~/api/Project/Master")]
    public class ProjectMasterApiController : Controller
    {
        [HttpGet("")]
        public IPagingList GetProjects([FromServices] ProjectMasterService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<ProjectMasterDto>();

            return list;
        }
        [HttpPost("")]
        public void Add([FromServices] ProjectMasterService service, [FromBody] ProjectMasterDto dto)
        {
            service.Add(dto) ;

        
        }
        [HttpGet("{id}")]
        public ProjectMasterDto GetProject([FromServices] ProjectMasterService service, [FromRoute] long id)
        {

            return service.GetProject(id);


        }
    }
}
