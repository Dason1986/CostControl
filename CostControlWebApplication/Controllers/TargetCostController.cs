﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class TargetCostController : Controller
    {


        public IActionResult Index([FromServices] ProjectService service, [FromQuery] ProjectQueryRequest queryRequest)
        {
            IPagingList list = service.GetProjects(queryRequest).ProjectedAsPagingList<ProjectInfoListItmeDto>();
            return View(list);

        }

        [HttpPost("~/api/TargetCost")]
        public void Add([FromServices] TargetCostService service)
        {

        }
    }
}
