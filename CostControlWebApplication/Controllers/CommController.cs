using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CostControlWebApplication.Services;
using BingoX.AspNetCore;

namespace CostControlWebApplication.Controllers
{
    [Authorize, ApiControllerAttribute, Route("~/api/comm")]
    public class CommController : Controller
    {

        [HttpGet("id")]
        public object GetId([FromServices] IBoundedContext service, [FromQuery] ProjectQueryRequest queryRequest)
        {

         
            return service.Generator.New();

        }


    }
}
