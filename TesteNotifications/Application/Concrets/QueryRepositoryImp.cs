using System.Linq;
using TesteNotifications.Application.Contracts;
using TesteNotifications.Application.Helpers;
using TesteNotifications.Application.ViewModels;
using TesteNotifications.Infra.Data;

namespace TesteNotifications.Application.Concrets
{
    public class QueryRepositoryImp : QueryRepository
    {
        private readonly ProjectContext _projectContext;

        public QueryRepositoryImp(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public PaginatedList<AlunoViewModel> ListarAlunos(int pagAtual, int totalPorPag)
        {
            var alunos = _projectContext.Alunos
                                        .OrderBy(a => a.Nome)
                                        .Select(a => new AlunoViewModel
                                        {
                                            nome = a.Nome,
                                            matricula = a.Matricula,
                                            nascimento = a.Nascimento
                                        });

            if (PaginarLista(pagAtual, totalPorPag))
            {
                return PaginatedList<AlunoViewModel>.Create(alunos, pagAtual, totalPorPag);
            }

            return new PaginatedList<AlunoViewModel>(alunos.ToList(), 0, 0, 0);
        }

        private bool PaginarLista(int pagAtual, int totalPorPag)
        {
            return (pagAtual > 0 && totalPorPag > 0);
        }
    }
}
