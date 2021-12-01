using _0_FramWork.Application;
using ShopManagement.Application.Contract.SliderDTO;
using System.Collections.Generic;

namespace ShopManagement.Domain.SliderAgg
{
    public interface ISlider:IBaseRepository<long,Slider>
    {
        List<SliderDTO> GetAllSliderList();
        EditSlider GetDetails(long id);
      
    }
}
