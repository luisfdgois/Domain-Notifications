using System.Collections.Generic;
using TesteNotifications.Models.ViewModels;

namespace TesteNotifications.Querys
{
    public interface RepositoryQuery
    {
        ICollection<AlunoViewModel> ListarAlunos();
    }
}
