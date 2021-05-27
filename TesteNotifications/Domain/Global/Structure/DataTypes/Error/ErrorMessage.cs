using System;

namespace TesteNotifications.Domain.Global.Structure.DataTypes.Error
{
    public class ErrorMessage
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public ErrorMessage(string error, string message)
        {
            Error = error;
            Message = message;
            Date = DateTime.Now;
        }
    }
}
