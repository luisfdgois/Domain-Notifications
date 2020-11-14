namespace TesteNotifications.Data.Repositories.Notifications
{
    public class Notification
    {
        public string Error { get; private set; }
        public string Message { get; private set; }

        public Notification(string error, string message)
        {
            Error = error;
            Message = message;
        }
    }
}
