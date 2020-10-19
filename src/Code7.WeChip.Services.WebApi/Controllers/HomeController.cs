using Code7.WeChip.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code7.WeChip.Services.WebApi.Controllers
{
    public class HomeController : Controller
    {

        

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
