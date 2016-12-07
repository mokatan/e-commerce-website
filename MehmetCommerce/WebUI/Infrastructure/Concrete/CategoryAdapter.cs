using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Infrastructure.Concrete
{
    public class CategoryAdapter : CategoryX, ICategory
    {
        //public ICategory ParentCategory { get; set; }
        //public int CategoryID { get; set; }
        //public string CategoryName { get; set; }
        //public string Description { get; set; }
        //public IImage Image { get; set; }

        public CategoryAdapter(Category categoryEntity)
        {
            this.CategoryID = categoryEntity.CategoryID;
            this.ParentCategory = null;
            //if (categoryEntity.ParentCategory != null)
            //    this.ParentCategory = new CategoryAdapter(categoryEntity.ParentCategory);
            this.CategoryName = categoryEntity.CategoryName;
            this.Description = categoryEntity.Description;
            this.Image = new ItemImage(categoryEntity.ImageId, ItemImage.imageType.category);
            //child category
            //product
        }
    }
}