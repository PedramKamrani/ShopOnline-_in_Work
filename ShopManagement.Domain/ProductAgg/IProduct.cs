using _0_FramWork.Application;
using ShopManagement.Application.Contract.ProductDTO;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProduct : IBaseRepository<long, Product>
    {
        EditProductDTO GetDetail(long id);
        List<ProductDTO> Search(SearchModel serachModel);
    }
}
