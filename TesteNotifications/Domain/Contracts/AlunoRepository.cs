using TesteNotifications.Domain.Entities;

namespace TesteNotifications.Domain.Contracts
{
    public interface AlunoRepository
    {
        void Adicionar(Aluno aluno);
        bool Commit();
    }
}
