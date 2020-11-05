using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BingoX.ComponentModel.Data;
using CostControlWebApplication.Services;
using CostControlWebApplication.Application.Services.Dtos;

namespace CostControlWebApplication.Controllers
{
    [Authorize]
    public class StandingbookController : Controller
    {




        public IActionResult Index( )
        {

   
            return View( );

        }
    }
}
