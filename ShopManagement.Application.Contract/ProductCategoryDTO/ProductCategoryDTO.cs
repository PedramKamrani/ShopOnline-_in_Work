using System;

namespace ShopManagement.Application.Contract.ProductCategoryDTO
{
    public class ProductCategoryDTO
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }


    }
}
