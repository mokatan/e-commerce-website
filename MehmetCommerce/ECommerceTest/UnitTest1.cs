using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using WebUI;
using WebUI.Infrastructure.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCategories()
        {
            ECommerceEntities et = new ECommerceEntities();
            var asd = et.Category.Where(x => x.CategoryID == 4).FirstOrDefault();
        }
    }
}
