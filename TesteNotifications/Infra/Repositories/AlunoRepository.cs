using TesteNotifications.Domain.Contracts;
using TesteNotifications.Domain.Models.Entities;
using TesteNotifications.Infra.Data;

namespace TesteNotifications.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ProjectContext _context;

        public AlunoRepository(ProjectContext context)
        {
            _context = context;
        }

        public void Adicionar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
