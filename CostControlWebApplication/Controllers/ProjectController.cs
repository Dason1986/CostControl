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


        public IActionResult Index([FromServices] ProjectService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<ProjectInfoListItmeDto>();
            return View(list);

        }
        [HttpGet("~/api/Project")]
        public IPagingList GetProjects([FromServices] ProjectService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<ProjectInfoListItmeDto>();

            return list;
        }
        [HttpGet("~/api/Project/{id}")]
        public ProjectInfoDto GetProject([FromServices] ProjectService service, [FromRoute] long id)
        {

            return service.GetProject(id);


        }
        [Route("/api/Project/file")]
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
        [HttpPost("~/api/Project")]
        public void AddProject([FromServices] ProjectService service, [FromBody] ProjectInfoDto dto)
        {

            service.Add(dto);


        }
        [HttpPost("~/api/Project/costout")]
        public void AddCostout([FromServices] ProjectService service, [FromBody] ProjectCostOutDto dto)
        {

            service.AddCostout(dto);


        }
        [HttpPost("~/api/Project/costin")]
        public void AddCostin([FromServices] ProjectService service, [FromBody] ProjectCostInDto dto)
        {

            service.AddCostin(dto);


        }
    }
}
