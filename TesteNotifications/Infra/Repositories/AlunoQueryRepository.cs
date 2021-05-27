using System.Linq;
using TesteNotifications.Domain.Contracts;
using TesteNotifications.Domain.Helpers;
using TesteNotifications.Domain.Models.ValueObjects;
using TesteNotifications.Infra.Data;

namespace TesteNotifications.Infra.Repositories
{
    public class AlunoQueryRepository : IAlunoQueryRepository
    {
        private readonly ProjectContext _projectContext;

        public AlunoQueryRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public PaginatedList<AlunoVM> ListarAlunos(int pagAtual, int totalPorPag)
        {
            var alunos = _projectContext.Alunos
                                        .OrderBy(a => a.Nome)
                                        .Select(a => new AlunoVM
                                        {
                                            Nome = a.Nome,
                                            Matricula = a.Matricula,
                                            Nascimento = a.Nascimento
                                        });

            if (PaginarLista(pagAtual, totalPorPag))
            {
                return PaginatedList<AlunoVM>.Create(alunos, pagAtual, totalPorPag);
            }

            return new PaginatedList<AlunoVM>(alunos.ToList(), 0, 0, 0);
        }

        private bool PaginarLista(int pagAtual, int totalPorPag)
        {
            return pagAtual > 0 && totalPorPag > 0;
        }
    }
}
