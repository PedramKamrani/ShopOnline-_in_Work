using _0_FramWork.Application;
using ShopManagement.Application.Contract.ProductDTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColleagueDiscount.Managment.Application.Contract.ColleagueDiscountDTO
{
    public class CreateColleagueDiscount
    {
        [Range(1, 100000, ErrorMessage = AttributetMessage.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = AttributetMessage.IsRequired)]
        public int DiscountRate { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
