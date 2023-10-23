using DataProvider.Models.Contoso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimeLine.Abstractions;
using TimeLine.Models.ViewModels;

namespace TimeLineWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntitiesTimeLineService _entitiesTimeLine;

        public HomeController(
            ILogger<HomeController> logger,
            IEntitiesTimeLineService entitiesTimeLine)
        {
            _logger = logger;
            _entitiesTimeLine = entitiesTimeLine;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EntitiesTimeLines()
        {
            try
            {
                var deviceTimeLine = _entitiesTimeLine.GetDeviceTimeLine();

                return View(deviceTimeLine);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems with entities timelines: {ex.Message}", ex.StackTrace);
                throw;
            }            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDevice([Bind("SerialNumber,Status,StartDate,EndDate")] DeviceViewModel device)
        {
            if (ModelState.IsValid)
            {
                _entitiesTimeLine.CreateDevice(device);

                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
