using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategoryDTO;
using System.Collections.Generic;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategory;
        public List<ProductCategoryDTO> Categores;
        public List<ProductCategoryDTO> ProductCategoryDTO;
        public SearchModel SearchModel;
        public IndexModel(IProductCategoryApplication productCategory)
        {
            _productCategory = productCategory;
        }
        public void OnGet(SearchModel searchmodel)
        {
            ProductCategoryDTO = _productCategory.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            Categores = _productCategory.GetAllCategory();
            return Partial("./Create", new CreateDto());
        }
        public JsonResult OnPostCreate( CreateDto dto)
        {
            if (!ModelState.IsValid)
                return new JsonResult("مقدار صحیح نمیباشد");
            var res= _productCategory.Create(dto);
            return new JsonResult(res);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productcategory = _productCategory.GetDetails(id);
            return Partial("./Edit", productcategory);
        }
        public JsonResult OnPostEdit(EditDto dto)
        {
            if (!ModelState.IsValid)
                return new JsonResult("مقدار صحیح نمیباشد");
            var res = _productCategory.Edit(dto);
            return new JsonResult(res);
        }
    }
}
