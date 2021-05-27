using System.Collections.Generic;
using TesteNotifications.Domain.Global.Structure.DataTypes.Error;

namespace TesteNotifications.Domain.Global.Structure.Queues.Error
{
    public interface IErrorQueue
    {
        public bool HasError { get; }
        void Insert(ErrorMessage errorMessage);
        IList<ErrorMessage> ReadErrors();
    }
}
