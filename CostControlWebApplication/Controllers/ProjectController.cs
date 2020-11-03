using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CostControlWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Domain;
using CostControlWebApplication.Application.Data;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class ProjectMasterController : Controller
    {


        public IActionResult Index( )
        {

          
            return View( );

        }


    }
}
