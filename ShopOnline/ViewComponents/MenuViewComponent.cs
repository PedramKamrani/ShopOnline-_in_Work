using _1_QueryLayer.Query.Contract.Slider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly ISliderQuery _sliderQuery;

        public MenuViewComponent(ISliderQuery sliderQuery)
        {
            _sliderQuery = sliderQuery;
        }

        public IViewComponentResult Invoke()
        {
            var slider = _sliderQuery.GetSliderQueries();
            return View(slider);
        }
    }
}
