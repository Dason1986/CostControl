using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CostControlWebApplication.Services;
using BingoX;
using System.IO;

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

    }
}
