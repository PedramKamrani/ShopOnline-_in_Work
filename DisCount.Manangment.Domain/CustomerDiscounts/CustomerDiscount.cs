using _0_FramWork.BaseClass;
using System;

namespace DisCount.Manangment.Domain.CustomerDiscounts
{
    public class CustomerDiscount : BaseEntity
    {
        public CustomerDiscount(long productId, byte discounRate, DateTime startDate, DateTime endDate, string rease)
        {
            ProductId = productId;
            DiscounRate = discounRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = rease;
        }

        public long ProductId { get; private set; }
        public byte DiscounRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; }

        public void Edit(long productId, byte discounRate, DateTime startDate, DateTime endDate, string rease)
        {
            ProductId = productId;
            DiscounRate = discounRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = rease;
        }

    }
}
