using _0_FramWork.Application;
using ShopManagement.Application.Contract.ProductCategoryDTO;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagment.Application
{
    public class ProductCategoryApplication:IProductCategoryApplication
    {
        private readonly IProductCategory _repository;
        public ProductCategoryApplication(IProductCategory repository)
        {
            _repository = repository;
        }

        public OpreationResult Create(CreateDto dto)
        {
            OpreationResult opreationResult = new OpreationResult();
            if (_repository.Exsists(e => e.Name == dto.Name))
                return opreationResult.Faild(ApplicationMessage.DuplicatedRecord); 

                string Slug = dto.Slug.Slugify();
            var entite = new ProductCategory(dto.Name, dto.Description, dto.Picture, dto.PictureAlt, dto.PictureTitle,
                dto.Keywords, dto.MetaDescription, Slug);
            _repository.Create(entite);
            _repository.SaveChanges();
            return opreationResult.Success();

        }

        public OpreationResult Edit(EditDto dto)
        {
            OpreationResult opreationResult = new OpreationResult();
            ProductCategory entity = _repository.Get(dto.Id);
            if (entity == null)
                return opreationResult.Faild(ApplicationMessage.RecordNotFound);
            if (_repository.Exsists(e => e.Name == dto.Name && entity.Id != dto.Id))
                return opreationResult.Faild(ApplicationMessage.DuplicatedRecord);
            string Slug = dto.Slug.Slugify();
            entity.Edit(dto.Name, dto.Description, dto.Picture, dto.PictureAlt, dto.PictureTitle,
                dto.Keywords, dto.MetaDescription, Slug);
            _repository.SaveChanges();
            return opreationResult.Success();
        }

        public List<ProductCategoryDTO> GetAllCategory()
        {
            return _repository.GetAllProductCategoryForProduct();
        }

        public EditDto GetDetails(long id)
        {
            return _repository.GetDetail(id);
        }

        public List<ProductCategoryDTO> Search(SearchModel serchModel)
        {
            return _repository.Search(serchModel);
        }
    }
}
