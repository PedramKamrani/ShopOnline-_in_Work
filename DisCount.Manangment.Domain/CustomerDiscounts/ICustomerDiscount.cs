using _0_FramWork.Application;
using Discount.Managment.Application.Contract.Discount.Managment.DTO;
using System.Collections.Generic;

namespace DisCount.Manangment.Domain.CustomerDiscounts
{
    public interface ICustomerDiscount : IBaseRepository<long, CustomerDiscount>
    {
        EditCustomerDisCountDTO GetDetails(long Id);
        List<DiscountCustomerDTO> Search(CustomerDiscountSearchModel searchModel);
    }
}
