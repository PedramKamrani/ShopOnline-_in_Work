using _0_FramWork.Application;

using System.Collections.Generic;
namespace ShopManagement.Application.Contract.ProductPictureDTO
{
    public interface IProductPictureApplication
    {
        OpreationResult Create(CreateProductPicture command);
        OpreationResult Edit(EditProductPicture command);
        EditProductPicture GetDetails(long id);
        List<ProductPictureDTO> Search(ProductPitureSearchModel SearchModel);
        OpreationResult Remove(long id);
        OpreationResult ReStore(long id);
    }
}
