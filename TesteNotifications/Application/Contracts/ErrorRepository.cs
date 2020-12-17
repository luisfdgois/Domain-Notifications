using System.Collections.Generic;
using TesteNotifications.Application.DataStructure;

namespace TesteNotifications.Application.Contracts
{
    public interface ErrorRepository
    {
        void Add(ErrorMessage errorMessage);
        IList<ErrorMessage> GetErrors();
        bool HasErrors();

    }
}
