using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using WebUI.Infrastructure.Concrete;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Controllers
{
    public class LogoutController : Controller
    {
        
        // GET: /Logout/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogoutUser()
        {
            if (SessionUser.UserLoggedIn())
            {
                SessionUser.LogOut();
            }
            if (!SessionUser.UserLoggedIn())
            {
                 ViewBag.Result = "Çıkış işlemi başarı ile gerçekleştirildi!";
                 return View(); //RedirectToAction("Index", "Home");
            }
            else
            {
                 ViewBag.Result = "Çıkış yapılamadı!";
            }
            //return RedirectToAction("Index", "Home");
            return View();
        }

    }
}
