using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Domain;
using CostControlWebApplication.Application.Services.Dtos;
using BingoX;
using System.IO;
using System.Linq;
using BingoX.AspNetCore;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class ProcurementController : Controller
    {


        public IActionResult Index([FromServices] ProjectProcurementService service, [FromQuery] ProjectQueryRequest queryRequest)
        {

            IPagingList list = service.GetProcurements(queryRequest).ProjectedAsPagingList<ProjectProcurementDto>();
            return View(list);

        }


    }
    [Authorize, ApiController, Route("~/api/Project/Procurement")]
    public class ProcurementApiController : Controller
    {

        public IPagingList<ProjectProcurementDto> GetProcurements([FromServices] ProjectProcurementService service, [FromQuery] ProjectQueryRequest queryRequest)
        {

            IPagingList<ProjectProcurementDto> list = service.GetProcurements(queryRequest).ProjectedAsPagingList<ProjectProcurementDto>();
            return list;

        }

        [HttpGet("draft")]
        public long GetId([FromServices] ProjectProcurementService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
        
          ProjectProcurement procurement=  service.GetDraftProcurement( );

            return procurement.ID;

        }
        [HttpGet("{id}")]
        public ProjectProcurementDto Get([FromServices] ProjectProcurementService service, [FromRoute] long id)
        {

            ProjectProcurementDto procurement = service.GetProcurement(id);

            return procurement;

        }
        [Route("")]
        [HttpPost()]
        public void Add([FromServices] ProjectProcurementService service, [FromBody] ProjectProcurementDto dto)
        {

            service.Edit(dto);


        }

      
        [Route("file")]
        [HttpPost]
        public ProjectAboutFileDto UploadFile([FromServices] ProjectMasterService projectService, [FromServices] FileStorageServie storageServie, [FromForm] Microsoft.AspNetCore.Http.IFormCollection form, [FromForm] long procurementid, [FromForm] long projectId)
        {
            if (form.Files.Count == 0) throw new LogicException("");
            var file = form.Files.First();
            var projectCode = projectService.GetProjectCode(projectId);
            var path = Path.Combine("project", projectCode, "procurement", file.FileName);
            var filedto = storageServie.AddFile(file.OpenReadStream(), path);
            return projectService.AddAboutFile(projectId, procurementid, ProjectFileType.Procurement, filedto).ProjectedAs<ProjectAboutFileDto>();

        }

    }
}
