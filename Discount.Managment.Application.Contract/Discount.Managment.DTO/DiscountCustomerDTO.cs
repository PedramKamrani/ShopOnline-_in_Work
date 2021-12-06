using System;

namespace Discount.Managment.Application.Contract.Discount.Managment.DTO
{
    public class DiscountCustomerDTO
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public byte DiscounRate { get; set; }
        public DateTime StartDateEN { get; set; }
        public DateTime EndDateEN { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public string CreationDate { get; set; }

    }


}
