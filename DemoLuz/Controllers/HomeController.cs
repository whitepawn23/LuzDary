using DemoLuz.Services.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoLuz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyService _companyService;
        public HomeController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public ActionResult Index()
        {
            var companiesResult = _companyService.Get();
            if (companiesResult.Success) { 
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}