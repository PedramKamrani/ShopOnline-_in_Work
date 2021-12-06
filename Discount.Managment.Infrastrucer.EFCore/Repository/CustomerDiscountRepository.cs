using _0_FramWork.Application;
using _0_FramWork.BaseClass;
using Discount.Managment.Application.Contract.Discount.Managment.DTO;
using DisCount.Manangment.Domain.CustomerDiscounts;
using ShopManagement.Infrastrucer;
using System.Collections.Generic;
using System.Linq;

namespace Discount.Managment.Infrastrucer.EFCore.Repository
{
    public class CustomerDiscountRepository : BaseRepository<long, CustomerDiscount>, ICustomerDiscount
    {
        private readonly CustomerDisCountContext _context;
        private readonly ShopContext _Shopcontext;
        public CustomerDiscountRepository(CustomerDisCountContext context, ShopContext Shopcontext) : base(context)
        {
            _context = context;
            _Shopcontext = Shopcontext;
        }
        public EditCustomerDisCountDTO GetDetails(long Id)
        {
            return _context.CustomerDiscounts.Select(x => new EditCustomerDisCountDTO
            {
                Id = x.Id,
                DiscounRate = x.DiscounRate,
                ProductId = x.ProductId,
                Reason = x.Reason,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi()
            }).FirstOrDefault(x => x.Id == Id);
        }

        public List<DiscountCustomerDTO> Search(CustomerDiscountSearchModel searchModel)
        {
            var products =_Shopcontext.Products.Select(p=>new {p.Id,p.Name }).ToList();
            var query = _context.CustomerDiscounts.Select(x => new DiscountCustomerDTO
            {
                Id = x.Id,
                DiscounRate = x.DiscounRate,
                ProductId = x.ProductId,
                Reason = x.Reason,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi()
            });
            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            if (string.IsNullOrWhiteSpace(searchModel.StartDate))
                query = query.Where(x => x.StartDateEN > searchModel.StartDate.ToGeorgianDateTime());
            if (string.IsNullOrWhiteSpace(searchModel.EndDate))
                query = query.Where(x => x.EndDateEN < searchModel.EndDate.ToGeorgianDateTime());
            var discounts = query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(discount =>
            discount.Product = products.FirstOrDefault(x => x.Id == discount.Id)?.Name);
            return discounts;
        }
    
    }
}
