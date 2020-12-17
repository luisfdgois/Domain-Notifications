using TesteNotifications.Application.Helpers;
using TesteNotifications.Application.ViewModels;

namespace TesteNotifications.Application.Contracts
{
    public interface QueryRepository
    {
        PaginatedList<AlunoViewModel> ListarAlunos(int pagAtual, int totalPorPag);
    }
}
