using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure.Abstract;
using Domain;

namespace WebUI.Infrastructure.Concrete
{
    public class ProductX: IStockable, IProduct
    {
        public ICategory ProductCategory { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public IImage Image { get; set; } //id?
        public double Rating { get; set; } 
        public decimal Price { get; set; } 
        public int ProductID { get; set; } 
        public Guid UniqueId { get; set; } 
        public int StockCount { get; set; } 
        public DateTime CreationTime { get; set; } 
 
        //order detail
        //shopping cart detail

        public static ProductX GetProduct(int productId)
        {
            ProductX myProduct = new ProductX();
            myProduct.ProductCategory = new CategoryX();
            ECommerceEntities entities = new ECommerceEntities();
            Product product = entities.Product.Where(x => x.ProductID == productId).FirstOrDefault();
            myProduct.ProductID = product.ProductID;
            myProduct.Name = product.ProductName;
            myProduct.Description = product.ProductDescription;
            myProduct.Rating = product.Rating;
            myProduct.Price = product.Price;
            myProduct.StockCount = product.StockCount;
            myProduct.CreationTime = product.CreationTime;
            myProduct.UniqueId = product.UniqueId;
            myProduct.ProductCategory.CategoryID = product.CategoryID;
            myProduct.Image = new ItemImage(product.ImageId,ItemImage.imageType.category);
            return myProduct;
        }
        
        public int GetStockCount()
        {
            ECommerceEntities et = new ECommerceEntities();
            return et.Product.Where(x => x.ProductID == this.ProductID).Select(x => x.StockCount).FirstOrDefault();
        }
        public bool CreateProduct()
        {
            ECommerceEntities et = new ECommerceEntities();
            Product ProductToInsert = new Product()
            {   
                ProductName = this.Name,
                ProductDescription = this.Description,
                Rating = this.Rating,
                StockCount = this.StockCount,
                ImageId = this.Image.ImageId,
                CreationTime = DateTime.Now,
                CategoryID = this.ProductCategory.CategoryID,
            };

            et.Product.Add(ProductToInsert);
            et.SaveChanges();
            return true;
        }

        public bool UpdateProduct()
        {
            ECommerceEntities entities = new ECommerceEntities();
            Product product = entities.Product.Where(x => x.ProductID == this.ProductID).FirstOrDefault();

                product.ProductName = this.Name;
                product.ProductDescription = this.Description;
                product.Rating = this.Rating;
                product.StockCount = this.StockCount;
                //product.ImageId = this.ImageId;  implement this!!!
                product.CreationTime = this.CreationTime;
                product.CategoryID = this.ProductCategory.CategoryID;

            entities.SaveChanges();
            return true;
        }

        public void AddToStock(int itemCount)
        {
            ECommerceEntities entities = new ECommerceEntities();
            Product product = entities.Product.Where(x => x.ProductID == this.ProductID).FirstOrDefault();

            product.StockCount += itemCount;
            entities.SaveChanges();
        }
    }
}