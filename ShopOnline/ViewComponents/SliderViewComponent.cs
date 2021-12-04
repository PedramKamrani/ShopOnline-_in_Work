using _1_QueryLayer.Query.Contract.Slider;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.SliderDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderQuery _slider;
      

        public SliderViewComponent(ISliderQuery slider)
        {
            _slider = slider;
        }

        public IViewComponentResult Invoke()
        {
            var slider = _slider.GetSliderQueries();
            return View(slider);
        }
    }
}
