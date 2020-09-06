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
using BingoX;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
       

        public IActionResult Index([FromServices] IProjectService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<ProjectInfoListItmeDto>();
            return View(list);
        
        }

        
    }
    [Authorize]
    public class FileController : Controller
    {
       
        [Route("/api/file/posts")]
        [HttpPost]
        public void UploadFile([FromForm] Microsoft.AspNetCore.Http.IFormCollection form, [FromForm] string filetype , [FromForm] string projectId)
        {
            if (form.Files.Count == 0) throw new LogicException("");


        }

        
    }
}
