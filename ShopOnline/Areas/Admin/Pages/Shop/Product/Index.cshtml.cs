
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductCategoryDTO;
using ShopManagement.Application.Contract.ProductDTO;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ServiceHost.Areas.Admin.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductCategory _productCategores;

        public List<ProductDTO> Products;
        public List<ProductCategoryDTO> ProductCategories { get; set; }
        public ShopManagement.Application.Contract.ProductDTO.SearchModel SearchModel;
        public SelectList ProductCategory;
        public IndexModel(IProductApplication productApplication, IProductCategory productCategory)
        {
            _productApplication = productApplication;
            _productCategores = productCategory;
        }
        public void OnGet(ShopManagement.Application.Contract.ProductDTO.SearchModel serachModel)
        {
            ProductCategory = new SelectList(_productCategores.GetAllList(), "Id", "Name");
            Products = _productApplication.Search(serachModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProductDTO
            {
                Categories = _productCategores.GetAllProductCategoryForProduct()
            };
            ProductCategories = _productCategores.GetAllProductCategoryForProduct();
            return Partial("./Create",command );
        }
        public JsonResult OnPostCreate(CreateProductDTO dto)
        {
           var res= _productApplication.Create(dto);
                return new JsonResult(res);
        }

        public IActionResult OnGetEdit(long id)
        {
            var res = _productApplication.GetDetails(id);
            res.Categories = _productCategores.GetAllProductCategoryForProduct();
            return Partial("./Edit", res);
        }
        public JsonResult OnPostEdit(EditProductDTO dto)
        {
            var res = _productApplication.Edit(dto);
            return new JsonResult(res);
        }
    }
}
