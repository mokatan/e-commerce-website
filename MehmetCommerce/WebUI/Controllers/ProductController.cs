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
    public class ProductController : Controller
    {
        private ICategory productDisplay;
        private ProductX productDetail;
        private ProductX productDetail2;
        public int PageSize = 4;
        public ProductController()
        {
        }

        public ViewResult CategoryProducts(int id)
        {
            ECommerceEntities entities = new ECommerceEntities();
            List<Product> productList = entities.Product.Where(x => x.CategoryID == id).ToList();
            List<IProduct> products = new List<IProduct>();
            foreach (Product product in productList)
            {
                products.Add(new ProductAdapter(product));
            }

            return View(products);
        }

        public ViewResult Detail(int id)
        {
            ECommerceEntities entities = new ECommerceEntities();
            Product product = entities.Product.Where(x => x.ProductID == id).FirstOrDefault();
            if (id == null || product == null)
            {
                return View(new ProductX());
            }
            productDetail2 = ProductX.GetProduct(id);
            return View(productDetail2);
        }

        public ViewResult List(int? id)
        {
            //int id = 1;
            ECommerceEntities entities = new ECommerceEntities();
            Category category = entities.Category.Where(x => x.CategoryID == id).FirstOrDefault();

            if (id == null || category == null)
            {
                return View(new List<IProduct>());
            }
            productDisplay = new CategoryAdapter(category);

            return View(productDisplay.GetCategoryProducts((int)id));
        }

        public ViewResult List2(int? id2)
        {
            productDetail = ProductX.GetProduct(1);
            return View(productDetail);
        }

        public RedirectToRouteResult AddToCart(int productId)
        {
            ShoppingCartX shoppingCart = new ShoppingCartX();
            ECommerceEntities et = new ECommerceEntities();

            shoppingCart.AddToCart(new ProductAdapter(et.Product.Where(x => x.ProductID == productId).FirstOrDefault()), 1);

            return RedirectToAction("Index","ShoppingCart");
        }
    }
}
