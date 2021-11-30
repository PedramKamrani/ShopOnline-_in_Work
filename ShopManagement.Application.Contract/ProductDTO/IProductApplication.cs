using _0_FramWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductDTO
{
    public interface IProductApplication
    {
        OpreationResult Create(CreateProductDTO dto);
        OpreationResult Edit(EditProductDTO dto);
        EditProductDTO GetDetails(long id);
        List<ProductDTO> Search(SearchModel serachModel);
    }
}
