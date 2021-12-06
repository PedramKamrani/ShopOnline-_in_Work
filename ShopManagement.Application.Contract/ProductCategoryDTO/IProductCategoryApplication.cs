using _0_FramWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductCategoryDTO
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateDto dto);
        OperationResult Edit(EditDto dto);
        EditDto GetDetails(long id);
        List<ProductCategoryDTO> Search(SearchModel serchModel);
        List<ProductCategoryDTO> GetAllCategory();
    }
}
