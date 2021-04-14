using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using THWebExample.Models;
using THWebExample.Services;
using THWebExample.ViewModels;

namespace THWebExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInterestService _interestService;
        private readonly IKrisInfoService _krisInfoService;

        public HomeController(ILogger<HomeController> logger, IInterestService interestService, IKrisInfoService krisInfoService)
        {
            _logger = logger;
            _interestService = interestService;
            _krisInfoService = krisInfoService;
        }

        public IActionResult Index()
        {
            var list = _krisInfoService.GetAllKrisInformation();


            var model = new HomeIndexViewModel();
            model.Items = _interestService.GetRepoInterestValues().Select(e => new HomeIndexViewModel.InterestItem
            {
                Value = e.Value,
                Datum = e.Datum
            }).ToList();

            return View(model);
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
