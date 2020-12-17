namespace TesteNotifications.Application.DataStructure
{
    public class ErrorMessage
    {
        public string Error { get; private set; }
        public string Description { get; private set; }

        public ErrorMessage(string error, string description)
        {
            Error = error;
            Description = description;
        }
    }
}
