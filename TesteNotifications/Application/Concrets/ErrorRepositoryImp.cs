using System.Collections.Generic;
using System.Linq;
using TesteNotifications.Application.Contracts;
using TesteNotifications.Application.DataStructure;

namespace TesteNotifications.Application.Concrets
{
    public class ErrorRepositoryImp : ErrorRepository
    {
        private readonly IList<ErrorMessage> _errors;

        public ErrorRepositoryImp()
        {
            _errors = new List<ErrorMessage>();
        }

        public void Add(ErrorMessage errorMessage)
        {
            _errors.Add(errorMessage);
        }

        public IList<ErrorMessage> GetErrors()
        {
            return _errors;
        }

        public bool HasErrors()
        {
            return _errors.Any();
        }
    }
}
