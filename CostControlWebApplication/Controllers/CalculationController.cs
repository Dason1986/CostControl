using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class CalculationController : Controller
    {


        public IActionResult Index()
        {

            return View();

        }
    }
    [Authorize, ApiControllerAttribute, Route("~/api/Project/Calculation")]

    public class CalculationApiController : Controller
    {
        [HttpGet()]
        public IPagingList GetList([FromServices] CalculationService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetCalculations(queryRequest).ProjectedAsPagingList<ProjectCalculationDto>();
            return list;


        }

       

        [HttpGet("{id}")]
        public ProjectCalculationDto Get([FromServices] CalculationService service, [FromRoute] long id)
        {
            var dto = service.Get(id).ProjectedAs<ProjectCalculationDto>();
            return dto;

        }
      
    }
}
