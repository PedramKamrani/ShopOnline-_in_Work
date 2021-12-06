using _0_FramWork.Application;

using System.Collections.Generic;
namespace ShopManagement.Application.Contract.ProductPictureDTO
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        EditProductPicture GetDetails(long id);
        List<ProductPictureDTO> Search(ProductPitureSearchModel SearchModel);
        OperationResult Remove(long id);
        OperationResult ReStore(long id);
    }
}
