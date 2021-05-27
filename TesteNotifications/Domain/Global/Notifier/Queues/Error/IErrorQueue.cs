using System.Collections.Generic;
using TesteNotifications.Domain.Global.Notifier.DataTypes.Error;

namespace TesteNotifications.Domain.Global.Notifier.Queues.Error
{
    public interface IErrorQueue
    {
        public bool HasError { get; }
        void Insert(ErrorMessage errorMessage);
        IList<ErrorMessage> ReadErrors();
    }
}
