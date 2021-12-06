using _0_FramWork.Application;
using System.Collections.Generic;

namespace ColleagueDiscount.Managment.Application.Contract.ColleagueDiscountDTO
{
    public interface IColleagueApplication
    {
        OperationResult Create(CreateColleagueDiscount command);
        OperationResult Edit(EditcolleagueDiscountViewModel command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditcolleagueDiscountViewModel GetDetails(long id);
        List<ColleagueDiscounDTO> Search(ColleagueSearchModel searchModel);
    }
}
