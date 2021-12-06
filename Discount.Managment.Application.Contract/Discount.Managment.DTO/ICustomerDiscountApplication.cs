using _0_FramWork.Application;
using System.Collections.Generic;

namespace Discount.Managment.Application.Contract.Discount.Managment.DTO
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Create(CreateCustomerDiscountDTO command);
        OperationResult Edit(EditCustomerDisCountDTO command);
        EditCustomerDisCountDTO GetDetails(long Id);
        List<DiscountCustomerDTO> Search(CustomerDiscountSearchModel searchModel);
    }
}
