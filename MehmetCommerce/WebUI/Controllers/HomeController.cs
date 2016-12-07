using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using WebUI.Infrastructure.Abstract;
using WebUI.Infrastructure.Concrete;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public RedirectToRouteResult Index()
        {
            return RedirectToAction("List", "Product");
        }
    }
}
