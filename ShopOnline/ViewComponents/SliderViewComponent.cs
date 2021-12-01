using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.SliderDTO;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        public readonly ISliderApplication _slider;
        public SliderViewComponent(ISliderApplication slider)
        {
            _slider = slider;
        }

        public IViewComponentResult Invoke()
        {
            var slider = _slider.GetListSlider();
            return View(slider);
        }
    }
}
