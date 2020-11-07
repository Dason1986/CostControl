using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CostControlWebApplication.Services;
using BingoX;
using System.IO;
using CostControlWebApplication.Application.Services.Dtos;
using Microsoft.AspNetCore.Http;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Controllers
{
    [Authorize, ApiController, Route("~/api/Project")]
    public class ProjectApiController : Controller
    {


        [HttpGet("Search")]
        public OptionEntry[] SearchProject([FromServices] ProjectMasterService service, [FromQuery] string code)
        {

            return service.SearchProject(code);


        }
        [Route("file")]
        [HttpPost]
        public ProjectAboutFileDto UploadFile([FromServices] ProjectMasterService projectService, [FromServices] FileStorageServie storageServie, [FromForm] IFormCollection form)
        {
            if (form.Files.Count == 0) throw new LogicException("");
            var file = form.Files.First();

            var path = Path.Combine("Temp", file.FileName);
            var filedto = storageServie.AddFile(file.OpenReadStream(), path);

            var dto = projectService.AddAboutFile(0, 0, ProjectFileType.Temp, filedto);
            return dto.ProjectedAs<ProjectAboutFileDto>();

        }

    }
}
