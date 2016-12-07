using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Infrastructure.Concrete
{
    public class ProductAdapter : ProductX, IProduct
    {
        //public ICategory ProductCategory { get; set; }
        //public int ProductID { get; set; }
        //public Guid UniqueId { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public double Rating { get; set; }
        //public decimal Price { get; set; }
        //public IImage Image { get; set; }

        public ProductAdapter(Product productEntity)
        {
            this.ProductID = productEntity.ProductID;
            this.Name = productEntity.ProductName;
            this.Description = productEntity.ProductDescription;
            this.Rating = productEntity.Rating;
            this.Price = productEntity.Price;
            this.Image = new ItemImage(productEntity.ImageId, ItemImage.imageType.product);
            this.ProductCategory = new CategoryAdapter(productEntity.Category);
            this.UniqueId = productEntity.UniqueId;
            this.CreationTime = productEntity.CreationTime;
            this.ProductCategory.CategoryID = productEntity.CategoryID; 
            this.StockCount = productEntity.StockCount;

            //shopping cart detail ???
            //order detail ???
         }
    }
}