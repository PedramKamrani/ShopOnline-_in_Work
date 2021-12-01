using Microsoft.AspNetCore.Http;
using Microsoft.;
using System.ComponentModel.DataAnnotations;
using _0_FramWork.Application;

namespace ShopManagement.Application.Contract.SliderDTO
{
    public class CreateSlider
    {
        [Required(ErrorMessage = AttributetMessage.IsRequerd)]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = AttributetMessage.IsRequerd)]
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string BtnText { get; set; }
        public string Link { get; set; }
        public bool IsRemoved { get; set; }
    }
}
