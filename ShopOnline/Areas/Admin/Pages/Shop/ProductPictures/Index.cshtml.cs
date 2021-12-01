using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductDTO;
using ShopManagement.Application.Contract.ProductPictureDTO;
using System.Collections.Generic;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        public List<ProductPictureDTO> ProductPictures;
        public ProductPitureSearchModel SearchModel;
        public SelectList Products;
        private readonly IProductPictureApplication _productPicture;
        private readonly IProductApplication _product;
        public IndexModel(IProductPictureApplication productPicture, IProductApplication product)
        {
            _productPicture = productPicture;
            _product = product;
        }
        public void OnGet(ProductPitureSearchModel searchModel)
        {
            Products = new SelectList(_product.GetAllProduct(), "Id", "Name");
            ProductPictures = _productPicture.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture
            {
                Products = _product.GetAllProduct()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var res = _productPicture.Create(command);
            return new JsonResult(res);
        }

        public IActionResult OnGetEdit(long id)
        {
            var res = _productPicture.GetDetails(id);
            res.Products = _product.GetAllProduct();
            return Partial("./Edit", res);

        }
        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var res = _productPicture.Edit(command);
            return new JsonResult(res);
        }

        public IActionResult OnGetRemove(long id)
        {
            _productPicture.Remove(id);
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetRestore(long id)
        {
            _productPicture.ReStore(id);
            return RedirectToPage("./Index");
        }
    }
}
