using _0_FramWork.BaseClass;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductCategoryDTO;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastrucer.Repository
{
    public class ProductCategoryRepository : BaseRepository<long, ProductCategory>, IProductCategory
    {
        private readonly ShopContext _context;
        public ProductCategoryRepository(ShopContext context):base(context)
        {
            _context = context;
        }
        public EditDto GetDetail(long id)
        {
            return _context.ProductCategories.Where(x => x.Id == id)
                .Select(x => new EditDto
                {
                    Id=x.Id,
                    Description=x.Description,
                    Keywords=x.Keywords,
                    MetaDescription=x.MetaDescription,
                   Name=x.Name,
                   Picture=x.Picture,
                   PictureAlt=x.PictureAlt,
                   PictureTitle=x.PictureTitle,
                   
                }).FirstOrDefault();

        }

        public List<ProductCategoryDTO> Search(SearchModel serchModel)
        {
            var query=_context.ProductCategories.Select(x=>
            new ProductCategoryDTO
            {
                Id=x.Id,
               Name=x.Name,
               CreationDate=x.CreationDate,
               Picture=x.Picture,
               PictureAlt=x.PictureAlt,
               PictureTitle=x.PictureTitle

            });
            if (!string.IsNullOrWhiteSpace(serchModel.Name))
                query = query.Where(x => EF.Functions.Like(x.Name,$"%{serchModel.Name}%" ));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
