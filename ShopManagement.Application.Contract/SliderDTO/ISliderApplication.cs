﻿using _0_FramWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.SliderDTO
{
    public interface ISliderApplication
    {
        OpreationResult Create(CreateSlider command);
        OpreationResult Edit(EditSlider command);
        List<SliderDTO> GetListSlider();
        EditSlider GetDetails(long id);
        OpreationResult Remove(long id);
        OpreationResult Restore(long id);
    }
}
