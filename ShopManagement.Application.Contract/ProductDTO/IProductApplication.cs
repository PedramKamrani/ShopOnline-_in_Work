using _0_FramWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductDTO
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProductDTO dto);
        OperationResult Edit(EditProductDTO dto);
        EditProductDTO GetDetails(long id);
        List<ProductDTO> Search(SearchModel serachModel);
        List<ProductDTO> GetAllProduct();


    }
}
