namespace ColleagueDiscount.Managment.Application.Contract.ColleagueDiscountDTO
{
    public class ColleagueDiscounDTO
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public int DiscountRate { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
    }
}
