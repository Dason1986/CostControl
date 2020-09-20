using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Services;
using System.Linq;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class FileController : Controller
    {

        [Route("/api/file/project")]
        [HttpPost]
        public FileEntryDto UploadFile([FromServices] FileStorageServie storageServie, [FromForm] Microsoft.AspNetCore.Http.IFormCollection form, [FromForm] string filetype, [FromForm] string projectId)
        {
            if (form.Files.Count == 0) throw new LogicException("");
            var file = form.Files.First();

            return storageServie.AddProjectFile(file.FileName, file.OpenReadStream(), filetype, projectId).ProjectedAs<FileEntryDto>();
        }
        [Route("/api/file/temp")]
        [HttpPost]
        public FileEntryDto TempUploadFile([FromServices] FileStorageServie storageServie, [FromForm] Microsoft.AspNetCore.Http.IFormCollection form)
        {
            if (form.Files.Count == 0) throw new LogicException("");
            var file = form.Files.First();

            return storageServie.AddTempFile(file.FileName, file.OpenReadStream()).ProjectedAs<FileEntryDto>();

        }
        [Route("/api/file/TargetCost")]
        [HttpPost]
        public FileEntryDto TargetCostUploadFile([FromServices] FileStorageServie storageServie, [FromForm] Microsoft.AspNetCore.Http.IFormCollection form,[FromForm] string targetId)
        {
            if (form.Files.Count == 0) throw new LogicException("");
            var file = form.Files.First();

            return storageServie.AddTargetCostFile(file.FileName, file.OpenReadStream(), targetId).ProjectedAs<FileEntryDto>();

        }
    }

}
