using ShopManagement.Application.Contract.ProductDTO;
using System.Collections.Generic;

namespace Discount.Managment.Application.Contract.Discount.Managment.DTO
{
    public class CreateCustomerDiscountDTO
    {
        public long ProductId { get; set; }
        public byte DiscounRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public List<ProductDTO> Products { get; set; }
    }


}
