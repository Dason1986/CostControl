using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BingoX.Helper;

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
        //[HttpPost("")]
        //public void Add([FromServices] ProjectMasterService service, [FromBody] ProjectMasterDto dto)
        //{
        //    service.Add(dto) ;


        //}

        [HttpPost("")]
        public void Add([FromServices] ProjectMasterService service, [FromForm] ProjectMasterDto dto, [FromForm] IFormCollection form)
        {
            var file = form.Files.First();
            var filearray = file.OpenReadStream().ToArray();
            service.Add(dto, new BingoX.ComponentModel.Compress.CompressEntry { Name = file.FileName, FileContent = filearray });


        }
        [HttpGet("{id}")]
        public ProjectMasterDto GetProject([FromServices] ProjectMasterService service, [FromRoute] long id)
        {

            return service.GetProject(id);


        }
    }
}
