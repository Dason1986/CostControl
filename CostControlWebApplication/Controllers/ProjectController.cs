using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CostControlWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using BingoX;
using CostControlWebApplication.Application.Data;
using System.IO;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {


        public IActionResult Index(  [FromServices] ProjectService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
          
            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<ProjectInfoListItmeDto>();
            return View(list);

        }
    }
    [Authorize, ApiControllerAttribute, Route("~/api/Project")]
    public class ProjectApiController : Controller
    {
        [HttpGet()]
        public IPagingList GetProjects([FromServices] ProjectService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<ProjectInfoListItmeDto>();

            return list;
        }
        [HttpGet("{id}")]
        public ProjectInfoDto GetProject([FromServices] ProjectService service, [FromRoute] long id)
        {

            return service.GetProject(id);


        }
        [HttpGet("Search")]
        public OptionEntry[] SearchProject([FromServices] ProjectService service, [FromQuery] string code)
        {

            return service.SearchProject(code);


        }
        [Route("file")]
        [HttpPost]
        public void UploadFile([FromServices] ProjectService projectService, [FromServices] FileStorageServie storageServie, [FromForm] Microsoft.AspNetCore.Http.IFormCollection form, [FromForm] long filetype, [FromForm] long projectId)
        {
            if (form.Files.Count == 0) throw new LogicException("");
            var file = form.Files.First();
            var projectCode = projectService.GetProjectCode(projectId);
          var path=Path.Combine( "project", projectCode, file.FileName);
            var filedto= storageServie.AddFile(file.OpenReadStream(), path) ;
            projectService.AddAboutFile(projectId,filetype,filedto);
              
        }
        [HttpPost("Project")]
        public void AddProject([FromServices] ProjectService service, [FromBody] ProjectInfoDto dto)
        {

            service.Add(dto);


        }
        [HttpPost("costout")]
        public void AddCostout([FromServices] ProjectService service, [FromBody] ProjectCostOutDto dto)
        {

            service.AddCostout(dto);


        }
        [HttpPut("costout/{id}")]
        public void EditCostout([FromServices] ProjectService service, [FromBody] ProjectCostOutDto dto,[FromRoute] long id)
        {

            service.EditCostout(id,dto);


        }
        [HttpPost("costin")]
        public void AddCostin([FromServices] ProjectService service, [FromBody] ProjectCostInDto dto)
        {

            service.AddCostin(dto);


        }
        [HttpPut("costin/{id}")]
        public void EditCostin([FromServices] ProjectService service, [FromBody] ProjectCostInDto dto, [FromRoute] long id)
        {

            service.EditCostin(id,dto);


        }
    }
}
