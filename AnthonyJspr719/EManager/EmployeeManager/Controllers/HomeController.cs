using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeManager.Models;
using MediatR;
using EManager.Application.SystemCommand.Commands;
using EManager.Application.SystemCommand.Queries;

namespace EmployeeManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator mediator;
        public class ForRole
        {
            public enum Role : int
            {
                Admin = 1,
                Regular = 2
            }
            public Role UserRole { get; set; }
        };

        


        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
          
        }

        public IActionResult Index()
        {
            return View();
        }
        
        


        [HttpGet]
        public IActionResult RegisterEmployee()
        {
           
            return View(Startup.currentUser);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterEmployee(UserVM employee)
        {
            if (employee.Lastname != null && employee.Username != null && employee.Password != null)
            {
                var _retVal = await mediator.Send(new SaveInfoCommand { EmployeeInfo = employee });

                return Json(true);
            }

            else
            {
                return Json(false);
            }          
        }

       
        [HttpGet]
        public  IActionResult LogIn()
        {

            return  View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVM employee)
        {
            
            var _retVal = await mediator.Send(new VerifyLoginQuery { User = employee});

            if (_retVal != null)
            {
                Startup.currentUser = _retVal;
                
                var _timeIn = await mediator.Send(new TimeInCheckerQuery { UserID = Startup.currentUser.ID });
                var _timeOut = await mediator.Send(new TimeOutCheckerQuery { UserID = Startup.currentUser.ID});

                if (_timeIn == true && _timeOut == true)
                {
                    Startup.currentUser.LogType = LogType.None;
                }
                else if (_timeIn == false && _timeOut == false)
                {
                    Startup.currentUser.LogType = LogType.TimeIn;
                }
                else if (_timeIn == true && _timeOut == false)
                {
                    Startup.currentUser.LogType = LogType.TimeOut;
                }

                return Json(true);
            }
            else
            {

                return Json(false);
            }
        }

        public async Task<IActionResult> DailyReport()
        {

            var _retVal = await mediator.Send(new GetDailyReportQuery { });

            return View(_retVal);
        }


        [HttpGet]
        public  IActionResult TimeRecord()
        {
            return View(Startup.currentUser);     
        }


        [HttpPost]

        public async Task<IActionResult> TimeIn()
        {
            var _retVal = await mediator.Send(new SaveTimeInCommand { ID = Startup.currentUser.ID});

            return Json(true);         
        }


        public async Task<IActionResult> TimeOut()
        {
            var _retVal = await mediator.Send(new SaveTimeOutCommand { ID = Startup.currentUser.ID});

            return Json(true);
        }

   
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
