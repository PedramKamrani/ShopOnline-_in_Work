using _0_FramWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SliderDTO
{
   public interface ISliderApplication
    {
        OperationResult Create(CreateSlider command);
        OperationResult Edit(EditSlider command);
        List<SliderDTO> GetListSlider();
        EditSlider GetDetails(long id);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}
