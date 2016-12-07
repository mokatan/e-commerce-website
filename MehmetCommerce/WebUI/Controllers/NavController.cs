using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Infrastructure.Abstract;
using WebUI.Infrastructure.Concrete;
using Domain;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private ICategory categoryDisplay;
        public PartialViewResult Menu()
        {
            ECommerceEntities entities = new ECommerceEntities();
            Category category = new Category();
            categoryDisplay = new CategoryAdapter(category);
            return PartialView(categoryDisplay.GetCategories());
        }
            
     }

}

