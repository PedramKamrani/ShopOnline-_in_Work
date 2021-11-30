using _0_FramWork.Application;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.ProductCategoryDTO
{
    public class CreateDto
    {
        [Required(ErrorMessage = AttributetMessage.IsRequerd)]
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = AttributetMessage.IsRequerd)]
        public string Keywords { get; set; }
        [Required(ErrorMessage = AttributetMessage.IsRequerd)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = AttributetMessage.IsRequerd)]
        public string Slug { get; set; }

    }
}
