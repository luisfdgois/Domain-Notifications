using TesteNotifications.Domain.Helpers;
using TesteNotifications.Domain.Models.ValueObjects;

namespace TesteNotifications.Domain.Contracts
{
    public interface IAlunoQueryRepository
    {
        PaginatedList<AlunoVM> ListarAlunos(int pagAtual, int totalPorPag);
    }
}
