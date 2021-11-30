namespace _0_FramWork.Application
{
    public class OpreationResult
    {
        public bool IsSeccuseed { get; set; }
        public string Message { get; set; }
        public OpreationResult()
        {
            IsSeccuseed = false;
        }

        public OpreationResult Success(string message = "عملیات با موفقیت انجام شد")
        {
            IsSeccuseed = true;
            Message = message;
            return this;
        }
        public OpreationResult Faild(string message)
        {
            IsSeccuseed = false;
            Message = message;
            return this;
        }
    }
}
