using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.SliderDTO;
using System.Collections.Generic;

namespace ServiceHost.Areas.Admin.Pages.Shop.Slider
{
    public class IndexModel : PageModel
    {
        public List<SliderDTO> Slider;
        private readonly ISliderApplication _sliderApplication;
        public IndexModel(ISliderApplication sliderApplication)
        {
            _sliderApplication = sliderApplication;
        }
        public void OnGet()
        {

            Slider = _sliderApplication.GetListSlider();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create",new CreateSlider());
        }
        public JsonResult OnPostCreate(CreateSlider command)
        {
            var res = _sliderApplication.Create(command);
            return new JsonResult(res);
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _sliderApplication.GetDetails(id);
            
            return Partial("./Create", command);
        }

        public JsonResult OnPostEdit(EditSlider command)
        {
           var result= _sliderApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            _sliderApplication.Remove(id);
           return RedirectToPage("./Index");
        }
        public IActionResult OnGetReStore(long id)
        {
            _sliderApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
