namespace _0_FramWork.Application
{
    public class OperationResult
    {
        public bool IsSeccuseed { get; set; }
        public string Message { get; set; }
        public OperationResult()
        {
            IsSeccuseed = false;
        }

        public OperationResult Success(string message = "عملیات با موفقیت انجام شد")
        {
            IsSeccuseed = true;
            Message = message;
            return this;
        }
        public OperationResult Faild(string message)
        {
            IsSeccuseed = false;
            Message = message;
            return this;
        }
    }
}
