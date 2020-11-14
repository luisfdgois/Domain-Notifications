using System;
using System.Collections.Generic;
using TesteNotifications.Models.Entities;

namespace TesteNotifications.Data.Repositories
{
    public interface RepositoryAluno
    {
        void Adicionar(Aluno aluno);
        ICollection<Aluno> ObterTodos();
        Aluno ObterPorId(Guid alunoId);
        Aluno ObterPorMatricula(int matricula);
    }
}
