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
using BingoX.Helper;
using BingoX.Utility;

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

      
      
        [Route("{id}")]
        [HttpPost()]
        public void  Submit([FromServices] ProjectProcurementService service, [FromRoute] long id)
        {

            service.Submit(id);


        }
        [Route("")]
        [HttpPost()]
        public void Add([FromServices] ProjectProcurementService service, [FromBody] ProjectProcurementDto dto)
        {

            service.AddOrEdit(dto);


        }
        [HttpGet("{id}")]
        public ProjectProcurementDto Get([FromServices] ProjectProcurementService service, [FromRoute] long id)
        {

            ProjectProcurementDto procurement = service.GetProcurement(id);
            procurement.AddFiles = EmptyUtility<long>.EmptyArray;
            return procurement;

        }

       

    }
}
