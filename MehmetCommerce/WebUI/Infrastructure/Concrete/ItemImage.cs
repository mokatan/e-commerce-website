using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Infrastructure.Concrete
{
    public class ItemImage : IImage
    {
        public Guid? ImageId { get; set; }
        public int ItemType { get; set; }
        public string ImageUrl { get; set; }

        public ItemImage(Guid? imageId, imageType itemType)
        {
            this.ImageId = imageId;
            CreateImageUrl(itemType);
        }

        protected void CreateImageUrl(imageType itemType)
        {
            this.ImageUrl = null;

            if (ImageId == null)
            {
                ImageUrl = null;
                return;
            }

            switch (itemType)
            {
                case imageType.product:
                    ImageUrl = "Products/" + ImageId.ToString() + ".jpg";
                    break;
                case imageType.category:
                    ImageUrl = "Categories/" + ImageId.ToString() + ".jpg";
                    break;
                case imageType.item:
                    ImageUrl = "Items/" + ImageId.ToString() + ".jpg";
                    break;
                default:
                    ImageUrl = null;
                    break;
            }

        }

        public enum imageType { product=1, category=2,item=3 }


        public override string ToString()
        {
            return this.ImageUrl;
        }
    }
}