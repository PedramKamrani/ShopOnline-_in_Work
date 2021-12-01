using _0_FramWork.Application;
using _0_FramWork.BaseClass;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductDTO;
using ShopManagement.Application.Contract.ProductPictureDTO;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastrucer.Repository
{
   public class ProductPictureRepository:BaseRepository<long,ProductPicture>,IProductPicture
    {
        private readonly ShopContext _context;
        public ProductPictureRepository(ShopContext context) :base(context)
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.ProductPictures.Select(c => new EditProductPicture
            {
                Id=c.Id,
               ProductId=c.ProductId,
               PictureTitle=c.PictureTitle,
               PictureAlt=c.PictureAlt
                
            }).FirstOrDefault(x => x.Id == id);
        }

        public ProductPicture GetProductByCategory(long ProductId)
        {
            var category = _context.ProductPictures
                .Include(x => x.Product)
                .ThenInclude(x=>x.ProductCategory)
                .FirstOrDefault(x => x.Id == ProductId);
            return category;
        }

        public List<ProductPictureDTO> Search(ProductPitureSearchModel searchModel)
        {
            var query = _context.ProductPictures.Select(x => new ProductPictureDTO
            {
                Id = x.Id,
                ProductId =x.ProductId,
                CreationDate=x.CreationDate.ToFarsi(),
                Picture=x.Picture,
                IsRemoved=x.IsRemoved,
            });
            if(searchModel.ProductId!=0)
                query=query.Where(x=>x.ProductId==searchModel.ProductId);
            return query.OrderBy(x => x.Id).Where(x=>x.IsRemoved==false).ToList();
        }
    }
}
