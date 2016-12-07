using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Infrastructure.Concrete
{
    public class Class1
    {
        public void test()
        {
            ECommerceEntities entities = new ECommerceEntities();

            //Category categoryEntity = entities.Category.Where(x => x.CategoryID == 5).FirstOrDefault();
            //ICategory category = new CategoryAdapter(categoryEntity);
        }
    }
}