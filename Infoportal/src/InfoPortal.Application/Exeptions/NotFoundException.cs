namespace InfoPortal.Application.Exeptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message = "Объект не найден") : base(message)
        {
        }
    }
}
