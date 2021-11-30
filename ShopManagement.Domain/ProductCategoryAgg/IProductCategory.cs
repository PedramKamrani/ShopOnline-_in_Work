using _0_FramWork.Application;
using ShopManagement.Application.Contract.ProductCategoryDTO;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategory : IBaseRepository<long, ProductCategory>
    {
        EditDto GetDetail(long id);
        List<ProductCategoryDTO> Search(SearchModel serchModel);
        List<ProductCategoryDTO> GetAllProductCategoryForProduct();
    }
}
