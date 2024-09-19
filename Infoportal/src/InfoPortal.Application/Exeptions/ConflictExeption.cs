namespace InfoPortal.Application.Exeptions
{
    public class ConflictExeption : BaseException
    {
        public ConflictExeption(string message = "Объект уже существует") : base(message)
        {
        }
    }
}
