using System.Collections.Generic;
using System.Linq;
using TesteNotifications.Domain.Global.Notifier.DataTypes.Error;

namespace TesteNotifications.Domain.Global.Notifier.Queues.Error
{
    public class ErrorQueue : IErrorQueue
    {
        private readonly IList<ErrorMessage> _errors;

        public ErrorQueue()
        {
            _errors = new List<ErrorMessage>();
        }

        public bool HasError => _errors.Any();

        public void Insert(ErrorMessage errorMessage)
        {
            _errors.Add(errorMessage);
        }

        public IList<ErrorMessage> ReadErrors()
        {
            return _errors;
        }
    }
}
