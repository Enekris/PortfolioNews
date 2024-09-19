namespace InfoPortal.Application.Exeptions
{
    public class BaseException : Exception
    {
        public Guid? AccountId { get; } //ну и где мне это брать(((( я чувствую что нужно
        public string? ErrorMessage { get; }
        public string? ErrorLog { get; }
        public BaseException()
        {
        }
        public BaseException(string message = "Непредвиденная ошибка") : base(message) //не думаю что мне это потребуется если нельзя расскрывать настоящий ex // СЮДА
        {
            ErrorMessage = message;
        }

    }
}
