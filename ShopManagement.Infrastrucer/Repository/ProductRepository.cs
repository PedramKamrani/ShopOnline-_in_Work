using _0_FramWork.BaseClass;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductDTO;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastrucer.Repository
{
   public class ProductRepository: BaseRepository<long,Product>,IProduct
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context):base(context)
        {
            _context = context;
        }

        public EditProductDTO GetDetail(long id)
        {
           return _context.Products.Select(x => new EditProductDTO
            {
               Id=x.Id,
               Code=x.Code,
               CreationDate=x.CreationDate.ToString(),
               Name=x.Name,
               Picture=x.Picture,   
               PictureTitle=x.PictureTitle,
               PictureAlt=x.PictureAlt,
               CategoryId=x.CategoryId,
               Description=x.Description,
               Keywords=x.Keywords,
               MetaDescription=x.MetaDescription,
               ShortDescription=x.ShortDescription,
               Slug=x.Slug
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<ProductDTO> Search(SearchModel serachModel)
        {
            var query = _context.Products.Include(x=>x.ProductCategory).Select(x => new ProductDTO
            {
               Id=x.Id,
                Code = x.Code,
                CreationDate = x.CreationDate.ToString(),
                Name = x.Name,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Category=x.ProductCategory.Name
            });
            if(!string.IsNullOrWhiteSpace(serachModel.Name))
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{serachModel.Name}%"));
            if (!string.IsNullOrWhiteSpace(serachModel.Code))
                query = query.Where(x=>EF.Functions.Like(x.Code, $"%{serachModel.Code}%"));

            if (serachModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == serachModel.CategoryId);

            return query.OrderBy(x=>x.Id).ToList();

        }
    }
}
