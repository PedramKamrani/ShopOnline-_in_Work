using _0_FramWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductCategoryDTO
{
    public interface IProductCategoryApplication
    {
        OpreationResult Create(CreateDto dto);
        OpreationResult Edit(EditDto dto);
        EditDto GetDetails(long id);
        List<ProductCategoryDTO> Search(SearchModel serchModel);
    }
}
