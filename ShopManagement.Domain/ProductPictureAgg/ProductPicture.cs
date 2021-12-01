using _0_FramWork.BaseClass;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
   public class ProductPicture:BaseEntity
    {
        public ProductPicture(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            IsRemoved = false;
            PictureTitle = pictureTitle;
        }

        public long ProductId { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsRemoved { get; private set; }
        public Product Product { get; private set; }

        public void Edit(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            if(!string.IsNullOrWhiteSpace(picture))
            Picture = picture;

            PictureAlt = pictureAlt; 
            PictureTitle = pictureTitle;
        }
        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }

    }
}
