using _0_FrameWork.Application;
using _0_FramWork.Application;
using ShopManagement.Application.Contract.ProductPictureDTO;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagment.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPicture _repository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPicture repository, IFileUploader fileUploader)
        {
            _repository = repository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreateProductPicture command)
        {
            OperationResult opreationResult = new OperationResult();
            string path = "";
            var product = _repository.GetProductByCategory(command.ProductId);
            if (product == null)
                return opreationResult.Failed(ApplicationMessage.RecordNotFound);
            path = $"{product.Product.ProductCategory}//{product.Product.Slug}";
            string productpicure = _fileUploader.Upload(command.Picture, path);
            var entity = new ProductPicture(command.ProductId, productpicure, command.PictureAlt, command.PictureTitle);
            _repository.Create(entity);
            return opreationResult.Success();

        }

        public OperationResult Edit(EditProductPicture command)
        {
            OperationResult opreationResult = new OperationResult();
            var produtpicture = _repository.GetProductByCategory(command.Id);
            if (produtpicture == null)
                return opreationResult.Failed(ApplicationMessage.RecordNotFound);
            var path = $"{produtpicture.Product.ProductCategory.Slug}//{produtpicture.Product.Slug}";
            var picturepath = _fileUploader.Upload(command.Picture, path);
            produtpicture.Edit(command.ProductId, picturepath, command.PictureAlt, command.PictureTitle);
            _repository.SaveChanges();
            return opreationResult.Success();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            OperationResult operationresult = new OperationResult();
            ProductPicture item = _repository.Get(id);
            if (item != null)
                item.Remove();
            _repository.SaveChanges();
            return operationresult.Success();
        }

        public OperationResult ReStore(long id)
        {
            OperationResult opreationResult = new OperationResult();
            ProductPicture item = _repository.Get(id);
            if (item != null)
                item.Restore();
            _repository.SaveChanges();
            return opreationResult.Success();
        }

        public List<ProductPictureDTO> Search(ProductPitureSearchModel SearchModel)
        {
            return _repository.Search(SearchModel);
        }
    }
}
