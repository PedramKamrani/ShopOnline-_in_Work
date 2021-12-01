using _0_FramWork.Application;
using ShopManagement.Application.Contract.ProductDTO;
using ShopManagement.Application.Contract.ProductPictureDTO;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPicture : IBaseRepository<long, ProductPicture>
    {
        ProductPicture GetProductByCategory(long ProductId);
        EditProductPicture GetDetails(long id);
        List<ProductPictureDTO> Search(ProductPitureSearchModel searchModel);
    }
}
