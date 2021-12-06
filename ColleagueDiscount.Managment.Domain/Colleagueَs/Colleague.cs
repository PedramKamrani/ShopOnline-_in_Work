using _0_FramWork.BaseClass;

namespace ColleagueDiscount.Managment.Domain.Colleagues
{
    public class Colleague: BaseEntity
    {
        public Colleague(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsRemved = false;
        }

        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public bool IsRemved { get; private set; }

        public void Edit(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsRemved = false;
        }

        public void Remove()
        {
            IsRemved = true;
        }
        public void Restore()
        {
            IsRemved = false;
        }
    }
}
