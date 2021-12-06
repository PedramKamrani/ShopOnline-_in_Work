using _0_FramWork.Application;
using ShopManagement.Application.Contract.ProductDTO;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProduct _repository;
        public ProductApplication(IProduct repository)
        {
            _repository = repository;
        }
        public OperationResult Create(CreateProductDTO dto)
        {
            OperationResult opreationResult = new OperationResult();
            if (_repository.Exsists(x => x.Name == dto.Name))
                return opreationResult.Faild(ApplicationMessage.DuplicatedRecord);
            string Slug = dto.Slug.Slugify();
            var entity = new Product(dto.Name, dto.Code, dto.ShortDescription, dto.Description
                , dto.Picture, dto.PictureAlt, dto.PictureTitle
                , dto.CategoryId, Slug, dto.Keywords, dto.MetaDescription);
            _repository.Create(entity);
            _repository.SaveChanges();
            return opreationResult.Success();


        }

        public OperationResult Edit(EditProductDTO dto)
        {
            OperationResult opreationResult = new OperationResult();
            var entity = _repository.Get(dto.Id);
            if (entity == null)
                return opreationResult.Faild(ApplicationMessage.RecordNotFound);
            if (_repository.Exsists(x => x.Name == dto.Name && x.Id != dto.Id))
                return opreationResult.Faild(ApplicationMessage.DuplicatedRecord);
            string Slug = dto.Slug.Slugify();
            entity.Edit(dto.Name,dto.Code,dto.ShortDescription,dto.Description,
                dto.Picture,dto.PictureAlt,dto.PictureTitle,dto.CategoryId,Slug,dto.Keywords,dto.MetaDescription);
            _repository.SaveChanges();
            return opreationResult.Success();

        }

        public List<ProductDTO> GetAllProduct()
        {
            return _repository.GetAllProduct();
        }

        public EditProductDTO GetDetails(long id)
        {
            return _repository.GetDetail(id);
        }

        public List<ProductDTO> Search(SearchModel serachModel)
        {
            return _repository.Search(serachModel);
        }
    }
}
