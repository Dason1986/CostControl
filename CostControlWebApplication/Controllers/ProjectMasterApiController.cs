using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BingoX.Helper;
using BingoX;
using System.IO;
using CostControlWebApplication.Domain;

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
            service.Add(dto);


        }
        [HttpPut("{id}")]
        public void Edit([FromServices] ProjectMasterService service, [FromBody] ProjectMasterDto dto)
        {
          service.Edit(dto);


        }
        [Route("file")]
        [HttpPost]
        public ProjectAboutFileDto UploadFile([FromServices] ProjectMasterService service, 
            [FromServices] FileStorageServie storageServie,
            [FromForm] IFormCollection form,
            [FromForm]long id
            )
        {
            if (form.Files.Count == 0) throw new LogicException("");
            var file = form.Files.First();
            var entity = service.GetProject(id);
            if (entity==null) throw new LogicException("");
            var path = Path.Combine("project", entity.Code, ProjectFileType.Create.GetHashCode().ToString(),  file.FileName);
            var filedto = storageServie.AddFile(file.OpenReadStream(), path);
      
            var dto = service.AddAboutFile(0, 0, ProjectFileType.Temp, filedto);           
       
            return dto.ProjectedAs<ProjectAboutFileDto>();

        }

        [HttpGet("{id}")]
        public ProjectMasterDto GetProject([FromServices] ProjectMasterService service, [FromRoute] long id)
        {

            return service.GetProject(id);


        }
    }
}
