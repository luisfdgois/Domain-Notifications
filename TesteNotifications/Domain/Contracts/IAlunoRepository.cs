using TesteNotifications.Domain.Models.Entities;

namespace TesteNotifications.Domain.Contracts
{
    public interface IAlunoRepository
    {
        void Adicionar(Aluno aluno);
        bool Commit();
    }
}
