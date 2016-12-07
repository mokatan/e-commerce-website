using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure.Abstract;
using Domain;

namespace WebUI.Infrastructure.Concrete
{
    public class CategoryX : ICategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IImage Image { get; set; }
        public ICategory ParentCategory { get; set; }
        //child category
        //product 

        //public List<IProduct> CategortProducts()
        //{
        //    ECommerceEntities et = new ECommerceEntities();
        //}

        public List<ICategory> GetCategories()
        {
            ECommerceEntities et = new ECommerceEntities();
            List<Category> categoryList = et.Category.Where(x => x.CategoryID != null).ToList();
            List<ICategory> categories = new List<ICategory>();

            foreach (Category category in categoryList)
            {
                categories.Add(new CategoryAdapter(category));
            }
            return categories;
        }

        public List<IProduct> GetCategoryProducts(int categoryId)
        {
            ECommerceEntities et = new ECommerceEntities();
            List<Product> productList = et.Product.Where(x => x.CategoryID == categoryId).ToList();
            List<IProduct> products = new List<IProduct>();

            foreach (Product product in productList)
            {
                products.Add(new ProductAdapter(product));
            }

            return products;
        }

        public void CreateCategory()
        {
            ECommerceEntities et = new ECommerceEntities();
            Category CategoryToCreate = new Category()
            {
                CategoryID = this.CategoryID,
                CategoryName = this.CategoryName, 
                ImageId = this.Image.ImageId,
                Description = this.Description 
            };
            et.Category.Add(CategoryToCreate);
            et.SaveChanges();
        }

        public void DeleteCategory()
        {
            ECommerceEntities et = new ECommerceEntities();
            Category category = et.Category.Where(x => x.CategoryID == this.CategoryID).FirstOrDefault();
            et.Category.Remove(category);
            et.SaveChanges();
        }

       
    }
}